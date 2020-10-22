using System.Collections;
using UnityEngine;

public class Souls : MonoBehaviour
{

	private Transform destination;
	private ParticleSystem ps;
	void Awake()
	{
		ps = GetComponent<ParticleSystem>();
		SpawnSoul();
	}

	void SpawnSoul()
	{
		int rand = Random.Range(0, 2);
		print(rand);
		if (rand == 0)
		{
			GameObject bossRoom = GameObject.FindGameObjectWithTag("BossRoom");
			destination = bossRoom.transform;
			var main = ps.main;
			Color bossColor;

			ColorUtility.TryParseHtmlString("#D42F25", out bossColor);
			main.startColor = bossColor;
			Destroy(gameObject, 3f);
		}
		if (rand == 1)
		{
			GameObject treasureRoom = GameObject.FindGameObjectWithTag("TreasureRoom");
			destination = treasureRoom.transform;
			var main = ps.main;
			Color treasureColor;

			ColorUtility.TryParseHtmlString("#FFF400", out treasureColor);
			main.startColor = treasureColor;
			Destroy(gameObject, 3f);
		}
	}
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, destination.transform.position, .3f * Time.deltaTime);

	}
}
