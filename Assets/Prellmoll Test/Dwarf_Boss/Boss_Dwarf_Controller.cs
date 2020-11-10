using System.Reflection;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Dwarf_Controller : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject dest1, dest2, dest3, dest4, dest5, arrow, muzzle, p2MuzzleL, p2MuzzleR, p2spinMuzzle, player;
    bool moving, attacking;
    int destNode, hasMovedCount;
    public float chargeTime, chargeTimeBigAttack, firerate, lastfired, bigAtkTurnSpeed, startedTurning;
    
    float startAngle, targetAngle;
    public Vector3 currentFacing;
    bool lookAtPlayer;
    public bool hasMoved, Spinning;
    Vector3 curPos;

    

    void Start()
    {
        destNode++;
        MovetoNextPoint();
    }
    void Update()
    {  
        var backwards = gameObject.transform.rotation.eulerAngles + new Vector3(0, -180, 0);
        print(Spinning);
        if (Spinning)
        {
            if (Time.time - lastfired > 1 / firerate)
            {
                lastfired = Time.time;
                Instantiate(arrow, muzzle.transform.position, transform.rotation);
                if(gameObject.GetComponent<Boss_Dwarf_Stats>().phase2 == true){
                    Instantiate(arrow, p2spinMuzzle.transform.position, Quaternion.Euler(backwards));
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.O)){
            BigAttack();
        }
        if(Input.GetKeyDown(KeyCode.P)){
            destNode++;
            MovetoNextPoint();
        }
        if (lookAtPlayer == true)
        {
            //print (lookAtPlayer);
            Vector3 lookVector = player.transform.position - transform.position;
            lookVector.y = transform.rotation.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        }
       
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "M_Node"){
            print("Collided");
            StartCoroutine("Chargeattack");
            hasMovedCount++;
           
        }   
        if (other.gameObject.tag == "M_Node_Centre" && hasMovedCount >= 6){
            StartCoroutine(BigCharge());
        } 
    }
    void MovetoNextPoint()
    {
        switch (destNode)
        {
            case 0:
            BigCharge();
            break;
            case 1:
            agent.SetDestination(dest1.transform.position);
            break;
            case 2:
            agent.SetDestination(dest2.transform.position);
            break;
            case 3:
            agent.SetDestination(dest3.transform.position);
            break;
            case 4: 
            agent.SetDestination(dest4.transform.position);
            break;  
        }
    }
    private IEnumerator Chargeattack()
    {
        print("chargingAttack");
        lookAtPlayer = true;
        yield return new WaitForSeconds(chargeTime);
        Attack();
        var lastPos = destNode;
        destNode = Random.Range(1, 5);
        if(hasMovedCount < 6){
            while(destNode == lastPos){
                destNode = Random.Range(1, 5);
                print ("WhileStarted");
                if(lastPos != destNode){
                    MovetoNextPoint();
                    print ("WhileStopping");
                }
            }
            //print("Lastpos" + lastPos + " Destnode "+ destNode);
        if (destNode != lastPos){
            MovetoNextPoint();
        }
        }
       
          if(hasMovedCount >= 6)
        {
            agent.SetDestination(dest5.transform.position);
        }
        
        
    }
    IEnumerator Rotate(float duration)
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;
        while ( t  < duration )
        {
            Spinning = true;
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }
        Spinning = false;
        MovetoNextPoint();
    }
    private IEnumerator BigCharge(){
        yield return new WaitForSeconds(chargeTimeBigAttack);
        BigAttack();
        hasMovedCount = 0;
    }
    void Attack()
    {
        lookAtPlayer = false;
        Instantiate(arrow, muzzle.transform.position, gameObject.transform.rotation);
        if(gameObject.GetComponent<Boss_Dwarf_Stats>().phase2 == true)
        {
            Vector3 cone1 = gameObject.transform.rotation.eulerAngles + new Vector3(0,30,0);
            Vector3 cone2 = gameObject.transform.rotation.eulerAngles + new Vector3(0,-30,0);
            Instantiate(arrow, p2MuzzleL.transform.position, Quaternion.Euler(cone2));
            Instantiate(arrow, p2MuzzleR.transform.position, Quaternion.Euler(cone1));
        }
        print("Attacking");
    }
    void BigAttack()
    {
        startedTurning = Time.time;
        Spinning = true;
        StartCoroutine(Rotate(3f));
        

    }
}
