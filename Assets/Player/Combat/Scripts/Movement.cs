using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed, SpeedMultiplier, MouseX, MouseSens, Horz, Vert;
    public Animator Anim;
    public Rigidbody Rb;
    public bool Attaking;
    public Vector3 Direction;
    public Transform Target;

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Target = GetComponentInChildren<MoveDirectionTest>().transform;


    }

    private void Update()
    {
        Attaking = GetComponent<Attack>().Attacking;
        Move();
        transform.LookAt(Target, transform.up);

        RaycastHit Hit;
        if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward, out Hit, Mathf.Infinity))
        {
                Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), Hit.point, Color.magenta);

            //Mabye Mabye not the right movment / camera for this game
            if (Attaking)
            {
                transform.LookAt(new Vector3(Hit.point.x, transform.position.y, Hit.point.z));
            }




        }      
    }

    void Move()
    {
        Horz = Input.GetAxis("Horizontal");
        Vert = Input.GetAxis("Vertical");
        Direction = new Vector3(Horz , 0 , Vert);

        Rb.velocity = Direction * (moveSpeed * SpeedMultiplier) * Time.deltaTime;
    }

}
