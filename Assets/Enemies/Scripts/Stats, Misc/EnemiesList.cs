using System.Collections.Generic;
using UnityEngine;

public class EnemiesList : MonoBehaviour {
    public List<EnemiesToSpawn> enemySet = new List<EnemiesToSpawn>();
    public List<GameObject> enemiesAlive = new List<GameObject> ();
    public GameObject boss;
    private void Awake () {
    }

    private void Update () {
        if (enemiesAlive.Count > 0) {
            Doors.locked = true;
        } else if (enemiesAlive.Count <= 0) {
            Doors.locked = false;
        }
    }
}