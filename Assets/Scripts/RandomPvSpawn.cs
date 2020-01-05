using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPvSpawn : MonoBehaviour
{
	public GameObject Pv;
	
	public float SpawnTime;
	public float SpawnDelay;
	
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnDelay);
    }

	public void Spawn(){
		Instantiate(Pv, transform.position, Quaternion.identity);	
	}
}
