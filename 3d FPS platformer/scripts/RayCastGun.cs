using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Делаем компонент-линия обязательным для этого скрипта
[RequireComponent(typeof(LineRenderer))]

public class RayCastGun : MonoBehaviour
{
    //Создаем переменные-объекты для камеры, лазера, дальности лазера, и эффекта попадания
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public GameObject flare;

    //Промежуточная переменная, хранит в себе линию
    private LineRenderer laserLine;
   

    void Awake()
    {
        //При старте выключаем эффект попадания и инициализируем переменную линию
        flare.SetActive(false);
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
 
        //Устанавливаем начальную точку луча
        laserLine.SetPosition(0, laserOrigin.position);

        //Определяем направление луча, чтобы смотрели точно в центр экрана
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
        
        //Рассчитываем точку попадания луча
        RaycastHit hit;
        //hit будет точка, в которую попадет луч
        //Physics.Raycast рассчитает луч в направлении взора камеры в центр экрана
        if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
        {
            //Включим эффект попадания
            flare.SetActive(true);

            //Установим конечную точку луча как точку, куда попадет "взор"
            laserLine.SetPosition(1, hit.point);

            //Переместим эффект попадания в конечную точку луча
            flare.transform.position = hit.point;
            // Destroy(hit.transform.gameObject); можно удалить цель
        }
        else
        {
            //Если луч никуда не попал или цель за дальностью 50 то выключаем эффект попадания 
            //и устанавливаем конечную точку в направлении луча на расстоянии gunRange
            flare.SetActive(false);
            laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
        }

    }

}