using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.IO;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public float speed, damage, health, attackSpeed, maxHealth;
	public Animator canvasAnim;

	public TextMeshProUGUI healthTxt, speedTxt, damageTxt, itemName, itemDesc, attackSTxt;
	public DataToSave data;

	void Awake()
	{
		if (File.Exists(SaveData.Path()))
		{
			data = SaveData.Load();
			print("File exists");
		}
		else
		{
			print("File doesn't exist");
		}
		health = maxHealth;
		UpdateUI();
	}

	#region SaveData

	private void Update()
	{
		if (health <= 0)
		{
			SaveData.Save(data);
			UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScreen");
		}
	}
	public void GetNormalKills(int amount)
	{
		data.kills += amount;
	}
	public void GetBossKills(int amount)
	{
		data.bossesKilled += amount;
	}
	public void GetFloorCleared(int amount)
	{
		data.floorsCleared += amount;
	}

	private void OnApplicationQuit()
	{
		SaveData.Save(data);
	}
	#endregion
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
		attackSTxt.text = "AttackSpeed: " + (attackSpeed * 10f).ToString();
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
			data.treasuresPickedUp++;
			canvasAnim.Play("FadeInOut");

			Destroy(ot.gameObject, 3);
			UpdateUI();
		}
	}
}

[System.Serializable]
public class DataToSave
{

	public int kills;
	public int floorsCleared;
	public int treasuresPickedUp;
	public int bossesKilled;
}