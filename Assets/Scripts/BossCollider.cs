using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
	private Boss boss;
	
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("PlayerSimpleShot")){
			boss.Damage(1);
		}
		if(col.CompareTag("PlayerShot")){
			boss.Damage(2);
		}
	}
}
