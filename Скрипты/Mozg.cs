using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Mozg : MonoBehaviour
{
    public Transform[] points;
    public Transform player;
    public float attackRangeMin = 5;
    public float attackRangeMax = 10;

    private int i = 0;

    void Start()
    {
        
         GetComponent<AICharacterControl>().target = points[i];
        

    }


    void Update()
    {
        //Определяем расстояние до точки пути
        float PointDistance = Vector3.Distance(points[i].position, transform.position);

        //Определяем расстояние до игрока
        float playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance < attackRangeMin)
        {
            GetComponent<AICharacterControl>().target = player;
            GetComponent<NavMeshAgent>().speed = 1;

        } else if (playerDistance > attackRangeMax)
        {
            GetComponent<AICharacterControl>().target = points[i];
            GetComponent<NavMeshAgent>().speed = 0.6f;
        }

        if (PointDistance < 1)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;   
            }
           
            GetComponent<AICharacterControl>().target = points[i];
        }

    }
}
