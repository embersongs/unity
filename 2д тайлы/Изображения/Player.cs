using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;

    // Update is called once per frame
    void Update()
    {
        //нефизическое перемещение
        //float moveX = Input.GetAxis("Horizontal");
        //float moveY = Input.GetAxis("Vertical");
        //  transform.Translate(moveX * Time.deltaTime * speed, moveY * Time.deltaTime * speed, 0);
    }

    private void FixedUpdate()
    {
        //физическое перемещение
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, moveY * speed);
    }
}
