using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class generateWorld : MonoBehaviour
{
    //ссылка на объект-земня, для фоновой генерации по пути движения
    public GameObject ground;

    //параметр ширина земли, или через сколько смещения по Х генерировать землю
    public int nextPosGround = 50;

    //текущее положение игрока по х, по достижении nextPosGround обнуляется
    private float playerPosition;

    //координаты положения земли
    public Vector2 startGroundPos;

    //разница положения между новой позицие и старой игрока, при достижении 50 будет в минус
    private float dX;

    //предыдущая поцизия игрока
    private float prevPos;

    void Start()
    {
        //при старте запоминаем положение земли, чтобы сдублировать ее вправо на nextPosGround
        startGroundPos = ground.transform.position;

        //инициализируем предудущую позицию игрока
        prevPos = 0; 
    }

    
    void Update()
    {

        //вычислаем нормированное значение игрока, оно будет всегда меняться от 0 до nextPosGround периодически
        playerPosition = transform.position.x % nextPosGround;

        //вычисляем смещение игрока, будет в минус при переходе с 49.9 в 0.01 (0.01 - 49.9) например
        //в обычном движении будет в плюсе, например (1.21 - 0.9)
        dX = playerPosition - prevPos;

        //как только будет смещение в минус генерируем новую землю
        if (dX < 0)
        {
           //вычисляем новое положение земли
           startGroundPos.x = startGroundPos.x + nextPosGround;

            //генерируем землю в новой позиции с вращением 0
           Instantiate(ground, startGroundPos, Quaternion.Euler(0,0,0));
      
        }

        //запоминаем текущую нормированную позицию игрока как предыдущую
        prevPos = transform.position.x % nextPosGround;
    }
}
