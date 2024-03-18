using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float force = 200; //Сила шага движения
    public int Left = -2;   //Количество шагов влево при патруле
    public int Right = 2;   //Количество шагов вправо при патруле
    public bool randomMove = false; //Галочка случайное движение и прыжок
    public float period = 1;    //Частота движени в секундах

    private Rigidbody2D rb;     //в rb храним физическое тело
    private int Direction = 1;  //Направление движения 1-влево 2-вправо 3-прыжок
    private int DirCounter = 0; //Счетчик шагов, с минусом будут шаги влево

    void Start()
    {
        //При старте игры, получаем компонент физическое тело
        rb = GetComponent<Rigidbody2D>();
        //Запускаем циклично через 0 секунд с периодом pediod вызывать действие Move()
        InvokeRepeating("Move", 0, period);
    }

    private void Move()
    {
        //Если стоит галочка случайное движение
        if (randomMove)
        {
            //Генерируем случайное число от 1 до 3
            Direction = Random.Range(1, 4);

            //Движение влево
            if (Direction == 1)
            {
                rb.AddForce(Vector2.left * force);
            }
            //Движение вправо
            if (Direction == 2)
            {
                rb.AddForce(Vector2.right * force);
            }
            //Прыжок
            if (Direction == 3)
            {
                rb.AddForce(Vector2.up * force);
            }
            //Сброс направления, если вдруг снимется галочка случайное движение
            Direction = 1;
            return;
        }

        //Если движение влево
        if (Direction == 1)
        {
            rb.AddForce(Vector2.left * force);
            DirCounter--;
            if (DirCounter == Left) Direction = 2;
            return;
        }
        //Если движение вправо
        if (Direction == 2)
        {
            rb.AddForce(Vector2.right * force);
            DirCounter++;
            if (DirCounter == Right) Direction = 1;
            return;
        }


    }

    //Действия при столкновении с другим isTrigger коллайдером
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Если это игрок
        if (collision.CompareTag("Player"))
        {
            //Перезагружаем уровень с начала
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

  

 
}
