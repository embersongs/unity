using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_controller : MonoBehaviour
{


    void Start() {

    }

    // Update is called once per frame
    void Update()
	{
		//rotation
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 0;

		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x -= objectPos.x;
		mousePos.y -= objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
       
 
		Vector3 Scaler = transform.localScale;
		if (angle < 90 && angle > -90) {
			Scaler.y = Mathf.Abs(Scaler.y);
		} else {
			Scaler.y = -Mathf.Abs(Scaler.y);
		}
		transform.localScale = Scaler;

	
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
 
	}
}