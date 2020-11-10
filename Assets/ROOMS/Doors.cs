using UnityEngine;

public class Doors : MonoBehaviour
{
	public Transform doorSpawn;
	public GameObject playerCam;
	public GameObject player;
	public Animator doorAnim;
	public Transform oC;
	public static bool locked;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		doorSpawn = this.gameObject.transform.GetChild(0);
		playerCam = GameObject.Find("Main Camera");
		doorAnim = GetComponentInParent<Animator>();
	}
	private void Update()
	{
		oC = gameObject.GetComponentInChildren<SetCam>().otherCamPos;
		if (locked == true)
		{
			doorAnim.SetBool("IsOpen", false);
		}
		else if (locked == false)
			doorAnim.SetBool("IsOpen", true);

	}
	private void OnTriggerEnter(Collider other)
	{

		if (locked == false)
		{

			if (other.transform.name == "Player")
			{
				ChangeRoom();
			}
		}
	}

	void ChangeRoom()
	{
		player.transform.position = doorSpawn.transform.position;
		playerCam.transform.position = oC.position;
	}


}