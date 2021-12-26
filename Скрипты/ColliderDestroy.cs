using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDestroy : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
    }
}
