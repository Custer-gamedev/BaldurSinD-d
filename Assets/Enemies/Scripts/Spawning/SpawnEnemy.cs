using UnityEngine;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {
    public EnemiesList enemiesList;
    private List<GameObject> spawningList = new List<GameObject>();
    public Transform spawnPoint;
    public EnemiesToSpawn enemyCount;
    private int rand;
    bool spawned = false;
    private void Awake () {
        enemiesList = GameObject.FindGameObjectWithTag ("GameController").GetComponent<EnemiesList> ();
        spawnPoint = this.transform;
    }

    public void Update () {
        if (Input.GetKeyDown (KeyCode.J)) {
            foreach (GameObject g in enemiesList.enemiesAlive) {
                g.GetComponent<EnemyStats>().hp = 0;
            }
            enemiesList.enemiesAlive.Clear ();
        }

    }
    public void Spawn () {
        if (!spawned) {
            if (this.transform.name == "BossSpawnPoint(Clone)") {
                GameObject justSpawned = Instantiate (enemiesList.boss, spawnPoint.transform.position, transform.rotation);
                enemiesList.enemiesAlive.Add (justSpawned);
                spawned = true;
            } else {
                rand = Random.Range (0, enemiesList.enemySet.Count);
                enemyCount = enemiesList.enemySet[rand];
                spawningList.AddRange(enemyCount.enemies);

                foreach (Transform t in spawnPoint) {
                    int spawnedAmount = 0;
                    for (int i = 0; i < spawningList.Count; i++) {
                        if (spawnedAmount == 0) { 
                            GameObject justSpawned = Instantiate (spawningList[i], t.transform.position, transform.rotation);
                            enemiesList.enemiesAlive.Add (justSpawned);
                            spawningList.RemoveAt(i);
                            spawnedAmount++;
                        }
                    }
                }
                spawned = true;
                print (enemyCount.name);

            }

        }

    }
}
