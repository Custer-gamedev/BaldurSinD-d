using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDoorThere : MonoBehaviour
{
	bool isDoor = false;
	int cols;
	public float waitTime = 2;

	bool IsCollding()
	{
		if (cols == 0)
		{
			return false;
		}
		else
			return true;
	}
	public void Update()
	{

		if (waitTime <= 0)
		{
			if (IsCollding() == false)
			{
				Destroy(transform.parent.gameObject.transform.parent.gameObject);

			}
			else if (IsCollding() == true)
				Destroy(this);

		}
		else
			waitTime -= Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Door")
		{
			cols++;
		}

	}
}
