using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            car1.SetActive(true);
            car1.transform.position =new Vector3(54, 27.3f, 320);
            car1.transform.eulerAngles = new Vector3(0, -201.649f, 0);
            car2.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            car2.SetActive(true);
            car2.transform.position = new Vector3(54, 27.3f, 320);
            car2.transform.eulerAngles = new Vector3(0, -201.649f, 0);
            car1.SetActive(false);
        }
    }
}
