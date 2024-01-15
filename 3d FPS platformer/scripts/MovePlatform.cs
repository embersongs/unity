using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovePlatform : MonoBehaviour
{
    public GameObject Player;

    // Как только на платформу запрыгнет Player, делаем его дочерним элементом
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    //При покидании платформы разрываем связь
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            other.gameObject.transform.SetParent(null);
        }
    }


    void FixedUpdate()
    {
        //Двигаем куб, важно что именно через Fixed, иначе игрок будет двигаться не правильно
        var step = 2 * Time.deltaTime; //2 скорость движения платформы
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.0f, 0.3f, 110.0f), step);
    }
}
