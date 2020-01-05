using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvMove : MonoBehaviour
{
   public float speed = 10F;
	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;
	
    // Start is called before the first frame update
    void Start()
    {		
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0)); 
		
	
		GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
		float random = Random.Range(leftBottomCameraBorder.x,rightBottomCameraBorder.x);
		gameObject.transform.position=new Vector3(random, leftTopCameraBorder.y ,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
		if(transform.position.x < leftBottomCameraBorder.x || transform.position.x > rightBottomCameraBorder.x || transform.position.y < leftBottomCameraBorder.y || transform.position.y > rightTopCameraBorder.y)
		{
			Destroy(gameObject);
		}		
    }
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			Destroy(gameObject);
		}
	}
}
