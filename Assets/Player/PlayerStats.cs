using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public float speed, damage, health;
    public Animator canvasAnim;

    public TextMeshProUGUI healthTxt, speedTxt, damageTxt, itemName, itemDesc;

    void Awake()
    {
        UpdateUI();
    }

    public void TakeDamage (float amount) {
        health -= amount;
      
        UpdateUI();
    }

    public void UpdateUI() {
        healthTxt.text = "Health: " + health.ToString();
        speedTxt.text = "Speed: " + speed.ToString();
        damageTxt.text = "Damage: " + damage.ToString();
    }

    public void OnTriggerEnter (Collider other) {
        if (other.transform.tag == "Treasure") {
            other.GetComponent<Collider> ().enabled = false;
            T_Item ot = other.gameObject.GetComponent<T_Item> ();
            health += ot.health;
            speed += ot.moveSpeed;
            damage += ot.damage;
            itemName.text = "You picked up " + ot.itemName;
            itemDesc.text = ot.description;

            canvasAnim.Play ("FadeInOut");

            Destroy (ot.gameObject, 3);
            UpdateUI();
        }
    }
}