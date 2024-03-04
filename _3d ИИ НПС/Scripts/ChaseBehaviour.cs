using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Поведение ПОГОНЯ

public class ChaseBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent; //Компонент NavMeshAgent отвечающий за движение
    Transform player;  //Положение игрока
    float attackRange = 2; //диапазон атаки
    float chaseRange = 10; //диапазон погони

    //При входе в состояние
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Получаем доступ к компоненту NavMeshAgent
        agent = animator.GetComponent<NavMeshAgent>();
        //И устаенавливаем ему скорость
        agent.speed = 4;

        //Находим на сцене игрока и сохраняем в player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //При активном состоянии делаем:
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Устанавливаем точку движения в точке игрока
        agent.SetDestination(player.position);

        //Определяем расстояние до игрока
        float distance = Vector3.Distance(animator.transform.position, player.position);
        
        
        //При приближении на дистанцию атаки переключаем в состояние атака
        if (distance < attackRange)
            animator.SetBool("isAttacking", true);

        //При выходе из зоны погони, выключаем состояние погоня
        if (distance > 10)
            animator.SetBool("isChasing", false);
    }

    //при выходе из состояния
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Устанавливаем точку цели в самого себя
        agent.SetDestination(agent.transform.position);
        //Возвращаем исходную скорость
        agent.speed = 2;
    }
}
