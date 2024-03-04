using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Поведение АТАКА

public class AttackBehaviour : StateMachineBehaviour
{
    //Положение игрока
    Transform player;
    

    //При входе в состояние
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Находим по тегу объект игрока на сцене и сохраняем его в player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //При активном состоянии работаем
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Поворачиваемся в сторону игрока
        animator.transform.LookAt(player);

        //Рассчитываем расстояние до игрока
        float distance = Vector3.Distance(animator.transform.position, player.position);

        //Если игрок отошел, выключаем состояние атаки
        if (distance > 3)
            animator.SetBool("isAttacking", false);

        //Если игрок удалился очень далеко, вючключаем состояние погони
        if (distance > 15)
            animator.SetBool("isChasing", false);
    }


}
