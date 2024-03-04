using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

//Состояние ПАТРУЛЬ

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;  //Счетчик времени
    List<Transform> points = new List<Transform>(); //Список точек патрулирования
    NavMeshAgent agent; //Компонент NavMeshAgent

    Transform player; //Положение игрока
    float chaseRange = 10; //Диапазон погони

    //При входе в состояние
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Обунляем счетчик времени
        timer = 0;

        //Получаем по тегу Points объект содержащий точки патрулирования
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;

        //Проходим циклом по всем объектам и добавляем их координаты в список точек патрулирования
        foreach (Transform t in pointsObject)
            points.Add(t);

        //Получаем доступ к компоненту NavMeshAgent
        agent = animator.GetComponent<NavMeshAgent>();

        //Устанавливаем первую точку патрулирования
        agent.SetDestination(points[0].position);

        //находим игрока на сцене и сохраняем его в player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //При активном состоянии делаем
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Если персонаж достиг точки назначения
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            //Берем из списка следующую случайную точку назначения
            agent.SetDestination(points[Random.Range(0, points.Count)].position);
        }
           

        //Увеличиваем время
        timer += Time.deltaTime;

        //Если прошло 10 секунд, останавливаем состояние патрулирования (переход в покой 5 секунд)
        if (timer > 10)
        {
            animator.SetBool("isPatrolling", false);
        }
            

        //Определяем расстояние до игрока
        float distance = Vector3.Distance(animator.transform.position, player.position);

        //При достижении дистанции погони, включаем состояние погони
        if (distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
            

    }

    //При выходе из состояния, возвращаем точку цели в самого себя
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
