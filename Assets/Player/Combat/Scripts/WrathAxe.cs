using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro.Examples;
using UnityEditor;
using UnityEngine;

public class WrathAxe : MonoBehaviour
{
    Rigidbody Rb;
    public float Speed;
    public GameObject AxeLandingMarker;
    public bool Thrown = true;
    public GameObject Player;

    float curontXrotation;
    Vector3 lookAtMarker;
    private bool inAir;
    public float axeSpinSpeed;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        AxeLandingMarker = GameObject.FindGameObjectWithTag("ATCK2axeMarker");
        Player = GameObject.Find("Player");
        Player.GetComponent<PlayerMove>().attacking = false;
    }

    void Update()
    {
        if (AxeLandingMarker != null)
        {
            if (!inAir)
            {
                transform.LookAt(AxeLandingMarker.transform, Vector3.up);
                inAir = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, AxeLandingMarker.transform.position, Time.deltaTime * Speed);
            transform.Rotate(axeSpinSpeed * Time.deltaTime,0,0,Space.Self);

            Debug.Log("ALTTID");
            /* 
            curontXrotation += transform.localRotation.x + 10;
            transform.localRotation = Quaternion.Euler(curontXrotation, 0, 0);
            */
        }
        else
        {
            inAir = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case ("ATCK2axeMarker"):
                Thrown = false;
                Destroy(other.gameObject);
            break;

            case ("Player"):
                if (!Thrown)
                {
                    other.GetComponent<Attack>().CD2.SetActive(true);
                    other.GetComponent<Attack>().GotAxe = true;
                    other.GetComponent<Attack>().SpawnArrow = true;
                    Destroy(this.gameObject);
                }
            break;

            case ("Wall"):
                Thrown = false;
                Destroy(GameObject.Find("AxeLandingMark(Clone)"));
                break;

            case ("Ground"):
                Destroy(GameObject.Find("AxeLandingMark"));
            break;
        }
    }
}