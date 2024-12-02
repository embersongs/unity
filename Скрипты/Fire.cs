using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public float speed = 30;



    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            GameObject spawnBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
            spawnBullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
        }
    }
}
