using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15; //скорость 
    public float jump = 5;   //сила прыжка
    public float maxVelocity = 7f; //максимальна¤ скорость

    private Rigidbody2D rb;         //тут храним физическое тело
    private bool isGrounded = true; //состо¤ние на земле да

    //ѕри старте игры
    void Start()
    {
        //получаем компонент физическое тело и сохран¤ем в rb
        rb = GetComponent<Rigidbody2D>();  
    }

    //в процессе игры
    void FixedUpdate()
    {
        //получаем горизонтальный ввод от -1 до 1 значение, 0 в покое
        float horisontal = Input.GetAxis("Horizontal");

        //вычисл¤ем направление движени¤ умножив ввод на скорость, по y не мен¤ем значение
        Vector2 move = new Vector2(horisontal * speed, rb.velocity.y);

        //если скорость превышает допустимую
        if (rb.velocity.magnitude > maxVelocity)
        {
            //ограничим скорость максимальной
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }

        //двигаем шар через приложив ему силу в направлении движени¤
        rb.AddForce(move);

        //если нажат пробел и состо¤ние на земле
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            //устанавливаем вертикальную скорость вверх дл¤ прыжка
            rb.velocity = new Vector2(rb.velocity.x, jump);

            //мен¤ем состо¤ние не на земле
            isGrounded = false;
        }

       
    }

    // огда сталкиваемс¤ с другим коллайдером
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //≈сли столкнулись с землей
        if (collision.gameObject.tag == "Ground")
        {
            //мен¤ем состо¤ние на земле
            isGrounded = true;
        }
    }

 
}
