using System.Collections;
using UnityEngine;

public class Souls : MonoBehaviour
{

    private Transform destination;
    void Awake()
    {
        SpawnSoul();
    }

    void SpawnSoul()
    {
        int rand = Random.Range(0, 2);
        print(rand);
        if(rand == 0)
        {
            GameObject bossRoom = GameObject.FindGameObjectWithTag("BossRoom");
            //GetComponent<ParticleSystem>().startColor = Color.red;
            destination = bossRoom.transform;
            Destroy(gameObject, 3f);
        }
        if(rand == 1)
        {
            GameObject treasureRoom = GameObject.FindGameObjectWithTag("TreasureRoom");
            //GetComponent<ParticleSystem>().startColor = Color.yellow;
            destination = treasureRoom.transform;

            Destroy(gameObject, 3f);
        }
    }
    void Update()
    {
            transform.position = Vector3.Lerp(transform.position, destination.transform.position, .3f * Time.deltaTime);
     
    }
}
