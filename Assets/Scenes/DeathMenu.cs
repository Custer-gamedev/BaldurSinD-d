using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
	public Button quitButton;
	public Button mainMenu;

	private void Start()
	{
		quitButton.onClick.AddListener(Quitting);
		mainMenu.onClick.AddListener(MainMenu);
	}

	void Quitting()
	{
		Application.Quit();
	}

	void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
