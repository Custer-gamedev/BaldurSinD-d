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

	private bool canAttack;
	public STATES state;
	public Transform player;
	public float projectileSpeed, moveSpeed, chaseSize;
	public LayerMask playerMask;
	private NavMeshAgent navM;
	public GameObject rock;
	private void Start()
	{
		navM = GetComponent<NavMeshAgent>();
	}
	void Update()
	{
		switch (state)
		{
			case STATES.Chase:
				ChaseAttack();
				break;
			case STATES.ThrowAttack:
				Invoke("ThrowAttack", 1);
				break;
			case STATES.Idle:
				break;
			case STATES.SpinAttack:
				break;

		}

	}

	void SpinAttack()
	{
		transform.Rotate(new Vector3(30, 0, 0) * Time.deltaTime);
	}

	void ChaseAttack()
	{
		navM.SetDestination(player.transform.position);
		if (Physics.CheckSphere(transform.position, chaseSize, playerMask))
		{
			//camerashake
			//slam
		}
	}
	void ThrowAttack()
	{
		GameObject projectile = Instantiate(rock, transform.position, transform.rotation);
		projectile.GetComponent<Rigidbody>().AddForce(player.transform.position * projectileSpeed * Time.deltaTime, ForceMode.Impulse);
	}
	void Idle()
	{
		//go to middle of room and idle
	}
	public IEnumerator ChangeState()
	{
		while (canAttack == true)
		{
			state = STATES.Chase;
			yield return new WaitForSeconds(5f);
			state = STATES.Idle;
			yield return new WaitForSeconds(2f);
			state = STATES.ThrowAttack;
			yield return new WaitForSeconds(3f);
			state = STATES.SpinAttack;
			yield return new WaitForSeconds(3.5f);
			state = STATES.Idle;
			yield return new WaitForSeconds(6f);

		}

		yield return null;
	}
}

