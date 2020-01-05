using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReimu : MonoBehaviour
{
	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private Vector3 siz;
	
    // Start is called before the first frame update
    void Start()
    {
        leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
    }

    // Update is called once per frame
    void Update()
    {
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
        siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		
		if(transform.position.y < leftBottomCameraBorder.y + (siz.y/2))
		{
			gameObject.transform.position=new Vector3(transform.position.x, leftBottomCameraBorder.y+(siz.y/2),transform.position.z);
		}
		if(transform.position.y > leftTopCameraBorder.y - (siz.y/2))
		{
			gameObject.transform.position=new Vector3(transform.position.x, leftTopCameraBorder.y-(siz.y/2),transform.position.z);
		}
		gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x,leftBottomCameraBorder.x, rightBottomCameraBorder.x), transform.position.y, transform.position.z);
		
		
    }
}
