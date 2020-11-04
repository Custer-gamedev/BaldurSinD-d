using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
	bool paused;
	public Button resumeGame, quitGame, yes, no;
	public GameObject pausedStuff, areYouSureStuff;
	public GameObject statsStuff;
	void Start()
	{
		resumeGame.onClick.AddListener(Unpause);
		yes.onClick.AddListener(ReturnToMain);
		quitGame.onClick.AddListener(AreYouSure);
		no.onClick.AddListener(No);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && !paused)
			PauseGame();

		else if (Input.GetKeyDown(KeyCode.Escape) && paused)
			Unpause();
	}
	void PauseGame()
	{
		paused = true;
		//Cursor.lockState = CursorLockMode.None;
		//Cursor.visible = true;
		pausedStuff.SetActive(true);
		statsStuff.SetActive(false);
		Time.timeScale = 0;
	}

	void Unpause()
	{
		paused = false;
		//	Cursor.lockState = CursorLockMode.Locked;
		//	Cursor.visible = false;
		pausedStuff.SetActive(false);
		statsStuff.SetActive(true);
		Time.timeScale = 1;
	}

	void AreYouSure()
	{
		areYouSureStuff.SetActive(true);
		pausedStuff.SetActive(false);

	}

	void No()
	{
		areYouSureStuff.SetActive(false);
		pausedStuff.SetActive(true);

	}
	void ReturnToMain()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
		Destroy(this);
	}
}
