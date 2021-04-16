using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int angleOffset;

    private Rigidbody2D _body;
    private Camera _camera;

    private float _horizontal;
    private float _vertical;

    public float runSpeed = 20.0f;
    public bool mouseControl = false;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        if (mouseControl)
        {
            var dir = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            RotateTo(dir);
            if (Input.GetButtonDown("Fire"))
            {
                Shoot();
            }
        }
        else
        {
            var horizontalAim = Input.GetAxisRaw("HorizontalAim");
            var verticalAim = Input.GetAxisRaw("VerticalAim");
            var dir = new Vector2(horizontalAim, verticalAim);
            RotateTo(dir);
            if (!(dir.magnitude <= 0.01))
            {
                Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        _body.velocity = new Vector2(_horizontal * runSpeed, _vertical * runSpeed);
    }

    private void RotateTo(Vector2 dir)
    {
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Shoot()
    {
        Debug.Log("Shoot");
    }
}