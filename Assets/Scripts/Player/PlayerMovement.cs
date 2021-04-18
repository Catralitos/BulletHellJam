using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool mouseControl;
        public float aimSensitivity = 0.75f;
        public float dashCooldown = 1f;
        public float dashSpeed = 10;
        public float dashTime = 0.5f;
        public float rotationSensitivity = 1.15f;
        public float runSpeed = 20.0f;
        public int angleOffset = -90;

        private Camera _camera;
        private PlayerControls _playerControls;
        private PlayerShooting _playerShooting;
        private Rigidbody2D _body;

        private bool _canDash;
        private bool _dashing;
        private bool _firing;
        private float _angle;
        private float _dashCooldownLeft;
        private float _dashLeft;
        private float _lastAngle;

        private Vector2 _dashDirection;
        private Vector2 _aim;
        private Vector2 _move;

        private void Awake()
        {
            _playerControls = new PlayerControls();

            if (mouseControl)
            {
                _playerControls.KeyboardGameplay.Fire.performed += _ => _firing = true;
                _playerControls.KeyboardGameplay.Fire.canceled += _ => _firing = false;
                _playerControls.KeyboardGameplay.Move.performed += ctx => { _move = ctx.ReadValue<Vector2>(); };
                _playerControls.KeyboardGameplay.Move.canceled += _ => _move = Vector2.zero;
                _playerControls.KeyboardGameplay.Aim.performed += ctx =>
                {
                    var dir = _camera.WorldToScreenPoint(transform.position);
                    _aim = ctx.ReadValue<Vector2>() - new Vector2(dir.x, dir.y);
                };
                _playerControls.KeyboardGameplay.Dash.performed += _ =>
                {
                    if (_dashing || !_canDash) return;
                    _dashing = true;
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
                    if (valueRounded.magnitude < aimSensitivity) return;
                    _aim = valueRounded;
                    _firing = true;
                };
                _playerControls.ControllerGameplay.Aim.canceled += _ => _firing = false;
                _playerControls.ControllerGameplay.Dash.started += _ =>
                {
                    if (_dashing || !_canDash) return;
                    _dashing = true;
                    _dashDirection = _move;
                };
            }
        }

        private void OnEnable()
        {
            if (mouseControl) _playerControls.KeyboardGameplay.Enable();
            else _playerControls.ControllerGameplay.Enable();
        }

        private void OnDisable()
        {
            if (mouseControl) _playerControls.KeyboardGameplay.Disable();
            else _playerControls.ControllerGameplay.Disable();
        }

        private void Start()
        {
            _body = GetComponent<Rigidbody2D>();
            _camera = Camera.main;
            _playerShooting = GetComponent<PlayerShooting>();
        }

        private void Update()
        {
            RotateTo();
            if (_firing) _playerShooting.Shoot();
            if (_dashing) _dashLeft -= Time.deltaTime;
            else _dashCooldownLeft -= Time.deltaTime;
            if (_dashCooldownLeft < 0f) _canDash = true;
            if (_dashLeft >= 0f) return;
            _dashDirection = Vector2.zero;
            _body.velocity = Vector2.zero;
            _dashing = false;
            _dashLeft = dashTime;
            _canDash = false;
            _dashCooldownLeft = dashCooldown;
        }

        private void FixedUpdate()
        {
            _body.velocity = !_dashing
                ? _move * runSpeed
                : (_dashDirection * 10).normalized * dashSpeed;
        }

        private void RotateTo()
        {
            _lastAngle = _angle;
            _angle = Mathf.Atan2(_aim.y, _aim.x) * Mathf.Rad2Deg + angleOffset;
            if (Mathf.Abs(_lastAngle - _angle) > rotationSensitivity)
                transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        }
    }
}