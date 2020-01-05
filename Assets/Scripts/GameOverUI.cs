using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
	public GameManager gameManager;
	
	public void Quit()
	{
		Application.Quit();
	}
	
	public void Retry()
	{
		gameManager.Restart();
	}
}
