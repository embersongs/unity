using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smooth = 1;

    // Update is called once per frame
    void Update()
    {
        Vector3 nextPos = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth);
        transform.position = nextPos;
    }
}
