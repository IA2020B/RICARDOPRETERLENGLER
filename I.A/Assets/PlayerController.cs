using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveInput;
    public float speed;
    private Rigidbody2D rb;
    public static bool touchingGround = false;
    public float jumpForce;
    private bool jumped = false;
    public static bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {



        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }


    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && touchingGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumped = true;
        }

       
    }

    void Flip()
    {

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
}
