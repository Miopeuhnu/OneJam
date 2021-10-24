using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    public float speed;
    public float jumpForce = 20f;
    float jumpTimeCounter;
    public float jumpTime;
    bool isJumping;
    float horizontal;
    
    Rigidbody2D rigidbody2d;
    public Transform feet;
    public LayerMask groundLayer;
    Animator animator;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&IsGrounded())
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0 && isJumping == true)
            {
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontal * speed, rigidbody2d.velocity.y);
        rigidbody2d.velocity = movement;
        animator.SetFloat("MoveX", horizontal);
        Debug.Log(horizontal);
       

    }
    void Jump()
    {
        Vector2 movement = new Vector2(rigidbody2d.velocity.x, jumpForce);
        rigidbody2d.velocity = movement;
        Debug.Log("Jump");
    }
    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.2f, groundLayer);
        if(groundCheck != null)
        {
            Debug.Log("is grounded");
            return true;
            
        }
        else
        {
            return false;
        }
    }
}

