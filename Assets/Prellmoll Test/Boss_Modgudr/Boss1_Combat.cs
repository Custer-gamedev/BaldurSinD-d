using System.Collections;
using UnityEngine;

    public enum BossState {PrimingAttack,Attacking,Moving,Idle, PrimingThrow }
public class Boss1_Combat : MonoBehaviour
{
    private Vector3 currentlocation;
    public GameObject ThrowProjectile, player;
    public float AttackRange;
    bool Attacking, inRange, sweepUsed, slamUsed;
    float outOfRangeTimer = 4;
    public Vector3 sweepAttackArea;
    public LayerMask playerMask;
    public GameObject sweepRotator;
    public float moveSpeed;
    bool MovementAvailable;
    Rigidbody playerRB;
    public int AttackSelection = 0;

    void Start()
    {
        //playerRB = player.GetComponent<Rigidbody>();
        sweepUsed = false;
        slamUsed = false;
    }


    private BossState curState = BossState.Idle;
    void Update()
    {
        currentlocation = transform.position;

        if (inRange == false)
        {
            outOfRangeTimer -= Time.deltaTime;
            print(outOfRangeTimer);
        }



        if (!inRange)
        {
            curState = BossState.Moving;
        }
        else if (outOfRangeTimer <= 0)
        {
            //RockThrow();
            //outOfRange();
        }
        if (!Attacking)
        {
            Vector3 lookdirection = player.transform.position - transform.position;
            lookdirection.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookdirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        }
       
        switch (curState)
        {
            case BossState.PrimingAttack:
                MovementAvailable = false;
                print(curState);
                break;
            case BossState.Attacking:
                Attacking = true;
                outOfRangeTimer = 4;
                print(curState);
                break;
            case BossState.Moving:
                print(curState);
                MovementAvailable = true;
                break;
            case BossState.PrimingThrow:
                MovementAvailable = false;
                print(curState);
                //RockThrow();
                break;
            default:
                break;
        }

        if (MovementAvailable && !Attacking)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * moveSpeed);
            //transform.position - new Vector3(player.transform.position.x, 0, player.transform.position.z)* Time.deltaTime * moveSpeed;
        }
        else if (!MovementAvailable)
        {
            transform.position = currentlocation;
            print(MovementAvailable + "can move");
        }
        print("is player in range" + inRange);


        if (Input.GetKeyDown(KeyCode.P))
        {
            //RockThrow();
        }
    }
   
    #region ATTACK REGION
    void Attack()
    {
        switch (AttackSelection)
        {
            case 0:
                Sweep();
                break;
            case 1:
                Slam();
                break;
            case 2:
                Bellow();
                break;
            default:
                return;
        }
    }
    void Slam()
    {
        sweepRotator.GetComponent<SweepAttack>().SlamAttack();
        AttackSelection = AttackSelection + 1;
        StartCoroutine(AttackDelay());
    }
    void Sweep()
    {
        sweepRotator.GetComponent<SweepAttack>().SweepingAttack();
        print("Sweepattack successful");
        sweepUsed = true;
        AttackSelection = AttackSelection + 1;
        StartCoroutine(AttackDelay());
    }
    void Bellow()
    {
        print("RAGHRRAHR");
        AttackSelection = 0;
        AttackDelay();
        /*if (!inRange){
            curState = BossState.Moving;
        }*/
    }
    #endregion

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(1);
        if (inRange)
        {
            curState = BossState.Attacking;
            Invoke("Attack", 0);
            print("Starting ATTACK");
        }
        else if (!inRange)
        {
            curState = BossState.Moving;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(AttackDelay());
            curState = BossState.PrimingAttack;
            inRange = true;
            print(other.gameObject.name + "this fucker");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            curState = BossState.Moving;
            inRange = false;
        }
    }
}
