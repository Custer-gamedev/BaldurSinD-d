using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureList : MonoBehaviour
{
    public List<GameObject> tObject = new List<GameObject>();
    public Transform testSpawn;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.K)){
            int rand = Random.Range(0, tObject.Count);
            Instantiate(tObject[rand], testSpawn.transform.position, transform.rotation);
            tObject.RemoveAt(rand);
        }
    }
}
