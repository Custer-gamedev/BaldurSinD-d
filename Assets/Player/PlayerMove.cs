using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
	[Header("Body/Move")]
	private float maxSpeed = 8f;
	public float moveSpeed;
	public PlayerStats pStats;
	private Currency currency;
	public bool attacking;
	public Transform body;
	public Transform target;

	public static bool allowedToMove = true;

	PlayerStats playerStats;
	Vector3 forward, right, moveDir;

	private void Start()
	{
		playerStats = GetComponent<PlayerStats>();
		forward = Camera.main.transform.forward;
		forward.y = 0;
		currency = GameObject.FindGameObjectWithTag("GameController").GetComponent<Currency>();
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
		body = this.transform;
		pStats = GetComponent<PlayerStats>();
	}
	private void Update()
	{


		float moveFloatX = Input.GetAxisRaw("Horizontal");
		float moveFloatY = Input.GetAxisRaw("Vertical");

		//if (moveFloatX <= 0 || moveFloatX >= 0 || moveFloatY <= 0 || moveFloatY >= 0)
		if (Input.anyKey)
			Move();


		moveSpeed = pStats.speed;

		attacking = GetComponent<Attack>().Attacking;
		transform.LookAt(target, transform.up);

		RaycastHit Hit;
		if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward, out Hit, Mathf.Infinity))
		{
			Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), Hit.point, Color.magenta);
			//todo: Mabye not the right movment / camera for this game  
			if (attacking)
			{
				transform.LookAt(new Vector3(Hit.point.x, transform.position.y, Hit.point.z));
			}
		}
	}

	void Move()
	{
		if (allowedToMove)
		{

			moveDir = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
			Vector3 rightMove = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
			Vector3 upMove = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

			moveDir = Vector3.Normalize(rightMove + upMove);

			if (moveDir == Vector3.zero)
				return;

			transform.forward = moveDir;
			//BEVEGELSE
			transform.position += rightMove;
			transform.position += upMove;
		}
	}

	//Gjør denne senere, men skal rotere langs musa
}