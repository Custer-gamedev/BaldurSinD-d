using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PreviewCutscenes : MonoBehaviour
{
	public VideoPlayer videoPlayer;
	public float waitTime, cutsceneLength;
	public static int videoNumber;
	public List<VideoClip> videoClips = new List<VideoClip>();
	public Animation textAnim;

	bool canSkip;
	public bool useVideoNumber;
	void Start()
	{
		videoPlayer = GetComponent<VideoPlayer>();

		if (useVideoNumber)
		{
			VideoClip playThisFromList;
			playThisFromList = videoClips[videoNumber];
			videoPlayer.clip = playThisFromList;
			cutsceneLength = (float)videoPlayer.length;


		}

		videoPlayer.Play();
		StartCoroutine(CanSkip());
		StartCoroutine(IsPlaying());
	}

	public IEnumerator CanSkip()
	{
		yield return new WaitForSeconds(waitTime);
		canSkip = true;
		textAnim.Play();
	}

	private void Update()
	{
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
		videoPlayer.Stop();
		SceneManager.LoadScene("MainMenu");
	}

	public IEnumerator IsPlaying()
	{
		yield return new WaitForSeconds(cutsceneLength);
		End();
	}
}
