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
	public AudioSource aS;
	public List<VideoClip> videoClips = new List<VideoClip>();
	public List<AudioClip> audioClips = new List<AudioClip>();
	public Animation textAnim;

	bool canSkip;
	public bool useVideoNumber;
	void Start()
	{
		videoPlayer = GetComponent<VideoPlayer>();
		aS = GetComponent<AudioSource>();

		if (useVideoNumber)
		{
			VideoClip playThisFromList;
			AudioClip playThisFromAudio;
			playThisFromAudio = audioClips[videoNumber];
			playThisFromList = videoClips[videoNumber];
			videoPlayer.clip = playThisFromList;
			aS.clip = playThisFromAudio;
			aS.Play();
			cutsceneLength = (float)videoPlayer.length;

		}
		cutsceneLength = (float)videoPlayer.length;

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
