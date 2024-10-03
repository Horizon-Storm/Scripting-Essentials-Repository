using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        // Cache the animator component attached to Character
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        //Handle Running and Idling
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        
        //Handle Jumping
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
        }
        
        //Handle Wall Jump
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("WallJump");
        }
        
        //Handle Double Jump
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetTrigger("DoubleJump");
        }
        
        //Handle Falling
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Fall");
        }
        
        //Handle Getting Hit
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("Hit");
        }
    }
}
