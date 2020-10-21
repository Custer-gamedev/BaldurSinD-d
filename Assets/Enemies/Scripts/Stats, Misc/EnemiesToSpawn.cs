using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesToSpawn", menuName = "EnemiesToSpawn", order = 0)]
public class EnemiesToSpawn : ScriptableObject {
    public List<GameObject> enemies = new List<GameObject>();
}
