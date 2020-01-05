using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int currentHealth;
	public int maxHealth = 200;
	
	[SerializeField]
	private GameObject bossDiedUI;
	[SerializeField]
	private GameObject gameCompletedUI;
	
	
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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
    }
	
	void Die(){
		string name = SceneManager.GetActiveScene().name;
		if(name != "StageThree")
		{
			bossDiedUI.SetActive(true);
		}else{			
			gameCompletedUI.SetActive(true);
		}
	}
	
	public void Damage(int dmg){
		currentHealth -= dmg;
		BossBarScript.health -= dmg;
	}
}
