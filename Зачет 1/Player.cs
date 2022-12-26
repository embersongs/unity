using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//создаем переменные для скорости и высоты прыжка
	public float Speed = 10;


	private Rigidbody2D rb; //в переменной rb храним компонет физическое тело, чтобы управлять им по кнопкам
    private void Start()
    {
		//при старте игры считываем в переменную компонент физическое тело
		rb = GetComponent<Rigidbody2D>(); 
    }

	//Действия в FixedUpdate не завис¤т от фпс игры, тут делаем все физические манипуляции с объектом
	private void FixedUpdate()
	{
		//в переменную moveHorizontal считываем управление с клавиатуры, будет значение от -1 до 1 и 0 в покое
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		//управляем скоростью физического тела по оси х умножив управл¤ющее значение на скорость, ось y без изменений
		rb.velocity = new Vector2(moveHorizontal * Speed, moveVertical * Speed);


	}

	//Действия в Update выполняются каждый кадр, тут считываем нажатия клавишь
    private void Update()
    {


	}

}
