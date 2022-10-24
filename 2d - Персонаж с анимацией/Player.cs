using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//создаем переменные для скорости и высоты прыжка
	public float Speed = 10;
	public float Jump = 5;

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
	
		//управляем скоростью физического тела по оси х умножив управл¤ющее значение на скорость, ось y без изменений
		rb.velocity = new Vector2(moveHorizontal * Speed, rb.velocity.y);


	}

	//Действия в Update выполняются каждый кадр, тут считываем нажатия клавишь
    private void Update()
    {

		//Если нажата клавиша прыжка добавляем силу вверх transform.up в виде импульса персонажу чтобы он подпрыгнул
		if (Input.GetButtonDown("Jump"))
		{
			rb.AddForce(transform.up * Jump, ForceMode2D.Impulse);
		}

		//Включаем-выключаем анимации бега isRun, если персонаж начинает двигаться
		if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.001f)
        {
			GetComponent<Animator>().SetBool("isRun", true);
        } else
        {
			GetComponent<Animator>().SetBool("isRun", false);
		}

		//Разворачиваем персонажа управляя компонентом SpriteRenderer и значением flipX проверяя направление движения
		if (Input.GetAxis("Horizontal") < 0) GetComponent<SpriteRenderer>().flipX = true;
		if (Input.GetAxis("Horizontal") > 0) GetComponent<SpriteRenderer>().flipX = false;

	}

}
