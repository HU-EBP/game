using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSide : MonoBehaviour
{
    // Movement variables
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;

    // Layer mask to check if the character is on the ground
    [SerializeField] private LayerMask groundLayer;

    // Components and variables
    private Rigidbody2D rb;
    private Collider2D coll;
    private float moveInput;
    private bool isGrounded;
    private Animator anim;

    // Get the character's Rigidbody2D and Collider2D components
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Get the player's input for horizontal movement and jump
    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // Check if the player presses the jump button and is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (moveInput > 0f)
        {
            anim.SetBool("MovingLeft", false);
            anim.SetBool("MovingRight", true);
        }
        else if (moveInput < 0f)
        {
            anim.SetBool("MovingLeft", true);
            anim.SetBool("MovingRight", false);
        }
        else
        {
            anim.SetBool("MovingLeft", false);
            anim.SetBool("MovingRight", false);
        }
    }

    // Move the character and check if they are on the ground
    private void FixedUpdate()
    {
        // Set the character's velocity based on their horizontal movement and current vertical velocity
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Check if the character is on the ground
        CheckGrounded();
    }

    // Check if the character is on the ground using a raycast
    private void CheckGrounded()
    {
        // Define the length of the ray and its color for visualization
        float extraHeightText = 0.1f;
        Color rayColor;

        // Cast a ray down from the center of the character's collider to check if it hits anything on the ground layer
        RaycastHit2D raycastHit = Physics2D.Raycast(coll.bounds.center, Vector2.down, coll.bounds.extents.y + extraHeightText, groundLayer);

        // If the raycast hits something on the ground layer, the character is considered grounded
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
            isGrounded = true;
        }
        // Otherwise, the character is not grounded
        else
        {
            rayColor = Color.red;
            isGrounded = false;
        }

        // Visualize the raycast
        Debug.DrawRay(coll.bounds.center, Vector2.down * (coll.bounds.extents.y + extraHeightText), rayColor);
    }

    // Make the character jump
    private void Jump()
    {
        // Set the character's velocity in the y direction to the jump force
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}