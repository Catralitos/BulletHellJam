using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _body;
    
    private float _horizontal;
    private float _vertical;
    
    public float runSpeed = 20.0f;
    
    private void Start ()
    {
       _body = GetComponent<Rigidbody2D>(); 
    }
    
    private void Update ()
    {
       _horizontal = Input.GetAxisRaw("Horizontal");
       _vertical = Input.GetAxisRaw("Vertical"); 
    }
    
    private void FixedUpdate()
    {  
       _body.velocity = new Vector2(_horizontal * runSpeed, _vertical * runSpeed);
    }
}
