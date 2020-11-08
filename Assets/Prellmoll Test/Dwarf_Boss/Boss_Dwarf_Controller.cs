using System.Reflection;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Dwarf_Controller : MonoBehaviour
{
	public NavMeshAgent agent;
	public GameObject dest1, dest2, dest3, dest4, dest5, arrow, muzzle, p2MuzzleL, p2MuzzleR, player;
	bool moving, attacking;
	int destNode, hasMovedCount;
	public float chargeTime, chargeTimeBigAttack, firerate, lastfired;
	public Vector3 currentFacing;
	bool lookAtPlayer;
	Vector3 curPos;


	void Start()
	{
		moving = false;
		attacking = false;
		player = GameObject.FindGameObjectWithTag("Player");
		MovetoNextPoint();
		destNode++;
		Move();
	}
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.P))
		{
			MovetoNextPoint();
			destNode++;
		}
		if (lookAtPlayer == true)
		{
			//print(lookAtPlayer);
			Vector3 lookVector = player.transform.position - transform.position;
			lookVector.y = transform.position.y;
			Quaternion rot = Quaternion.LookRotation(lookVector);
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "M_Node")
		{
			print("Collided");
			StartCoroutine("Chargeattack");
		}
		if (other.gameObject.tag == "M_Node_Centre")
		{

		}
	}
	void MovetoNextPoint()
	{
		switch (destNode)
		{
			case 0:
				BigCharge();
				break;
			case 1:
				agent.SetDestination(dest1.transform.position);
				break;
			case 2:
				agent.SetDestination(dest2.transform.position);
				break;
			case 3:
				agent.SetDestination(dest3.transform.position);
				break;
			case 4:
				agent.SetDestination(dest4.transform.position);
				break;
			case 5:
				agent.SetDestination(dest1.transform.position);
				destNode = 1;
				break;
			default:
				MovetoNextPoint();
				break;
		}
		hasMovedCount++;
	}
	private IEnumerator Chargeattack()
	{
		print("chargingAttack");
		lookAtPlayer = true;
		yield return new WaitForSeconds(chargeTime);
		Attack();
		if (hasMovedCount < 4)
		{

			var lastPos = destNode;
			destNode = Random.Range(1, 5);
			if (destNode == lastPos)
			{
				print("Lastpos" + lastPos + " Destnode " + destNode);
				destNode = Random.Range(1, 5);
			}
			MovetoNextPoint();
		}
		if (hasMovedCount > 4)
		{
			print("BigAttackTime");
			agent.SetDestination(dest5.transform.position);
		}

	}
	private IEnumerator BigCharge()
	{
		yield return new WaitForSeconds(chargeTimeBigAttack);

		hasMovedCount = 0;

	}
	void Attack()
	{
		lookAtPlayer = false;
		Instantiate(arrow, muzzle.transform.position, gameObject.transform.rotation);
		if (gameObject.GetComponent<Boss_Dwarf_Stats>().phase2 == true)
		{
			Vector3 cone1 = gameObject.transform.rotation.eulerAngles + new Vector3(0, 30, 0);
			Vector3 cone2 = gameObject.transform.rotation.eulerAngles + new Vector3(0, -30, 0);
			Instantiate(arrow, p2MuzzleL.transform.position, Quaternion.Euler(cone2));
			Instantiate(arrow, p2MuzzleR.transform.position, Quaternion.Euler(cone1));
		}
		print("Attacking");
		Invoke("Move", 3f);
	}
	void Move()
	{
		MovetoNextPoint();
		destNode++;
	}
	void BigAttack()
	{

	}
}
