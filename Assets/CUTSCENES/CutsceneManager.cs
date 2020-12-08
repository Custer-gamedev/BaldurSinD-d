using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class CutsceneManager : MonoBehaviour
{

	public VideoPlayer videoPlayer;
	public List<GameObject> stuffToEnable;
	public Animation textAnim;
	public float waitTime, cutsceneLength;

	private AudioSource audioSource;
	bool canSkip;
	bool floorTwoPlayed, floorThreePlayed;
	private void Awake()
	{
		stuffToEnable.Add(GameObject.Find("GUIcamera"));
		stuffToEnable.Add(GameObject.Find("PlayerCanvas"));
		stuffToEnable.Add(GameObject.Find("ATCK2canvas"));
		stuffToEnable.Add(GameObject.Find("Canvas"));
		videoPlayer = GetComponent<VideoPlayer>();
		videoPlayer.targetCamera = Camera.main;

	}
	private void Start()
	{
		for (int i = 0; i < stuffToEnable.Count; i++)
		{
			stuffToEnable[i].SetActive(false);
		}

		/*audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.playOnAwake = false;
		videoPlayer.Prepare();

		videoPlayer.EnableAudioTrack(0, true);
		videoPlayer.SetTargetAudioSource(0, audioSource);

		audioSource.Play(); */
		videoPlayer.Play();

		StartCoroutine(CanSkip());
		StartCoroutine(IsPlaying());
		PlayerMove.allowedToMove = false;

	}
	private void Update()
	{
		Scene scene = SceneManager.GetActiveScene();

		if (canSkip == true)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				End();
				canSkip = false;
			}
		}
	}

	public void End()
	{
		for (int i = 0; i < stuffToEnable.Count; i++)
		{
			stuffToEnable[i].SetActive(true);
		}
		PlayerMove.allowedToMove = true;
		videoPlayer.Stop();
		Destroy(this.gameObject);
	}

	public IEnumerator CanSkip()
	{
		yield return new WaitForSeconds(waitTime);
		canSkip = true;
		textAnim.Play();
	}
	public IEnumerator IsPlaying()
	{
		yield return new WaitForSeconds(cutsceneLength);
		End();
	}
}
