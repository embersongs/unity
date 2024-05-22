using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 5;
    private bool onGround = true;
    public GameObject hitEffect;
    public GameObject point;

    private void Start()
    {
        InvokeRepeating("pointGenerator", 0, 0.1f);
    }

    private void pointGenerator()
    {
        Instantiate(point, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Instantiate(hitEffect, collision.ClosestPoint(transform.position), transform.rotation);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Instantiate(hitEffect, collision.ClosestPoint(transform.position), transform.rotation);
            onGround = false;
        }
    }

    private void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * jumpForce;
        }
    }

    private void FixedUpdate()
    {
        // ѕеремещение по горизонтали и вертикали
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal > 0) GetComponent<SpriteRenderer>().flipX = false;
        if (moveHorizontal < 0) GetComponent<SpriteRenderer>().flipX = true;

       

        // «адаем вектор направлени€ только по горизонтали
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);

        // Ќормализуем вектор дл€ избежани€ движени€ быстрее/медленнее при движении по диагонали
        movement = movement * speed * Time.deltaTime;

        // ѕеремещаем персонажа
        transform.Translate(movement);

        if (Mathf.Abs(moveHorizontal) > 0.01f)
        {
            GetComponent<Animator>().SetBool("isRun", true);
        } else
        {
            GetComponent<Animator>().SetBool("isRun", false);
        }

    }
}
