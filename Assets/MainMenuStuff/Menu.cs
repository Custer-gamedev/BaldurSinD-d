using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public Button startLevel, quitLevel, credits, goback, goBackAgain, cBaldurIntro, cBaldurDeath, cFrigg, cLoki, cOdin, cHermod, cutsceneMenu;
	public GameObject creditMenu, mainMenu, cutsceneMenus;
	private void Awake()
	{
		startLevel.onClick.AddListener(StartLevel);
		quitLevel.onClick.AddListener(QuitLevel);
		credits.onClick.AddListener(CreditsMenu);
		goback.onClick.AddListener(MainMenu);
		goBackAgain.onClick.AddListener(MainMenu);
		cutsceneMenu.onClick.AddListener(CutsceneMenu);
		creditMenu.SetActive(false);

		cBaldurIntro.onClick.AddListener(BaldurIntro);
		cBaldurDeath.onClick.AddListener(BaldurDeath);
		cFrigg.onClick.AddListener(Frigg);
		cLoki.onClick.AddListener(Loki);
		cOdin.onClick.AddListener(Odin);
		cHermod.onClick.AddListener(Hermod);


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
		cutsceneMenus.SetActive(false);
	}
	public void MainMenu()
	{
		creditMenu.SetActive(false);
		cutsceneMenus.SetActive(false);
		mainMenu.SetActive(true);
	}
	public void CutsceneMenu()
	{
		creditMenu.SetActive(false);
		mainMenu.SetActive(false);
		cutsceneMenus.SetActive(true);
	}
	public void BaldurIntro()
	{
		PreviewCutscenes.videoNumber = 0;
		SceneManager.LoadScene("CutscenesScene");


	}
	public void Frigg()
	{
		PreviewCutscenes.videoNumber = 1;
		SceneManager.LoadScene("CutscenesScene");
	}
	public void Loki()
	{
		PreviewCutscenes.videoNumber = 3;
		SceneManager.LoadScene("CutscenesScene");
	}
	public void BaldurDeath()
	{
		PreviewCutscenes.videoNumber = 5;
		SceneManager.LoadScene("CutscenesScene");
	}
	public void Odin()
	{
		PreviewCutscenes.videoNumber = 4;
		SceneManager.LoadScene("CutscenesScene");
	}
	public void Hermod()
	{
		PreviewCutscenes.videoNumber = 2;
		SceneManager.LoadScene("CutscenesScene");
	}
}
