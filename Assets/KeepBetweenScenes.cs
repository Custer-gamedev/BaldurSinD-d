using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepBetweenScenes : MonoBehaviour
{
	private void Awake()
	{
		DontDestroyOnLoad(this);
	}
	private void Update()
	{
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "MainMenu" || scene.name == "DeathScreen" || scene.name == "FloorThree")
		{
			print("ayaya");
			MUS_Controller.volume = 0;
			Destroy(this.gameObject);
		}
	}
}
