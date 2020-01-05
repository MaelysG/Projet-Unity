using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaguyaShots : MonoBehaviour
{
    public GameObject KaguyaShot1;
	public GameObject KaguyaShot2;
	public GameObject KaguyaShot3;
	public GameObject KaguyaShot4;
	public GameObject KaguyaShot5;
	public GameObject KaguyaShot6;
	
	public Transform BulletSpawn;
	private Boss Kaguya;
	private Transform Rotation;
	private Transform Rotation2;
	private Transform Rotation3;
	private Transform Rotation4;
	private float fireRate;
	private float nextFire;
	private float fireRate2;
	private float nextFire2;
	
	private int nbtir;
	private bool direction; //true = vers la droite, false = vers la gauche
	
    // Start is called before the first frame update
    void Start()
    {
        Rotation = new GameObject().transform;
        Rotation2 = new GameObject().transform;
        Rotation3 = new GameObject().transform;
        Rotation4 = new GameObject().transform;
        Kaguya = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
		fireRate = 1.5F;
		fireRate2 = 3F;
		nbtir = 20;
		direction = true;
    }

    // Update is called once per frame
    void Update()
    {
		if(nbtir==0){
			direction = true;
		}
		if(nbtir==40){
			direction = false;
		}
		
		if(150>Kaguya.currentHealth && Kaguya.currentHealth>=100)
		{
			fireRate = 0.5F;
		}
		if(100>Kaguya.currentHealth && Kaguya.currentHealth>=50)
		{
			fireRate = 2F;
		}
		if(50>Kaguya.currentHealth && Kaguya.currentHealth>0)
		{
			fireRate = 0.1F;
		}
			
        if(Time.time > nextFire){
			nextFire = Time.time + fireRate;
			if(Kaguya.currentHealth>=150)
			{
				Arc(KaguyaShot5, 4, 10);
			}
			if(150>Kaguya.currentHealth && Kaguya.currentHealth>=100)
			{
				CercleTournant(0, 16, KaguyaShot3, Rotation);
				Rotation.Rotate(new Vector3(0,0,-5));
			}
			if(100>Kaguya.currentHealth && Kaguya.currentHealth>=50)
			{
				Cercle(0, 16, KaguyaShot6);
			}
			if(Kaguya.currentHealth<50)
			{
				SpiraleMultiple(KaguyaShot2,-5);
			}
		}
		if(Time.time > nextFire2){
			nextFire2 = Time.time + fireRate2;
			if(Kaguya.currentHealth>=150)
			{				
				Arc(KaguyaShot1, 5, 5);
			}
		}
    }
	
	void Arc(GameObject ShotStyle, int nbBullets, int espacement)
	{
		var newTrans1 = new GameObject().transform;
		var newTrans2 = new GameObject().transform;

		for (int i=0; i<=nbBullets; i++) {
			var bullet1 = Instantiate (ShotStyle, BulletSpawn.position, newTrans1.rotation);
			var bullet2 = Instantiate (ShotStyle, BulletSpawn.position, newTrans2.rotation);
			newTrans1.Rotate(new Vector3(0,0,espacement));
			newTrans2.Rotate(new Vector3(0,0,-espacement));
		}
	}
	
	void Cercle(float angle, float nbBullets, GameObject ShotStyle)
	{
		var newTrans = new GameObject().transform;
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
		if(direction==true)
		{
			Instantiate(ShotStyle, BulletSpawn.position, Rotation3.rotation);
			Rotation3.Rotate(new Vector3(0,0,2));	
			Instantiate(ShotStyle, BulletSpawn.position, Rotation4.rotation);
			Rotation4.Rotate(new Vector3(0,0,-2));	
			nbtir+=2;					
		}
		if(direction==false)
		{
			Instantiate(ShotStyle, BulletSpawn.position, Rotation3.rotation);
			Rotation3.Rotate(new Vector3(0,0,-2));	
			Instantiate(ShotStyle, BulletSpawn.position, Rotation4.rotation);
			Rotation4.Rotate(new Vector3(0,0,2));	
			nbtir-=2;
		}
	}
}
