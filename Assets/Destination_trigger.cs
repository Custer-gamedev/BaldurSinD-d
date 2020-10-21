using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination_trigger : MonoBehaviour
{
    public GameObject boss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnTriggerEnter(Collider col) {
       
        if(col.gameObject.tag == "Boss"){
            print("collided correctly");
            boss.GetComponent<Boss_Dwarf_Controller>().Chargeattack();
        }
   }
}
