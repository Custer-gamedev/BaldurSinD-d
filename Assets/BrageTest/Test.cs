using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{

	public Rigidbody rb;
	public Transform moveTarget;
	public NavMeshAgent agent;
	// Update is called once per frame
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			StartCoroutine(Knockback());
		}
		agent.SetDestination(moveTarget.position);
	}
	public IEnumerator Knockback()
	{
		agent.isStopped = true;
		rb.AddForce(-transform.forward * 2f, ForceMode.Impulse);
		yield return new WaitForSeconds(1);
		rb.velocity = Vector3.zero;
		agent.isStopped = false;

	}
}
