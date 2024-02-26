using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float life = 100;
    private Rigidbody rb;
    public GameObject target;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("MoveToTarget", 0, 1);
    }

    public void getDamage(float damage)
    {
        life = life - damage;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }


    //импульс силы в сторону цели
    private void MoveToTarget()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            rb.AddForce(direction * 50, ForceMode.Impulse);
        }

    }

    //импульс в случайном направлении
    private void Move()
    {
        float randomAngle = Random.Range(0f, 360f);
        Vector3 randomDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
        rb.AddForce(randomDirection * 50, ForceMode.Impulse);
    }

}
