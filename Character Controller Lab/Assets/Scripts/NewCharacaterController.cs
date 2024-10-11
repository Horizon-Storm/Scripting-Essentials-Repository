using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharacaterController : MonoBehaviour
{
    private float speed = 20f;
    private float horizontalInput;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        //Assign the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        float horizontalMovement = horizontalInput * speed * Time.deltaTime;
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
