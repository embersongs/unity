//Подсказки как сделать логику анимации включения-выключения прыжка

//свойство, отвечающее касается ли земли персонаж, bool значит true или false
public bool onGround;

//Как сделать чтобы пометить что персонаж касается земли
onGround = true;

//Как включить анимацию прыжка и выключить анимацию падения
anim.SetBool("isJump", true);
anim.SetBool("isFall", false);

//Как проверить не на земле ли персонаж, т.е. в полете
if (!onGround) {

}

//Как проверить что персонаж движется вверх
if (rb.velocity.y > 0) {

}

//Как проверить что персонаж движется вниз
if (rb.velocity.y < 0) {

}