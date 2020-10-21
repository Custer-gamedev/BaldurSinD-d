using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Fire_Arrow : MonoBehaviour
{
    public GameObject bossRot;
    public float muzzleVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.rotation = bossRot.transform.rotation;
        gameObject.transform.position = gameObject.transform.position +gameObject.transform.forward * muzzleVelocity *  Time.deltaTime;
    }
}
