using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public int angleOffset = -90;
        public float aimSensitivity = 0.75f;
        public float runSpeed = 20.0f;
        public bool mouseControl = false;

        private PlayerControls _playerControls;
        private Rigidbody2D _body;
        private Camera _camera;
        private PlayerShooting _playerShooting;
        
        private Vector2 _move;
        private Vector2 _aim;
        
        private void Awake()
        {
            _playerControls = new PlayerControls();

            if (mouseControl)
            {
                _playerControls.KeyboardGameplay.Fire.performed += _ => _playerShooting.Shoot();
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
                    Vector2 value = ctx.ReadValue<Vector2>();
                    _aim = value.magnitude > aimSensitivity ? value : _aim;
                    _playerShooting.Shoot();
                };
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
        }

        private void FixedUpdate()
        {
            _body.velocity = new Vector2(_move.x * runSpeed, _move.y * runSpeed);
        }

        private void RotateTo()
        {
            //isto começa-te sempre virado para a direita, podemos por um _aim no awake ou assim
            var angle = Mathf.Atan2(_aim.y, _aim.x) * Mathf.Rad2Deg + angleOffset;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}