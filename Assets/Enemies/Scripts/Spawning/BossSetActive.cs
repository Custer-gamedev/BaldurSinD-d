using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSetActive : MonoBehaviour
{

	public GameObject boss;
	private EnemiesList eList;
	private void Start()
	{
		eList = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemiesList>();
	}
	private void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Player")
		{
			boss.SetActive(true);
			eList.enemiesAlive.Add(boss);
			Destroy(this);
		}
	}
}
