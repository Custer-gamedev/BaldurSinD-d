using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Controller : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    public void AttackPlayer()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/ATK/ATK_1");
    }
    public void AttackEnemy()
    {

    }
    
}
