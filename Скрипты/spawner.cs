using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject obj;

    void Start()
    {
        InvokeRepeating("Spawn", 0, 0.02f);
    }

    
    void Spawn()
    {
        Instantiate(obj, transform.position, transform.rotation);
    }

    private void Update()
    {

    }
}
