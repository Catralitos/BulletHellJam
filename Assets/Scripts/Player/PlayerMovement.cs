using System;
using Audio;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    /// The class that handles the player movement
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class PlayerMovement : MonoBehaviour
    {
        /// <summary>
        /// If the game is being played with keyboard and mouse (true) or a controller (false)
        /// </summary>
        public bool mouseControl;
        /// <summary>
        /// The dash cooldown
        /// </summary>
        public float dashCooldown = 1f;
        /// <summary>
        /// The dash speed
        /// </summary>
        public float dashSpeed = 10;
        /// <summary>
        /// The dash time
        /// </summary>
        public float dashTime = 0.5f;

        /// <summary>
        /// The mouse rotation sensitivity
        /// </summary>
        public float mouseRotationSensitivity = -1.15f;
        /// <summary>
        /// The controller movement sensitivity
        /// </summary>
        public float controllerPushingSensitivity = 0.75f;
        /// <summary>
        /// The controller rotation sensitivity
        /// </summary>
        public float controllerRotationSensitivity = 1.15f;

        /// <summary>
        /// The run speed
        /// </summary>
        public float runSpeed = 20.0f;
        /// <summary>
        /// The angle offset of the character
        /// </summary>
        public int angleOffset = -90;

        /// <summary>
        /// The animator
        /// </summary>
        private Animator _animator;
        /// <summary>
        /// The GameManager
        /// </summary>
        private GameManager _gameManager;
        /// <summary>
        /// The trail renderer
        /// </summary>
        private TrailRenderer _trailRenderer;
        /// <summary>
        /// The player controls
        /// </summary>
        private PlayerControls _playerControls;
        /// <summary>
        /// The body
        /// </summary>
        private Rigidbody2D _body;

        /// <summary>
        /// If the character can dash
        /// </summary>
        [HideInInspector] public bool canDash;
        /// <summary>
        /// If the character is dashing
        /// </summary>
        public bool dashing;
        /// <summary>
        /// If the character is firing
        /// </summary>
        private bool _firing;
        /// <summary>
        /// The current angle of the character
        /// </summary>
        private float _angle;
        /// <summary>
        /// The dash cooldown left
        /// </summary>
        private float _dashCooldownLeft;
        /// <summary>
        /// The dash time left
        /// </summary>
        private float _dashLeft;
        /// <summary>
        /// The angle in the last frame
        /// </summary>
        private float _lastAngle;

        /// <summary>
        /// The dash direction
        /// </summary>
        private Vector2 _dashDirection;
        /// <summary>
        /// The aim direction
        /// </summary>
        private Vector2 _aim;
        /// <summary>
        /// The move direction
        /// </summary>
        private Vector2 _move;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake()
        {
            _gameManager = GameManager.Instance;
            _playerControls = new PlayerControls();
            mouseControl = _gameManager.mouseControls;
            canDash = true;
            _dashCooldownLeft = 0f;
            //Using the next input system, depending on the controls, we set up the varioous events
            if (mouseControl)
            {
                _playerControls.KeyboardGameplay.Fire.performed += _ => _firing = true;
                _playerControls.KeyboardGameplay.Fire.canceled += _ => _firing = false;
                _playerControls.KeyboardGameplay.Move.performed += ctx => { _move = ctx.ReadValue<Vector2>(); };
                _playerControls.KeyboardGameplay.Move.canceled += _ => _move = Vector2.zero;
                _playerControls.KeyboardGameplay.Dash.performed += _ =>
                {
                    if (dashing || !canDash || _move.magnitude <= 0.01f) return;
                    dashing = true;
                    AudioManager.Instance.Play("Dash");
                    _animator.SetBool("Dashing", true);
                    _dashDirection = _move;
                };
            }
            else
            {
                _playerControls.ControllerGameplay.Move.performed += ctx => { _move = ctx.ReadValue<Vector2>(); };
                _playerControls.ControllerGameplay.Move.canceled += _ => { _move = Vector2.zero; };
                _playerControls.ControllerGameplay.Aim.performed += ctx =>
                {
                    var value = ctx.ReadValue<Vector2>();
                    var valueRounded = new Vector2((float) Math.Round(value.x, 2), (float) Math.Round(value.y, 2));
                    if (valueRounded.magnitude < controllerPushingSensitivity) return;
                    _aim = valueRounded;
                    _firing = true;
                };
                _playerControls.ControllerGameplay.Aim.canceled += _ => _firing = false;
                _playerControls.ControllerGameplay.Dash.started += _ =>
                {
                    if (dashing || !canDash || _move.magnitude <= 0.01f) return;
                    dashing = true;
                    _animator.SetBool("Dashing", true);
                    AudioManager.Instance.Play("Dash");
                    _dashDirection = _move;
                };
            }
        }

        /// <summary>
        /// Called when [enable].
        /// </summary>
        private void OnEnable()
        {
            if (mouseControl) _playerControls.KeyboardGameplay.Enable();
            else _playerControls.ControllerGameplay.Enable();
        }

        /// <summary>
        /// Called when [disable].
        /// </summary>
        private void OnDisable()
        {
            if (mouseControl) _playerControls.KeyboardGameplay.Disable();
            else _playerControls.ControllerGameplay.Disable();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
            _trailRenderer = GetComponent<TrailRenderer>();
            _animator = GetComponent<Animator>();
            _body = GetComponent<Rigidbody2D>();
            canDash = true;
            _dashCooldownLeft = 0f;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        private void Update()
        {
            //If the player is dashing, emit a trail
            _trailRenderer.emitting = dashing;
            //Rotate the sprite
            RotateTo();
            //Perform actions according to inputs/cooldowns left
            if (_firing) PlayerEntity.Instance.shooting.Shoot();
            if (dashing) _dashLeft -= Time.deltaTime;
            else _dashCooldownLeft -= Time.deltaTime;
            if (_dashCooldownLeft <= 0f) canDash = true;
  
            //This code is to execute the dash
            if (_dashLeft > 0f) return;
            _dashDirection = Vector2.zero;
            _body.velocity = Vector2.zero;
            dashing = false;
            _animator.SetBool("Dashing", false);
            _dashLeft = dashTime;
            canDash = false;
            _dashCooldownLeft = dashCooldown;
        }

        /// <summary>
        /// Updates this instance at a fixed rate
        /// </summary>
        private void FixedUpdate()
        {
            //Set eth body's velocity according to if they're dashing
            _body.velocity = !dashing
                ? _move * runSpeed
                : (_dashDirection * 10).normalized * dashSpeed;
        }

        /// <summary>
        /// Rotates to the right positin
        /// </summary>
        private void RotateTo()
        {
            //Using mouse control, we need to get the position where the mouse is, and get the angle with the player character
            if (mouseControl)
            {
                Vector3 mousePosition = Mouse.current.position.ReadValue();

                if (Camera.main != null)
                {
                    Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.localPosition);

                    _aim = ((Vector2) mousePosition - (Vector2) screenPosition).normalized;
                }
            }

            _lastAngle = _angle;
            _angle = Mathf.Atan2(_aim.y, _aim.x) * Mathf.Rad2Deg + angleOffset;
            //We check the angle on the last frame.
            //If the angle difference is very small, in order to avoid jittery rotation,
            //we discard the input.
            switch (mouseControl)
            {
                case false when Mathf.Abs(_lastAngle - _angle) > controllerRotationSensitivity:
                case true when Mathf.Abs(_lastAngle - _angle) > mouseRotationSensitivity:
                    transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
                    break;
            }
        }
    }
}