using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CutsceneManager : MonoBehaviour
{

	public VideoPlayer videoPlayer;
	public GameObject[] stuffToEnable;
	public Animation textAnim;
	public float waitTime, cutsceneLength;
	bool canSkip;

	private void Start()
	{
		for (int i = 0; i < stuffToEnable.Length; i++)
		{
			stuffToEnable[i].SetActive(false);
		}
		videoPlayer = GetComponent<VideoPlayer>();
		videoPlayer.Play();
		StartCoroutine(CanSkip());
		StartCoroutine(IsPlaying());
		PlayerMove.allowedToMove = false;
	}

	private void Update()
	{
		if (canSkip == true)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				End();
			}
		}
	}

	public void End()
	{
		for (int i = 0; i < stuffToEnable.Length; i++)
		{
			stuffToEnable[i].SetActive(true);
		}
		PlayerMove.allowedToMove = true;
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
