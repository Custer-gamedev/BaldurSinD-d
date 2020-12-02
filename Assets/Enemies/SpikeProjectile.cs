using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeProjectile : MonoBehaviour
{
	private LineRenderer lr;
	public LayerMask groundMask;
	public Transform tip;
	private void Start()
	{
		lr = GetComponent<LineRenderer>();
	}
	private void Update()
	{
		lr.SetPosition(0, tip.transform.position);
		RaycastHit hit;
		if (Physics.Raycast(tip.transform.position, tip.transform.up, out hit, 30, groundMask))
		{
			lr.SetPosition(1, hit.transform.position);
			print(hit.transform.position);
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.DrawRay(tip.transform.position, tip.transform.up * 20);
	}
}
