using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class fmod_testscr : MonoBehaviour
{
    public float hp;
    public float intensity;
    FMOD.Studio.EventInstance Music;

    
    void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/MUS/MUS_F1");
        Music.start();
    }
    
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Space)){
         FMODUnity.RuntimeManager.PlayOneShot("event:/Hermod/ATK_1", gameObject.transform.position);
         
     }   
     
        Music.setParameterByName("Intensity2", intensity);
        Music.setParameterByName("Health", hp);
        
    }
}
