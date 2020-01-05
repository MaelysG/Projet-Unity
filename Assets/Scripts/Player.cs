using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public int currentHealth;
	public int maxHealth = 6;
	public GameObject SimpleShot;
	public GameObject Shot;
	
	public Transform BulletSpawn;
	private Transform Rotation;
	private Transform Rotation2;
	private Transform Rotation3;
	private float fireRate;
	private float nextFire;
	
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
		Rotation = new GameObject().transform;
		Rotation2 = new GameObject().transform;
		Rotation3 = new GameObject().transform;
		Rotation2.Rotate(new Vector3(0,0,10));
		Rotation3.Rotate(new Vector3(0,0,-10));
		fireRate = 0.25F;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth>maxHealth){
			currentHealth=maxHealth;
		}
		
		if(currentHealth<=0){
			Die();
		}
		
		if(Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Instantiate(Shot, BulletSpawn.position, Rotation.rotation);
			Instantiate(SimpleShot, BulletSpawn.position, Rotation3.rotation);
			Instantiate(SimpleShot, BulletSpawn.position, Rotation2.rotation);
		}
    }
	
	public void Die(){
		FindObjectOfType<GameManager>().EndGame();
	}
	
	public void Damage(int dmg){
			currentHealth -= dmg;
	}
	public void Life(int life){
		if(currentHealth<maxHealth)
		{
			currentHealth += life;
		}
	}
}
