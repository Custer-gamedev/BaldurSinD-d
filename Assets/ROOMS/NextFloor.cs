using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFloor : MonoBehaviour
{
	public string floorToLoad;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			SceneManager.LoadScene(floorToLoad);
			other.transform.position = new Vector3(0, .5f, 0);
		}
	}
}
