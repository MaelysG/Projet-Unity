using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleted : MonoBehaviour
{
	public GameManager gameManager;
	
	void Start()
	{
		gameManager.Win();
	}
	
	public void Menu()
	{
		SceneManager.LoadScene("MainMenu");
	}
	
	public void Suite()
	{
		string name = SceneManager.GetActiveScene().name;
		if(name == "StageOne")
		{
			SceneManager.LoadScene("StageTwo");
		}
		if(name == "StageTwo")
		{
			SceneManager.LoadScene("StageThree");
		}
	}
	
    public void Quit()
	{
		Application.Quit();
	}
}
