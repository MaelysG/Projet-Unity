using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MokouShots : MonoBehaviour
{
    public GameObject MokouShot1;
	public GameObject MokouShot2;
	public GameObject MokouShot3;
	public GameObject MokouShot4;
	public GameObject MokouShot5;
	public GameObject MokouShot6;
	
	public Transform BulletSpawn;
	private Boss Mokou;
	private Transform Rotation;
	private Transform Rotation2;
	private Transform Rotation3;
	private Transform Rotation4;
	private Transform Rotation5;
	private Transform Rotation6;
	private float fireRate;
	private float nextFire;
	
	private int nbtir;
	private bool direction; //true = vers la droite, false = vers la gauche
	
    // Start is called before the first frame update
    void Start()
    {
        Rotation = new GameObject().transform;
        Rotation2 = new GameObject().transform;
        Rotation3 = new GameObject().transform;
        Rotation4 = new GameObject().transform;
        Rotation5 = new GameObject().transform;
        Rotation6 = new GameObject().transform;
        Mokou = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
		fireRate = 0.5F;
		nbtir = 2;
		direction = true;
    }

    // Update is called once per frame
    void Update()
    {
		if(nbtir==0){
			direction = true;
		}
		if(nbtir==4){
			direction = false;
		}
		
		if(150>Mokou.currentHealth && Mokou.currentHealth>=100)
		{
			fireRate = 0.20F;
		}
		if(100>Mokou.currentHealth && Mokou.currentHealth>=50)
		{
			fireRate = 0.2F;
		}
		if(50>Mokou.currentHealth && Mokou.currentHealth>0)
		{
			fireRate = 0.1F;
		}
			
        if(Time.time > nextFire){
			nextFire = Time.time + fireRate;
			if(Mokou.currentHealth>=150)
			{
				Ondulations(MokouShot2);
			}
			if(150>Mokou.currentHealth && Mokou.currentHealth>=100)
			{
				TirVise(MokouShot5);
			}
			if(100>Mokou.currentHealth && Mokou.currentHealth>=50)
			{
				SpiraleMultiple(MokouShot6, 10);
				SpiraleMultiple(MokouShot1, 5);
			}
			if(Mokou.currentHealth<50)
			{
				CercleTournant(0, 10, MokouShot4, Rotation);
				CercleTournant(0, 4, MokouShot3, Rotation2);
				Rotation.Rotate(new Vector3(0,0,-10));
				Rotation2.Rotate(new Vector3(0,0,-20));
			}
		}
    }
	
	void CercleTournant(float angle, float nbBullets, GameObject ShotStyle, Transform Rotation)
	{
		var newTrans = new GameObject().transform;
		newTrans.rotation = Rotation.rotation;
		float angleStep = 360f / nbBullets;
		float radius = 5f;
		
		for (int i=0; i<=nbBullets; i++) {
			
			float bulletDirXposition = BulletSpawn.position.x + Mathf.Sin ((angle * Mathf.PI) / 180) * radius;
			float bulletDirYposition = BulletSpawn.position.y + Mathf.Cos ((angle * Mathf.PI) / 180) * radius;

			Vector3 projectileVector = new Vector3(bulletDirXposition, bulletDirYposition,0);
			Vector3 projectileMoveDirection = (projectileVector - BulletSpawn.position).normalized * 5;

			var bullet = Instantiate (ShotStyle, BulletSpawn.position, newTrans.rotation);
			bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (projectileMoveDirection.x, projectileMoveDirection.y);
			angle += angleStep;
			newTrans.Rotate(new Vector3(0,0,angle));
		}
	}
	
	void TirVise(GameObject ShotStyle)
	{
		Instantiate(ShotStyle, transform.position, Quaternion.identity);
	}
	
	void SpiraleMultiple(GameObject ShotStyle, int rotation)
	{
		Instantiate(ShotStyle, BulletSpawn.position, Rotation.rotation);
		Rotation.Rotate(new Vector3(0,0,-rotation+180));
		Instantiate(ShotStyle, BulletSpawn.position, Rotation.rotation);
		Rotation.Rotate(new Vector3(0,0,-rotation+90));
		Instantiate(ShotStyle, BulletSpawn.position, Rotation.rotation);
		Rotation.Rotate(new Vector3(0,0,-rotation+45));
	} 
	
	void Ondulations(GameObject ShotStyle){
		
        Rotation = new GameObject().transform;
		if(direction==true)
		{
			if(Rotation3.rotation != Rotation.rotation && Rotation4.rotation != Rotation.rotation && Rotation5.rotation != Rotation.rotation && Rotation6.rotation != Rotation.rotation)
			{
				Instantiate(ShotStyle, BulletSpawn.position, Rotation3.rotation);
				Rotation3.Rotate(new Vector3(0,0,2));	
				Instantiate(ShotStyle, BulletSpawn.position, Rotation4.rotation);
				Rotation4.Rotate(new Vector3(0,0,4));	
				Instantiate(ShotStyle, BulletSpawn.position, Rotation5.rotation);
				Rotation5.Rotate(new Vector3(0,0,6));	
				Instantiate(ShotStyle, BulletSpawn.position, Rotation6.rotation);
				Rotation6.Rotate(new Vector3(0,0,8));	
				nbtir++;
			}else{
				Instantiate(ShotStyle, BulletSpawn.position, Rotation3.rotation);
				Rotation3.Rotate(new Vector3(0,0,2));	
				Rotation4.Rotate(new Vector3(0,0,4));	
				Rotation5.Rotate(new Vector3(0,0,6));	
				Rotation6.Rotate(new Vector3(0,0,8));	
				nbtir++;
			}				
		}
		if(direction==false)
		{
			if(Rotation3.rotation != Rotation.rotation && Rotation4.rotation != Rotation.rotation && Rotation5.rotation != Rotation.rotation && Rotation6.rotation != Rotation.rotation)
			{
				Instantiate(ShotStyle, BulletSpawn.position, Rotation3.rotation);
				Rotation3.Rotate(new Vector3(0,0,-2));	
				Instantiate(ShotStyle, BulletSpawn.position, Rotation4.rotation);
				Rotation4.Rotate(new Vector3(0,0,-4));	
				Instantiate(ShotStyle, BulletSpawn.position, Rotation5.rotation);
				Rotation5.Rotate(new Vector3(0,0,-6));	
				Instantiate(ShotStyle, BulletSpawn.position, Rotation6.rotation);
				Rotation6.Rotate(new Vector3(0,0,-8));	
				nbtir--;
			}else{
				Instantiate(ShotStyle, BulletSpawn.position, Rotation3.rotation);
				Rotation3.Rotate(new Vector3(0,0,-2));	
				Rotation4.Rotate(new Vector3(0,0,-4));	
				Rotation5.Rotate(new Vector3(0,0,-6));	
				Rotation6.Rotate(new Vector3(0,0,-8));	
				nbtir--;
			}			
			
		}
	}
}
