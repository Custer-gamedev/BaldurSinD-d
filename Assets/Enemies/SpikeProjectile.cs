using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeProjectile : MonoBehaviour
{
	private LineRenderer lr;
	private void Start()
	{
		lr = GetComponent<LineRenderer>();
	}
	private void Update()
	{
		//	lr.SetPosition(0, tip.transform.position);
	}
	private void OnDrawGizmos()
	{
		//Gizmos.DrawRay(tip.transform.position, tip.transform.up * 20);
	}
}
