using UnityEngine;

public class SetCam : MonoBehaviour
{
	int cols;
	public Transform otherCamPos;
	float timer = 4;

	public bool Colliding()
	{
		if (cols == 0)
			return false;

		else
			return true;
	}

	public void Update()
	{
		bool isColliding = Colliding();
		GameObject parent = this.transform.parent.gameObject;
		if (isColliding == false)
		{
			if (timer < 0)
			{
				Destroy(parent);
			}
			else
				timer -= Time.deltaTime;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Room" || other.tag == "BossRoom")
		{
			otherCamPos = other.gameObject.transform.Find("CamHolder");
			cols++;
		}
	}

	public void OnTriggerStay(Collider other)
	{
		if (other.transform.tag == "BossRoom")
		{
			transform.parent.parent.Find("Skull").gameObject.SetActive(true);
		}
	}
}