using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject fon;
    public float scale = 0.08f;

    private void Update()
    {
        fon.transform.position = new Vector2(transform.position.x * scale, fon.transform.position.y);
    }
}
