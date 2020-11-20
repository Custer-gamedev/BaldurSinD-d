using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
	public float hp, damage;
	public GameObject soul, nextFloor;
	public bool isThisBoss, useSouls;
	public bool Souls()
	{
		int rand = Random.Range(0, 4);
		if (rand == 1)
			return true;
		else
			return false;
	}

	Color thisColor;
	private EnemiesList enemiesList;
	void Awake()
	{
		enemiesList = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemiesList>();
		PlayerStats p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	}
	void Update()
	{
		PlayerStats p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

		if (hp <= 0)
		{
			p.Heal(.5f);
			if (Souls() == true && useSouls == true)
			{
				Instantiate(soul, transform.position, transform.rotation);
			}

			Destroy(gameObject);
			enemiesList.enemiesAlive.Remove(this.gameObject);

			if (isThisBoss == true)
			{
				nextFloor.SetActive(true);
				p.GetBossKills(1);
			}
			else
				p.GetNormalKills(1);

		}
	}
	void OnTriggerEnter(Collider other)
	{
		PlayerStats p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

		switch (other.tag)
		{
			case "ATCK":
				StartCoroutine(TakeDamage(p.damage));
				print(p.damage);
				break;
			case "ATCK2":
				StartCoroutine(TakeDamage(p.damage));
				print(p.damage / 2);
				break;
			case "ATCK3":

				break;
		}
	}
	public IEnumerator TakeDamage(float amount)
	{
		hp -= amount;
		if (!isThisBoss)
			//GetComponent<Rigidbody>().AddForce(-transform.forward * 1f, ForceMode.Impulse);

			yield return new WaitForSeconds(1f);
		//GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
}