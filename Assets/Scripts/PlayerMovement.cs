using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int angleOffset;
   
    private Rigidbody2D _body;
    private Camera _camera;
    
    private float _horizontal;
    private float _vertical;
    
    public float runSpeed = 20.0f;
    
    private void Start ()
    {
       _body = GetComponent<Rigidbody2D>(); 
       _camera = Camera.main;
    }
    
    private void Update ()
    {
       _horizontal = Input.GetAxisRaw("Horizontal");
       _vertical = Input.GetAxisRaw("Vertical"); 
       var dir = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
       var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
       transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
       
    }
    
    private void FixedUpdate()
    {  
       _body.velocity = new Vector2(_horizontal * runSpeed, _vertical * runSpeed);
    }
}