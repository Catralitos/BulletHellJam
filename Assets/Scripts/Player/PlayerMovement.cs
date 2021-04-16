using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public int angleOffset = -90;
        public float aimSensitivity = 0.75f;
        public float rotationSensitivity = 1.15f;
        public float runSpeed = 20.0f;
        public bool mouseControl = false;

        private PlayerControls _playerControls;
        private Rigidbody2D _body;
        private Camera _camera;
        private PlayerShooting _playerShooting;

        private Vector2 _move;
        private Vector2 _aim;
        private float _angle;
        private float _lastAngle;
        private bool _firing = false;

        private void Awake()
        {
            _playerControls = new PlayerControls();

            if (mouseControl)
            {
                _playerControls.KeyboardGameplay.Fire.performed += _ => _firing = true;
                _playerControls.KeyboardGameplay.Fire.canceled += _ => _firing = false;
                _playerControls.KeyboardGameplay.Move.performed += ctx => _move = ctx.ReadValue<Vector2>();
                _playerControls.KeyboardGameplay.Move.canceled += _ => _move = Vector2.zero;
                _playerControls.KeyboardGameplay.Aim.performed += ctx =>
                {
                    var dir = _camera.WorldToScreenPoint(transform.position);
                    _aim = ctx.ReadValue<Vector2>() - new Vector2(dir.x, dir.y);
                };
            }
            else
            {
                _playerControls.ControllerGameplay.Move.performed += ctx => _move = ctx.ReadValue<Vector2>();
                _playerControls.ControllerGameplay.Move.canceled += _ => _move = Vector2.zero;
                _playerControls.ControllerGameplay.Aim.performed += ctx =>
                {
                    var value = ctx.ReadValue<Vector2>();
                    var valueRounded = new Vector2((float) Math.Round(value.x, 2), (float) Math.Round(value.y, 2));
                    if (valueRounded.magnitude < aimSensitivity) return;
                    _aim = valueRounded;
                    _firing = true;
                };
                _playerControls.ControllerGameplay.Aim.canceled += _ => _firing = false;
            }
        }

        private void OnEnable()
        {
            if (mouseControl)
            {
                _playerControls.KeyboardGameplay.Enable();
            }
            else
            {
                _playerControls.ControllerGameplay.Enable();
            }
        }

        private void OnDisable()
        {
            if (mouseControl)
            {
                _playerControls.KeyboardGameplay.Disable();
            }
            else
            {
                _playerControls.ControllerGameplay.Disable();
            }
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
        }

        private void FixedUpdate()
        {
            _body.velocity = new Vector2(_move.x * runSpeed, _move.y * runSpeed);
        }

        private void RotateTo()
        {
            _lastAngle = _angle;
            _angle = Mathf.Atan2(_aim.y, _aim.x) * Mathf.Rad2Deg + angleOffset;
            //Debug.Log(Mathf.Abs(_lastAngle - _angle));
            if (Mathf.Abs(_lastAngle - _angle) > rotationSensitivity)
                transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        }
    }
}