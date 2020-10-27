using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public Button startLevel, quitLevel;
	private void Awake()
	{
		startLevel.onClick.AddListener(StartLevel);
		quitLevel.onClick.AddListener(QuitLevel);

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

}
