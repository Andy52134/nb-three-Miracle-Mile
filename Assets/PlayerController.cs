using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{


    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 lastMoveDirection; // Added to store the last non-zero movement direction
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovementInput();
        UpdateAnimator();
    }

    void HandleMovementInput()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (moveInput.magnitude > 0)
        {
            lastMoveDirection = moveInput; // Store the last non-zero movement direction
        }

        Vector2 moveVelocity = moveInput * moveSpeed;
        rb.velocity = moveVelocity;
    }

    void UpdateAnimator()
    {
        animator.SetFloat("Xinput", lastMoveDirection.x);
        animator.SetFloat("Yinput", lastMoveDirection.y);
        animator.SetBool("isMoving", moveInput.magnitude > 0);
    }


}
