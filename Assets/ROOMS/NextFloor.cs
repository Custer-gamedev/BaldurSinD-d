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
			other.GetComponent<PlayerStats>().GetFloorCleared(1);
			SceneManager.LoadScene(floorToLoad);
			other.transform.position = new Vector3(0, 1f, 0);
			GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(-8.687653f, 12.36444f, -10.69486f);
		}
	}
}
