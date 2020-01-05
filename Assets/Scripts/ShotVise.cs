using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotVise : MonoBehaviour
{
	private Player player;
	private Vector2 direction;
	
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
		
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		direction = (player.transform.position - transform.position).normalized * speed;
		GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y);
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
