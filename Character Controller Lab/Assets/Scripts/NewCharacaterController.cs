using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharacaterController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.4f;
    [SerializeField]
    private float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    private float horizontalInput;
    public Camera mainCamera;

    private float moveDirection = 0;
    bool facingRight = true;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D rb;
    CapsuleCollider2D mainCollider;
    Transform t;
    
    // Start is called before the first frame update
    void Start()
    {
        t = transform;
        //Assign the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        //Assign Collider Component
        mainCollider = GetComponent<CapsuleCollider2D>();
        //Freeze rotation on the player
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.gravityScale = gravityScale;

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        //Movement Controls
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (isGrounded || Mathf.Abs(rb.velocity.x) < 0.01f))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else
        {
            if (isGrounded || rb.velocity.magnitude < 0.0f)
            {
                moveDirection = 0;
            }
        }
        
        //Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }

            if (moveDirection < 0 && facingRight)
            {
               facingRight = false;
               t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }
        
        //Jumping
        if ((Input.GetKeyDown(KeyCode.W) || (Input.GetButton("Jump"))) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        
        //Camera Follow
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
        }
        
    }
    
    private void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos =
            colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        //Check if Player is Grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so , set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
        
        //Apply movement velocity
        rb.velocity = new Vector2((moveDirection) * speed, rb.velocity.y);
        
        //Simple Debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0,colliderRadius,0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius,0,0), isGrounded ? Color.green : Color.red);

    }
}
