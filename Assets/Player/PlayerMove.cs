using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    private float maxSpeed = 8f;
    public float moveSpeed;
    public PlayerStats pStats;
    private Currency currency;
    public bool attacking;
    public Transform body;
    PlayerStats playerStats;
    Vector3 forward, right;
   
    private void Start () {
        playerStats = GetComponent<PlayerStats>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        currency = GameObject.FindGameObjectWithTag("GameController").GetComponent<Currency>();
        forward = Vector3.Normalize (forward);
        right = Quaternion.Euler (new Vector3 (0, 90, 0)) * forward;
        body = this.transform;
        pStats = GetComponent<PlayerStats>();

    }
    private void Update () {
        Move();
        moveSpeed = pStats.speed;
       /* if (Input.GetKeyDown(KeyCode.R))
        {
            currency.GetCoins(+1);
        } */
      //RotateMouse();
    }
    void Move () {
        Vector3 dir = new Vector3 (Input.GetAxis ("HorizontalKey"), 0, Input.GetAxis ("VerticalKey"));
        Vector3 rightMove = right * moveSpeed * Time.deltaTime * Input.GetAxis ("HorizontalKey");
        Vector3 upMove = forward * moveSpeed * Time.deltaTime * Input.GetAxis ("VerticalKey");

        Vector3 moveDir = Vector3.Normalize (rightMove + upMove);

        //ROTASJON
        transform.forward = moveDir;

        //BEVEGELSE
        transform.position += rightMove;
        transform.position += upMove;
    }
   
    //Gjør denne senere, men skal rotere langs musa
    void RotateMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.y ,body.transform.position.y));
        Vector3 forward = mouseWorld - body.transform.position;
        body.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }

}