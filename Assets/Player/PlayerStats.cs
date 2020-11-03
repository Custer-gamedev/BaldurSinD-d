using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public float speed, damage, health, attackSpeed, maxHealth;
	public Animator canvasAnim;

	public TextMeshProUGUI healthTxt, speedTxt, damageTxt, itemName, itemDesc, attackSTxt;

	void Awake()
	{
		health = maxHealth;
		UpdateUI();
	}

	private void Update()
	{
	}
	public void TakeDamage(float amount)
	{
		health -= amount;
		healthTxt.text = "Health: " + health.ToString() + " / " + maxHealth.ToString();

	}

	public void Heal(float amount)
	{
		health = Mathf.Clamp(health, 0, maxHealth - .5f);
		health += amount;
		healthTxt.text = "Health: " + health.ToString() + " / " + maxHealth.ToString();

	}

	public void UpdateUI()
	{
		healthTxt.text = "Health: " + health.ToString() + " / " + maxHealth.ToString();
		speedTxt.text = "Speed: " + speed.ToString();
		damageTxt.text = "Damage: " + damage.ToString();
	//	attackSTxt.text = "AttackSpeed: " + (attackSpeed * 10f).ToString();
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Treasure")
		{
			other.GetComponent<Collider>().enabled = false;
			T_Item ot = other.gameObject.GetComponent<T_Item>();
			health += ot.health;
			maxHealth += ot.health;
			speed += ot.moveSpeed;
			damage += ot.damage;
			attackSpeed -= ot.attackSpeed;
			GetComponentInChildren<Attack>().UpdateCooldownTime();
			itemName.text = "You picked up " + ot.itemName;
			itemDesc.text = ot.description;

			canvasAnim.Play("FadeInOut");

			Destroy(ot.gameObject, 3);
			UpdateUI();
		}
	}
}