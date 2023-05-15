using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f; 
    [SerializeField] private float jumpForce = 15;
    [SerializeField] private int extraJumps = 2;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private bool isMoving;
    public bool onGround;
    private float moveHorizontal;
    public int exJumps;

    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = true;
            exJumps = extraJumps;
            anim.SetBool("isJump", false);
            anim.SetBool("isFall", false);
        }

        if (collision.CompareTag("Fire"))
        {
            anim.SetBool("isHit", true);
        }

    }

    private void endJump2()
    {
        anim.SetBool("isJump2", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = false;
            
        }

        if (collision.CompareTag("Fire"))
        {
            anim.SetBool("isHit", false);
        }
    }

    private void Update()
    {
        
        moveHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && exJumps > 0)
        {
            
            exJumps--;
            if (exJumps == 0)
            {
                Debug.Log("Jumpo");
                anim.SetBool("isJump2", true);
            }
            rb.velocity = transform.up * jumpForce;
        }

        isMoving = moveHorizontal != 0 ? true : false;

        if (isMoving)
        {
            sr.flipX = moveHorizontal > 0 ? false : true;
        }

        if (!onGround)
        {
            if (rb.velocity.y > 0) anim.SetBool("isJump", true);

            if (rb.velocity.y < 0)
            {
                anim.SetBool("isJump", false);
                anim.SetBool("isFall", true);
            }
        }
      

        anim.SetBool("isMoving", isMoving);
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(moveHorizontal * speed * Time.fixedDeltaTime, rb.velocity.y);

    }


}
