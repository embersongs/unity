using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //подключим библиотеку для загрузки уровней

public class FinishLevel : MonoBehaviour
{
    //Имя сцены со следующим уровнем
    public string nextLevelName = "Level2";

    //Как только столкнулись с другим коллайдером
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Проверим это игрок
        if (collision.CompareTag("Player"))
        {
            //Если да, то загрузим следующий уровень по имени из nextLevelName
            SceneManager.LoadScene(nextLevelName);
        }
    }

}
