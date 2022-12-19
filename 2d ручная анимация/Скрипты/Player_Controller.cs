using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
	
	public float speed=10;

	private float moveX;
	private float moveY;
	private Rigidbody2D rb;
	private bool facingRight = false;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveX = Input.GetAxis("Horizontal");
		moveY = Input.GetAxis("Vertical");
		rb.velocity = new Vector2(moveX * speed, moveY * speed);

		anim.SetFloat("speed", Mathf.Abs(moveX + moveY));
		
		if (facingRight == false && moveX > 0)
		{
			Flip();
		} else if (facingRight == true && moveX < 0) {
			Flip();
		}
	}
	
	void Flip() {
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
