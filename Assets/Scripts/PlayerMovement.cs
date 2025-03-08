using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class for managing the player's movement.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 movement;
    [Tooltip("This controls the player's speed.")]
    public float speed = 2.0f;
    [Tooltip("This controls the player's running speed.")]
    public float runningSpeed = 4.0f;
    private float inputHor,inputVer;
    private Animator animator;
    private Transform interactions;

    private void Start()
    {
        inputHor = Input.GetAxisRaw("Horizontal");
        inputVer = Input.GetAxisRaw("Vertical");
        inputHor = 0;
        inputVer = 0;
        rb = GetComponent<Rigidbody2D>();

        /// This is PlayerGFX game object.
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();

        /// This is the Interactions game object.
        interactions = gameObject.transform.GetChild(1);
    }
    void Update()
    {
        inputHor = Input.GetAxisRaw("Horizontal");
        inputVer = Input.GetAxisRaw("Vertical");
        movement.x = inputHor;
        movement.y = inputVer;

        /// Change from walking to running.
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }
        else
        {
            speed = 2.0f;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(inputHor == 1 || inputHor == -1 || inputVer == 1 || inputVer == -1)
        {
            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }
        
        if (inputHor > 0)  
        {
            interactions.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (inputHor < 0) 
        {
            interactions.localRotation = Quaternion.Euler(0, 0, -90);
        }
        else  
        {
            if (inputVer > 0)
            {
                interactions.localRotation = Quaternion.Euler(0, 0, 180);
            }
            else if (inputVer < 0)
            {
                interactions.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

}
