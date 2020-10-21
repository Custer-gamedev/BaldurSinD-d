using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Item : MonoBehaviour {
    public Treasure _t;
    public string description, itemName;
    public float damage, health, moveSpeed;

    public void Awake () {
        description = _t.description;
        itemName = _t.itemName;
        damage = _t.playerDamageIncrease;
        health = _t.playerHealthIncrease;
        moveSpeed = _t.playerMovementSpeedIncrease;
    }
}