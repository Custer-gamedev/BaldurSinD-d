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
	public Transform player;
	public Animator jotneAnim;
	public float projectileSpeed, chaseSize, spinningSpeed, damageSize;
	public LayerMask playerMask;
	private NavMeshAgent navM;
	public GameObject rock;
	float shootWait, stompWait;
	float coolDownTime = 2;
	float stompCoolDown = 3f;
	private void Start()
	{
		navM = GetComponent<NavMeshAgent>();
		jotneAnim = GetComponent<Animator>();
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
		//spin animasjon
		transform.Rotate(new Vector3(0, 10, 0) * spinningSpeed * Time.deltaTime);
		navM.SetDestination(player.transform.position);
		navM.speed = .5f;
	}

	void ChaseAttack()
	{
		//run animasjon
		navM.SetDestination(player.transform.position);
		navM.speed = 4f;
		if (Physics.CheckSphere(transform.position, chaseSize, playerMask))
		{
			//slam animasjon
			navM.isStopped = true;
			if (stompWait <= 0)
			{
				print("player took damage");

				stompWait = stompCoolDown;

			}
			else
				stompWait -= Time.deltaTime;

		}
		else
			navM.isStopped = false;
	}
	public void ThrowAttack()
	{
		//pickup and throw animasjon
		navM.isStopped = true;
		if (shootWait <= 0)
		{
			GameObject projectile = Instantiate(rock, transform.position, transform.rotation);
			projectile.GetComponent<Rigidbody>().AddForce(player.transform.position * projectileSpeed * Time.deltaTime, ForceMode.Impulse);
			Destroy(projectile, 3f);
			shootWait = coolDownTime;
		}

	}
	void Idle()
	{
		//kneel animasjon
		navM.isStopped = true;
	}
	public IEnumerator ChangeState()
	{
		while (canAttack == true)
		{
			state = STATES.Chase;
			yield return new WaitForSeconds(10f);
			state = STATES.Idle;
			yield return new WaitForSeconds(2f);
			shootWait = coolDownTime;
			state = STATES.ThrowAttack;
			yield return new WaitForSeconds(3f);
			state = STATES.SpinAttack;
			yield return new WaitForSeconds(6f);
			state = STATES.Idle;
			yield return new WaitForSeconds(6f);

		}

		yield return null;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, chaseSize);
		Gizmos.DrawWireSphere(transform.position, damageSize);
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Player")
		{
			player.GetComponent<PlayerStats>().TakeDamage(1);
		}
	}
}

