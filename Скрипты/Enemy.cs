using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float force = 200;
    public int Left = -2;
    public int Right = 2;
    public bool randomMove = false;
    public float period = 1;

    private Rigidbody2D rb;
    private int Direction = 1;
    private int DirCounter = 0;


    private void Move()
    {
        if (randomMove)
        {
            Direction = Random.Range(1, 4);

            if (Direction == 1)
            {
                rb.AddForce(Vector2.left * force);
            }
            if (Direction == 2)
            {
                rb.AddForce(Vector2.right * force);
            }
            if (Direction == 3)
            {
                rb.AddForce(Vector2.up * force);
            }
            Direction = 1;
            return;
        }

        if (Direction == 1)
        {
            rb.AddForce(Vector2.left * force);
            DirCounter--;
            if (DirCounter == Left) Direction = 2;
            return;
        }
        if (Direction == 2)
        {
            rb.AddForce(Vector2.right * force);
            DirCounter++;
            if (DirCounter == Right) Direction = 1;
            return;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Move", 0, period);
    }

 
}
