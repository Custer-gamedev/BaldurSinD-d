﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUS_Controller : MonoBehaviour
{
    FMOD.Studio.EventInstance Music;
    public float intensity;
    public float HP = 100;
    public float volume;
    public static bool isBoss;
    // Start is called before the first frame update
    void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/MUS/MUS_F1");
        Music.start();
        
    }

    // Update is called once per frame
    void Update()
    {
        Music.setParameterByName("Intensity2", intensity);
        Music.setParameterByName("Health", HP);
        Music.setParameterByName("VolumeSetting", volume * .01f);
        if (Doors.locked && !isBoss)
        {
            intensity = 1;
        }
        if (Doors.locked && isBoss)
        {
            intensity = 2;
        }
        //if boss
        //intensity 2
        if (!Doors.locked)
        {
            intensity = 0;
        }
    }
}