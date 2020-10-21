using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreasure : MonoBehaviour {
    public TreasureList treasureList;
    Transform spawnPoint;
    public bool spawned;
    private void Awake () {
        treasureList = GameObject.FindGameObjectWithTag ("GameController").GetComponent<TreasureList> ();
        spawnPoint = this.transform;
    }
    public void Spawn () {
        if (!spawned) {
            int rand = Random.Range (0, treasureList.tObject.Count);
            GameObject justSpawned = Instantiate (treasureList.tObject[rand], spawnPoint.transform.position, transform.rotation);
            treasureList.tObject.RemoveAt (rand);
            spawned = true;
        }
    }
}