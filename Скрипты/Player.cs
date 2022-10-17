using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float horizontal;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Level2");
        }
        
    }


    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * 0.05f;

        transform.Translate(horizontal, 0, 0);
        
    }
}
