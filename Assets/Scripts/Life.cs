using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
	public Sprite[] Hearts;
	[SerializeField]
	private Image HeartsUI;
	private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
    // Update is called once per frame
    void Update()
    {
		if(player.currentHealth>-1){
			HeartsUI.sprite = Hearts[player.currentHealth];
		}
    }
}
