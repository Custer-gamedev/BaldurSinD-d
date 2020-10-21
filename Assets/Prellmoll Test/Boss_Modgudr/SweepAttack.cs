using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepAttack : MonoBehaviour
{
    
    
    Animator myAnim;
    public GameObject Club;

    
    // Start is called before the first frame update
    void Start()
    {
        myAnim = Club.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void SweepingAttack()
    {
       myAnim.SetTrigger("SweepAttack");
       
    }
    public void SlamAttack(){
        myAnim.SetTrigger("SlamAttack");
    }
}
