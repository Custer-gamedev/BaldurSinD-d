using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Smoothening;
    public Vector3 Offset;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {        
        Vector3 endPos = Target.position + Offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, endPos, Smoothening);
        transform.position = smoothPos;
    }
}
