using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float time = 1; //как часто спавнить, 1 раз в секунду по умолчанию, поле доступно в настройках
    public GameObject obj; //какой объект спавнить, нужно будет перетащить объект для спавна.
    
    void Start()  //Действие при старте игры
    {
        InvokeRepeating("Spawn", //будем делать действие Spawn
            0,                  //через 0 секунд после старта
            time                //С периодичностью заданной в time
            );
    }

    
    void Spawn()            //само действие Spawn
    {
        GameObject newObj = Instantiate( //Создаем объект
            obj,                //берем объект из поля obj
            transform.position,    //создаем объект в положении объекта, в котором будет скрипт спавна
            transform.rotation      //создаем объект с таким же вращением
            );
        newObj.SetActive(true);     //делаем созданный объект видимым
    }
}
