using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float time = 0.5f;

    void Start()
    {
        Destroy(gameObject, time);
    }

  
}
