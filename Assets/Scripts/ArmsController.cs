using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    public float speed;
    float horizontal;
    Rigidbody2D rigidbody2d;
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
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        if (horizontal < 0)
        {
            animator.SetBool("LookRight", false);
            animator.SetBool("LookLeft", true);
        }
        else if(horizontal >= 0);
        {
            animator.SetBool("LookRight", true);
            animator.SetBool("LookLeft", false);
        }


    }
    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        animator.SetFloat("MoveX", horizontal);
        rigidbody2d.MovePosition(position);
       

    }
}
