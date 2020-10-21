using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Dwarf_Controller : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject dest1, dest2, dest3, dest4, arrow, muzzle, player;
    bool moving, attacking;
    int destNode;
    public float chargeTime;
    Vector3 muzzlev3;
    bool lookAtPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        attacking = false;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            MovetoNextPoint();
            destNode++;
        }
        if (lookAtPlayer == true)
        {
            print (lookAtPlayer);
            Vector3 lookVector = player.transform.position - transform.position;
            lookVector.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        }
    }

    void MovetoNextPoint()
    {
        switch (destNode)
        {
            case 0:
            BigAttack();
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
            default:
            destNode = 0;
            break;
        }
        
    }
    public IEnumerator Chargeattack(){
        print("chargingAttack");
        lookAtPlayer = true;
        yield return new WaitForSeconds(chargeTime);
        Attack();
    }
    void Attack()
    {
        lookAtPlayer = false;
        Instantiate(arrow);
        print("Attacking");
    }
    void BigAttack(){
        print("Fire 3 arrows");
    }
}
