using System;
using Audio;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    public class PlayerMovement : MonoBehaviour
    {
        /// <summary>
        /// The mouse control
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
        /// The controller pushing sensitivity
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
        /// The angle offset
        /// </summary>
        public int angleOffset = -90;

        /// <summary>
        /// The animator
        /// </summary>
        private Animator _animator;
        /// <summary>
        /// The game manager
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
        /// The player shooting
        /// </summary>
        private PlayerShooting _playerShooting;
        /// <summary>
        /// The body
        /// </summary>
        private Rigidbody2D _body;

        /// <summary>
        /// The can dash
        /// </summary>
        [HideInInspector] public bool canDash;
        /// <summary>
        /// The dashing
        /// </summary>
        public bool dashing;
        /// <summary>
        /// The firing
        /// </summary>
        private bool _firing;
        /// <summary>
        /// The angle
        /// </summary>
        private float _angle;
        /// <summary>
        /// The dash cooldown left
        /// </summary>
        private float _dashCooldownLeft;
        /// <summary>
        /// The dash left
        /// </summary>
        private float _dashLeft;
        /// <summary>
        /// The last angle
        /// </summary>
        private float _lastAngle;

        /// <summary>
        /// The dash direction
        /// </summary>
        private Vector2 _dashDirection;
        /// <summary>
        /// The aim
        /// </summary>
        private Vector2 _aim;
        /// <summary>
        /// The move
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
            _playerShooting = GetComponent<PlayerShooting>();
            canDash = true;
            _dashCooldownLeft = 0f;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        private void Update()
        {
            _trailRenderer.emitting = dashing;
            RotateTo();
            if (_firing) _playerShooting.Shoot();
            if (dashing) _dashLeft -= Time.deltaTime;
            else _dashCooldownLeft -= Time.deltaTime;
            if (_dashCooldownLeft <= 0f) canDash = true;
            //isto e tudo so para o dash
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
        /// Fixeds the update.
        /// </summary>
        private void FixedUpdate()
        {
            _body.velocity = !dashing
                ? _move * runSpeed
                : (_dashDirection * 10).normalized * dashSpeed;
        }

        /// <summary>
        /// Rotates to.
        /// </summary>
        private void RotateTo()
        {
            if (mouseControl)
            {
                Vector3 mousePosition = Mouse.current.position.ReadValue();

                Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.localPosition);

                _aim = ((Vector2) mousePosition - (Vector2) screenPosition).normalized;
            }

            _lastAngle = _angle;
            _angle = Mathf.Atan2(_aim.y, _aim.x) * Mathf.Rad2Deg + angleOffset;
            if (!mouseControl && Mathf.Abs(_lastAngle - _angle) > controllerRotationSensitivity)
                transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
            if (mouseControl && Mathf.Abs(_lastAngle - _angle) > mouseRotationSensitivity)
                transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        }
    }
}