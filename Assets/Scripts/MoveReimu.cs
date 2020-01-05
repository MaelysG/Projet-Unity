using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveReimu : MonoBehaviour
{
	public float speed = 5;
	private Vector2 movement;
	private Vector3 touchPosition;
	private Vector3 direction;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {		
		if(Input.touchCount>0){
			
			Touch touch = Input.GetTouch(0);
			touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
			touchPosition.z =0;
			direction = (touchPosition - transform.position);
			movement = new Vector2(direction.x,direction.y);
			GetComponent<Rigidbody2D>().velocity = speed*movement;
			
			if(touch.phase == TouchPhase.Ended)
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			
		}else{
			
			float inputY =Input.GetAxis("Vertical");
			float inputX =Input.GetAxis("Horizontal");
			
			movement = new Vector2(inputX,inputY);
			GetComponent<Rigidbody2D>().velocity = speed*movement;
		}
    }
}
