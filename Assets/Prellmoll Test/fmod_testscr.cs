using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class fmod_testscr : MonoBehaviour
{
    float hp;
    float intensity;

    
    void Start()
    {   
        
        FMODUnity.RuntimeManager.PlayOneShot("event:/MUS/MUS_F1", gameObject.transform.position);
    }
    
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Space)){
         FMODUnity.RuntimeManager.PlayOneShot("event:/Hermod/ATK_1", gameObject.transform.position);
         
     }   
    }
}
