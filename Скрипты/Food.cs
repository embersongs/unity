using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public string foodName;
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //player = GameObject.Find("Player");
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.SendMessage("getFood", foodName);
            Destroy(gameObject);
        }
    }
}
