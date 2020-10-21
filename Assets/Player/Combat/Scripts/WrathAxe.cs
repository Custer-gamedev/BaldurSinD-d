using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WrathAxe : MonoBehaviour
{
    Rigidbody Rb;
    public float Speed;
    public GameObject AxeLandingMarker;
    public bool Thrown = true;
    Animator Anim;
    public GameObject Player;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        AxeLandingMarker = GameObject.FindGameObjectWithTag("ATCK2axeMarker");
        Anim = GetComponent<Animator>();

        Player = GameObject.Find("Player");
        Player.GetComponent<PlayerMove>().attacking = false;
    }

    void Update()
    {
        if (AxeLandingMarker != null)
        {
            transform.LookAt(AxeLandingMarker.transform,Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, AxeLandingMarker.transform.position, Time.deltaTime * Speed);           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case ("ATCK2axeMarker"):
                Thrown = false;
                Destroy(other.gameObject);
                Anim.SetBool("InGround", true);
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
            
            case ("Ground"):
                Destroy(GameObject.Find("AxeLandingMark"));
            break;
        }
    }
}