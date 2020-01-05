using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
	[SerializeField]
	private GameObject gameOverUI;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject boss;
	[SerializeField]
	private GameObject pv;
	
	bool gameHasEnded = false;
    public void EndGame()
	{
		if(gameHasEnded == false)
		{
			gameOverUI.SetActive(true);
			player.SetActive(false);
			boss.SetActive(false);
			pv.SetActive(false);
		}
	}
	
	public void Win()
	{
		player.SetActive(false);
		boss.SetActive(false);
		pv.SetActive(false);
	}
	
	public void Restart()
	{
		gameOverUI.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
