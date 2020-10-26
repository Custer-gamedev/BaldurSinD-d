using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Treasure", menuName = "Make Treasure", order = 0)]
public class Treasure : ScriptableObject
{

	[Header("Text and Model")]
	public string itemName;
	public string description;
	[Header("Stats")]
	public float playerHealthIncrease;
	public float playerDamageIncrease;
	public float playerMovementSpeedIncrease;
	public float playerAttackSpeedIncrease;
}
