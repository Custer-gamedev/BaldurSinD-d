using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    GameObject Target;
    float StunTimer = 10, StilStun = 10;
    void Start()
    {
        Target = transform.parent.gameObject;
        transform.parent = GameObject.FindGameObjectWithTag("Canvas").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(Target.transform.position + transform.up);
        if (StilStun < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StilStun = StilStun - Time.deltaTime * 100;
            
        }

        print("time until stun runs out " + StilStun);
    }
}
