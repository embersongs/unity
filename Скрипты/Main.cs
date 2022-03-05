using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //обявляем поля для связи с объектами-едой
    public GameObject hotdog;
    public GameObject cheese;

    void Start()
    {
        
    }


    void Update()
    {
        //по нажатию ЛКМ поедаем
        if (Input.GetButton("Fire1"))
        {
            hotdog.SetActive(false);
            cheese.SetActive(false);
        }
    }

    //функция вызывается когда наступили на еду, а в foodName будет имя еды
    public void getFood(string foodName)
    {
        //подбираем хотдог
        if (foodName == "hotdog")
        {
            hotdog.SetActive(true);
            cheese.SetActive(false);
        }

        //подбираем сыр
        if (foodName == "cheese")
        {
            hotdog.SetActive(false);
            cheese.SetActive(true);
        }
    }

}
