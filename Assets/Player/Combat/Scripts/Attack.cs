using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
	[Header("Basic Attack")]
	public float coolDownTime, attackDelay;
	public GameObject BasicHitBox, CD;
	public Vector3 Offset; // offset of attack from the player

	[Header("Second Attack")]
	public float AtkDelay2;
	public GameObject SecondHitBox, TargetIndicator, CD2, AxeOnMap;
	public GameObject ATCK2canvas;
	public Vector3 offset2;
	public bool charging = true, gotAxe = true, spawnArrow = true;

	[Header("Third Attack")]
	public float AtkDelay3;
	public GameObject ThirdHitBox, CD3;

	public bool Attacking;
	public GameObject Player;
	[Header("Movement")]
	float halfSpeed;

	private void Start()
	{
		Player = this.gameObject;
		UpdateCooldownTime();
	}

	void Update()
	{
		#region BasicAttack
		if (attackDelay >= 0) attackDelay -= Time.deltaTime * 0.1f;
		else
		{
			CD.SetActive(false);
		}
		CD.GetComponentInChildren<Text>().text = (attackDelay * 10).ToString();
		if (Input.GetButton("Fire1") && GameObject.FindGameObjectWithTag("ATCK") == null && GameObject.FindGameObjectWithTag("ATCK3") == null && GameObject.Find("arrow(Clone)") == null && PlayerMove.allowedToMove == true)
		{
			if (attackDelay <= 0)
			{
				FMODUnity.RuntimeManager.PlayOneShot("event:/Hermod/ATK_1");
				Attacking = true;
				halfSpeed = Player.GetComponent<PlayerStats>().speed / 2;
				Player.GetComponent<PlayerStats>().speed = halfSpeed;
				Instantiate(BasicHitBox, Offset /* transform.forward*/, Quaternion.Euler(0, 0, 0), this.transform);
				CD.SetActive(true);
				attackDelay = coolDownTime;
			}
		}
		#endregion

		#region SecondAttack
		float CoolDownTime2 = coolDownTime * 2f;
		AxeOnMap.SetActive(!gotAxe);
		if (gotAxe)
		{
			if (AtkDelay2 >= 0)
			{
				AtkDelay2 -= Time.deltaTime * 0.1f;
			}
			else
			{
				CD2.SetActive(false);
			}
			CD2.GetComponentInChildren<Text>().text = (AtkDelay2 * 10).ToString();

			//creates indicator
			if (Input.GetButton("Fire2") && AtkDelay2 <= 0 && GameObject.FindGameObjectWithTag("ATCK") == null && GameObject.FindGameObjectWithTag("ATCK3") == null && PlayerMove.allowedToMove == true)
			{
				Attacking = true;
				ATCK2canvas = GameObject.FindGameObjectWithTag("ATCK2canvas");

				if (spawnArrow)
				{
					Instantiate(TargetIndicator, (transform.position + offset2) + transform.forward, Quaternion.Euler(0, 0, 0), ATCK2canvas.transform);
					spawnArrow = false;
				}
			}

			//creates throwing axe
			if (Input.GetButtonUp("Fire2") && PlayerMove.allowedToMove == true)
			{
				if (AtkDelay2 <= 0 && GameObject.FindGameObjectWithTag("ATCK") == null && GameObject.FindGameObjectWithTag("ATCK3") == null)
				{
					Attacking = false;
					Instantiate(SecondHitBox, (transform.position + offset2) + transform.forward, Quaternion.Euler(0, 0, 0), null);
					AtkDelay2 = CoolDownTime2;
					gotAxe = false;

				}
			}
		}

		#endregion

		#region ThridAttack
		float CoolDownTime3 = coolDownTime * 3f;

		if (AtkDelay3 >= 0) AtkDelay3 -= Time.deltaTime * 0.1f;
		else
		{
			CD3.SetActive(false);
		}
		CD3.GetComponentInChildren<Text>().text = (AtkDelay3 * 10).ToString();
		if (Input.GetButtonDown("Fire3") && GameObject.FindGameObjectWithTag("ATCK") == null && GameObject.FindGameObjectWithTag("ATCK3") == null && GameObject.Find("arrow(Clone)") == null && PlayerMove.allowedToMove == true)
		{
			if (AtkDelay3 <= 0)
			{
				Attacking = true;
				GameObject tempAss = Instantiate(ThirdHitBox, transform.position, Quaternion.Euler(0, 0, 0), this.transform);
				Destroy(tempAss, 1f);
				CD3.SetActive(true);
				AtkDelay3 = CoolDownTime3;
			}
		}
		#endregion
	}

	public void UpdateCooldownTime()
	{
		coolDownTime = Player.GetComponent<PlayerStats>().attackSpeed;
	}

}
