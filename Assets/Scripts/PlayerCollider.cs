using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
	private Player player;
	
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Boss")){
			player.Damage(1);
			GetComponent<CircleCollider2D> ().enabled = false;
			StartCoroutine(EnableBox(1.0F));
		}	
		if(col.CompareTag("Bullet1")){
			player.Damage(1);
			GetComponent<CircleCollider2D> ().enabled = false;
			StartCoroutine(EnableBox(1.0F));
		}	
		if(col.CompareTag("Bullet2")){
			player.Damage(1);
			GetComponent<CircleCollider2D> ().enabled = false;
			StartCoroutine(EnableBox(1.0F));
		}	
		if(col.CompareTag("Bullet3")){
			player.Damage(1);
			GetComponent<CircleCollider2D> ().enabled = false;
			StartCoroutine(EnableBox(1.0F));
		}	
		if(col.CompareTag("Bullet4")){
			player.Damage(1);
			GetComponent<CircleCollider2D> ().enabled = false;
			StartCoroutine(EnableBox(1.0F));
		}	
		if(col.CompareTag("Bullet5")){
			player.Damage(1);
			GetComponent<CircleCollider2D> ().enabled = false;
			StartCoroutine(EnableBox(1.0F));
		}	
		if(col.CompareTag("Bullet6")){
			player.Damage(1);
			GetComponent<CircleCollider2D> ().enabled = false;
			StartCoroutine(EnableBox(1.0F));
		}
		if(col.CompareTag("PV_Bonus")){
			player.Life(1);
		}
	}
	
	IEnumerator EnableBox(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        GetComponent<CircleCollider2D> ().enabled = true;
    }
}
