using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
	[SerializeField]
	private GameObject menuUI;
	[SerializeField]
	private GameObject selectLevelUI;
	
	public void StartRun()
	{
		SceneManager.LoadScene("StageOne");
	}
	
	public void SelectLevel()
	{
		menuUI.SetActive(false);
		selectLevelUI.SetActive(true);
	}
	
	public void SelectLevelOne()
	{
		SceneManager.LoadScene("StageOne");
	}
	
	public void SelectLevelTwo()
	{
		SceneManager.LoadScene("StageTwo");
	}
	
	public void SelectLevelThree()
	{
		SceneManager.LoadScene("StageThree");
	}
	
	public void Quit()
	{
		Application.Quit();
	}
}
