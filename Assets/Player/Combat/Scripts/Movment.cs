using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public float moveSpeed = 8f, MouseX, MouseSens;
    public Transform body;
    Vector3 forward, right;
    public Animator Anim;
    public LayerMask GroundLayer;
    bool Attaking; 


    private void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    private void Update()
    {
        Attaking = GetComponent<Attack>().Attacking;

        if (!Attaking)
        {
            Move();
            RaycastHit Hit;
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward, out Hit, Mathf.Infinity, GroundLayer))
            {
                Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), Hit.point, Color.magenta);
                transform.LookAt((Hit.point + transform.position) - transform.position);               
            }               
        }
    }

    void Move()
    {
        Vector3 rightMove = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMove = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        

        //BEVEGELSE
        transform.position += rightMove;
        transform.position += upMove;
    }

}
