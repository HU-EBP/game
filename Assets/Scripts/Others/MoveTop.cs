using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTop : MonoBehaviour
{
    // Movement variables
    [SerializeField] private float speed = 5f;

    // Components and variables
    private Rigidbody2D rb;
    private Animator anim;

    // Get the character's Rigidbody2D and Animator components
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Get the player's input for horizontal and vertical movement
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Set the character's velocity based on their horizontal and vertical movement
        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        if (horizontalInput > 0f)
        {
            anim.SetBool("MovingLeft", false);
            anim.SetBool("MovingRight", true);
        }
        else if (horizontalInput < 0f)
        {
            anim.SetBool("MovingLeft", true);
            anim.SetBool("MovingRight", false);
        }
        else
        {
            anim.SetBool("MovingLeft", false);
            anim.SetBool("MovingRight", false);
        }

        if (verticalInput > 0f)
        {
            anim.SetBool("MovingDown", false);
            anim.SetBool("MovingUp", true);
        }
        else if (verticalInput < 0f)
        {
            anim.SetBool("MovingDown", true);
            anim.SetBool("MovingUp", false);
        }
        else
        {
            anim.SetBool("MovingDown", false);
            anim.SetBool("MovingUp", false);
        }
    }
}