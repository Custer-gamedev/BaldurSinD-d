using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum STATES { SpinAttack, ThrowAttack, Chase, Idle }
public class Jotne : MonoBehaviour
{

	// Abilites
	//Rock Throw (gjør ikke mye damage, men stopper spiller for å kampe)
	//Spinattack (Spinner rundt i sirkel rundt romme)
	//Chase (Jager etter spiller, hvis hun fanger spilleren, så tar han mye damage)
	//En pause mellom attacks, sånn at spiller kan angripe
	// Lite HP, men mye Damage

	private bool canAttack = true;
	public STATES state;
	public Transform spawner;
	public Transform player;
	public Animator jotneAnim;
	public float projectileSpeed, chaseSize, spinningSpeed;
	public LayerMask playerMask;
	private NavMeshAgent navM;
	public GameObject iceTaps;
	float shootWait, stompWait;
	bool spinny;
	float coolDownTime = .1f;
	float stompCoolDown = 3f;
	private void Start()
	{
		navM = GetComponent<NavMeshAgent>();
		spawner = GameObject.FindGameObjectWithTag("IceTapSpawner").transform;
		jotneAnim = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		shootWait = coolDownTime;
		stompWait = coolDownTime;
		StartCoroutine(ChangeState());
	}
	void Update()
	{
		switch (state)
		{
			case STATES.Chase:
				ChaseAttack();
				break;
			case STATES.ThrowAttack:
				ThrowAttack();
				break;
			case STATES.Idle:
				Idle();
				break;
			case STATES.SpinAttack:
				SpinAttack();
				break;
		}
	}

	void SpinAttack()
	{
		jotneAnim.Play("SpinnyBoy");
		transform.Rotate(new Vector3(0, 10, 0) * spinningSpeed * Time.deltaTime);
		navM.SetDestination(player.transform.position);
		navM.speed = 20f;
		spinny = true;
	}

	void ChaseAttack()
	{
		navM.SetDestination(player.transform.position);
		navM.speed = 7f;
		if (Physics.CheckSphere(transform.position, chaseSize, playerMask))
		{
			navM.isStopped = true;
			if (stompWait <= 0)
			{
				jotneAnim.Play("Slam");
				print("player took damage");
				player.GetComponent<PlayerStats>().TakeDamage(1);
				stompWait = stompCoolDown;
			}
			else
			{
				stompWait -= Time.deltaTime;
			}

		}
		else
		{
			jotneAnim.Play("Walk");

			navM.isStopped = false;
		}
	}
	public void ThrowAttack()
	{
		jotneAnim.Play("RockThrow");

		navM.isStopped = true;
		if (shootWait <= 0)
		{
			Vector3 spawnPos = new Vector3(Random.Range(-9f, 9f), 0, Random.Range(-10f, 10f));
			spawnPos = spawner.TransformPoint(spawnPos * .5f);
			Instantiate(iceTaps, spawnPos, transform.rotation);
			/*GameObject projectile = Instantiate(rock, transform.position, transform.rotation);
			projectile.GetComponent<Rigidbody>().AddForce(player.transform.position * projectileSpeed * Time.deltaTime, ForceMode.Impulse);
			Destroy(projectile, 3f);
			shootWait = coolDownTime; */
			shootWait = coolDownTime;
		}
		else
			shootWait -= Time.deltaTime;

	}
	void Idle()
	{
		jotneAnim.Play("Idle");
		navM.isStopped = true;
	}
	public IEnumerator ChangeState()
	{
		while (canAttack == true)
		{
			state = STATES.Chase;
			yield return new WaitForSeconds(9f);
			state = STATES.Idle;
			yield return new WaitForSeconds(7f);
			shootWait = coolDownTime;
			state = STATES.ThrowAttack;
			yield return new WaitForSeconds(4f);
			state = STATES.SpinAttack;
			yield return new WaitForSeconds(7f);
			spinny = false;
			state = STATES.Idle;
			yield return new WaitForSeconds(7f);


		}

		yield return null;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, chaseSize);
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Player")
		{
			player.GetComponent<PlayerStats>().TakeDamage(2);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && spinny == true)
		{
			player.GetComponent<PlayerStats>().TakeDamage(2);

		}
	}
}

