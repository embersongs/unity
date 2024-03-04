using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Поведение ПОКОЯ

public class IdleBehaviour : StateMachineBehaviour
{
    float timer; //счетчик прошедшего времени
    Transform player; //Позиция игрока
    float chaseRange = 10; //Диапазон погони

    //При в ходе в состояние
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Обнуляем счетчик времени и находим игрока сохраняя его в player
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //При активном состоянии делаем:
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Рассчитываем пройденное время
        timer += Time.deltaTime;

        //Если время больше 5 секунд включаем состояние патрулирования
        if (timer > 5)
            animator.SetBool("isPatrolling", true);

        //Определяем расстояние до игрока
        float distance = Vector3.Distance(animator.transform.position, player.position);

        //Если игрок приблизился на расстояние погони, включаем состояние погоня
        if (distance < chaseRange)
            animator.SetBool("isChasing", true);

    }

  
}
