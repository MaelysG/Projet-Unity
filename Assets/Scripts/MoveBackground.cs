using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
	private Rigidbody2D rgBody;
	private float speed = -1.5f;
	private float positionRestartY;
	
	private Vector3 siz;
	
	private Vector3 leftBottomCameraBorder;
	
	
    // Start is called before the first frame update
    void Start()
    {
		rgBody = GetComponent<Rigidbody2D>();
		rgBody.velocity = new Vector2(0, speed);
    
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));		
		positionRestartY = 20.4F;
    }

    // Update is called once per frame
    void Update()
    {
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		if (transform.position.y < leftBottomCameraBorder.y - (siz.y / 2))
		{
		transform.position = new Vector3(transform.position.x,positionRestartY,transform.position.z);
		}
	}
}
