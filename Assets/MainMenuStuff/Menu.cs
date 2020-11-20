using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public Button startLevel, quitLevel, credits, goback;
	public GameObject creditMenu, mainMenu;
	private void Awake()
	{
		startLevel.onClick.AddListener(StartLevel);
		quitLevel.onClick.AddListener(QuitLevel);
		credits.onClick.AddListener(CreditsMenu);
		goback.onClick.AddListener(MainMenu);
		creditMenu.SetActive(false);

	}
	public void StartLevel()
	{
		SceneManager.LoadScene("FloorOne");
	}

	public void QuitLevel()
	{
		Application.Quit();
		print("Quitting");
	}
	public void CreditsMenu()
	{
		creditMenu.SetActive(true);
		mainMenu.SetActive(false);
	}

	public void MainMenu()
	{
		creditMenu.SetActive(false);
		mainMenu.SetActive(true);
	}

}
