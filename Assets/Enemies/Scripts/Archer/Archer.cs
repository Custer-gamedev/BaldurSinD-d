using UnityEngine;
using UnityEngine.AI;

public class Archer : MonoBehaviour
{
    public GameObject arrow;
    public GameObject player;
    public Transform barrelPos;
    private Vector3 playerPos;
    public LayerMask playerMask;
    public NavMeshAgent navM;
    public float spottingSize = 3;
    public float shootTimer, waitTime, arrowSpeed;
    private void Awake()
    {
        navM = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

    }
    void Update()
    {
        if (Physics.CheckSphere(transform.position, spottingSize, playerMask))
        {
            navM.isStopped = true;
            if (shootTimer <= 0)
            {
                GameObject arrowClone = Instantiate(arrow, transform.position,Quaternion.LookRotation(player.transform.position - transform.position));
                arrowClone.AddComponent<Ranged_Damage>();
                arrowClone.GetComponent<Ranged_Damage>().eStats = GetComponent<EnemyStats>();
                arrowClone.GetComponent<Rigidbody>().AddForce(transform.forward * arrowSpeed, ForceMode.Impulse);
                Destroy(arrowClone, 4f);
                shootTimer = waitTime;
            }
            else
                shootTimer -= Time.deltaTime;
        }
        else
        {
            navM.isStopped = false;
            navM.SetDestination(player.transform.position);
        }

        RotateTowardsPlayer();

        //  transform.Rotate(player.transform.position);
    }
    void RotateTowardsPlayer()
    {
        Vector3 dir = player.transform.position - transform.position;
        dir.y = 0;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spottingSize);
    }
}