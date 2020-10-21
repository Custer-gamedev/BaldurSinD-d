using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Damage : MonoBehaviour {
    public EnemyStats eStats;
    public float damage = 5f;
    private void Awake () {
    }

    private void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            other.GetComponent<PlayerStats> ().TakeDamage (damage);
        }
    }
}