using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjColliderCreate : MonoBehaviour
{
    public GameObject obj;
   
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Столкновение");
        Instantiate(
            obj, //что создавать
            other.gameObject.transform.position, //где создавать
            other.gameObject.transform.rotation // с каким поворотом
            );
    }

    // Update is called once per frame
    void Update()
    {

    }
}
