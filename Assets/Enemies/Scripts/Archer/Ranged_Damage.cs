using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Damage : MonoBehaviour
{
	public float damage;
	private void Awake()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<PlayerStats>().TakeDamage(damage);
			Destroy(this.gameObject);
		}
	}
}