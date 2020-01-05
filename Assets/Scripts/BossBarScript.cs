using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBarScript : MonoBehaviour
{
	private Image healthBar;
	private Boss boss;
	private float maxHealth;
	public static float health;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
		healthBar = GetComponent<Image>();
		maxHealth = boss.maxHealth;
		health = maxHealth;
    }
	
	void Update()
	{
		healthBar.fillAmount = health/maxHealth;
	}
}
