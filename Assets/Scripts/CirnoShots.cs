using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirnoShots : MonoBehaviour
{
	public GameObject CirnoShot1;
	public GameObject CirnoShot2;
	public GameObject CirnoShot3;
	public GameObject CirnoShot4;
	public GameObject CirnoShot5;
	public GameObject CirnoShot6;
	
	public Transform BulletSpawn;
	private Boss Cirno;
	private Transform Rotation;
	private Transform Rotation2;
	private Transform Rotation3;
	private Transform Rotation4;
	private float fireRate;
	private float nextFire;
	private float fireRate2;
	private float nextFire2;
	
	private int nbtir1;
	private bool direction1; 
	private int nbtir2;
	private bool direction2; //true = vers la droite, false = vers la gauche
	
    // Start is called before the first frame update
    void Start()
    {
        Rotation = new GameObject().transform;
        Rotation2 = new GameObject().transform;
        Rotation3 = new GameObject().transform;
        Rotation4 = new GameObject().transform;
        Cirno = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
		fireRate = 0.5F;
		nbtir1 = 4;
		direction1 = true;
		nbtir2 = 15;
		direction2 = true;
    }

    // Update is called once per frame
    void Update()
    {
		if(nbtir1==0){
			direction1 = true;
		}
		if(nbtir1==8){
			direction1 = false;
		}
		if(nbtir2==0){
			direction2 = true;
		}
		if(nbtir2==30){
			direction2 = false;
		}
		
		if(150>Cirno.currentHealth && Cirno.currentHealth>=100)
		{
			fireRate = 0.05F;
		}
		if(100>Cirno.currentHealth && Cirno.currentHealth>=50)
		{
			fireRate = 0.4F;
			fireRate2 = 0.5F;
		}
		if(50>Cirno.currentHealth && Cirno.currentHealth>0)
		{
			fireRate = 0.25F;
		}
			
        if(Time.time > nextFire){
			nextFire = Time.time + fireRate;
			if(Cirno.currentHealth>=150)
			{
				Ondulations(CirnoShot5, 1);
			}
			if(150>Cirno.currentHealth && Cirno.currentHealth>=100)
			{
				Spirale(CirnoShot1, -5);
			}
			if(100>Cirno.currentHealth && Cirno.currentHealth>=50)
			{
				Cercle(0, 16, CirnoShot2);
			}
			if(Cirno.currentHealth<50)
			{
				for(int i=0; i<4; i++){
					for(int j=0; j<5; j++){
						Instantiate(CirnoShot3, BulletSpawn.position, Rotation.rotation);
						Rotation.Rotate(new Vector3(0,0,5));
						Instantiate(CirnoShot3, BulletSpawn.position, Rotation2.rotation);
						Rotation2.Rotate(new Vector3(0,0,-5));
					}
				}
			}
		}
		if(Time.time > nextFire2){
			nextFire2 = Time.time + fireRate2;
			if(100>Cirno.currentHealth && Cirno.currentHealth>=50)
			{
				Ondulations(CirnoShot6, 2);
			}
		}
    }
	
	void Ondulations(GameObject ShotStyle, int style){
		if(style == 1){
			if(direction1==true)
			{
				Instantiate(ShotStyle, BulletSpawn.position, Rotation3.rotation);
				Rotation3.Rotate(new Vector3(0,0,2));	
				Instantiate(ShotStyle, BulletSpawn.position, Rotation4.rotation);
				Rotation4.Rotate(new Vector3(0,0,-2));	
				nbtir1++;					
			}
			if(direction1==false)
			{
				Instantiate(ShotStyle, BulletSpawn.position, Rotation3.rotation);
				Rotation3.Rotate(new Vector3(0,0,-2));	
				Instantiate(ShotStyle, BulletSpawn.position, Rotation4.rotation);
				Rotation4.Rotate(new Vector3(0,0,2));	
				nbtir1--;
			}
		}
		if(style == 2){
			if(direction2==true)
			{
				Instantiate(ShotStyle, BulletSpawn.position, Rotation3.rotation);
				Rotation3.Rotate(new Vector3(0,0,2));	
				Instantiate(ShotStyle, BulletSpawn.position, Rotation4.rotation);
				Rotation4.Rotate(new Vector3(0,0,-2));	
				nbtir2++;					
			}
			if(direction2==false)
			{
				Instantiate(ShotStyle, BulletSpawn.position, Rotation3.rotation);
				Rotation3.Rotate(new Vector3(0,0,-2));	
				Instantiate(ShotStyle, BulletSpawn.position, Rotation4.rotation);
				Rotation4.Rotate(new Vector3(0,0,2));	
				nbtir2--;
			}
		}
	}
	
	void Spirale(GameObject ShotStyle, int rotation)
	{
		Instantiate(ShotStyle, BulletSpawn.position, Rotation.rotation);
		Rotation.Rotate(new Vector3(0,0,-rotation+180));
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
}
