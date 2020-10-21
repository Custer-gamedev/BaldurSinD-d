using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubDamageController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col) 
    {
        if(col.gameObject.tag == "Player")
        {
            print("Player took a hit");
            //put logic for player damage here, knockback?
        }
    }
}
