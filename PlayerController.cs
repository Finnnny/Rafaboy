using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[HideInspector]
    public Rigidbody2D rb;
        
    public float speed;
    public float jumpingPower;
    public float horizontal;
    public bool isFacingRight;
    public AudioSource footstepsSound;

    private bool isGrounded;

    private bool isWalking;
    private bool isJump;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        InputMovement();
        HandleAnimation();
        Flip();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && isGrounded)
        {

            footstepsSound.enabled = true;

        }
        else
        {
            footstepsSound.enabled = false;
        }

    }

    void InputMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Debug.Log("Horizontal Value: " + horizontal);
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isJump = true;
        }
        
        if (isJump && isGrounded == true) 
        {
            isJump = false;
        }

        isWalking = horizontal!=0 ? true : false;
        
    }

    void HandleAnimation()
    {
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isJump", isJump);
    }

    void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2((horizontal * speed), rb.velocity.y);
    }

    private void LateUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = false;
            isJump = true;
        }
    }
}
