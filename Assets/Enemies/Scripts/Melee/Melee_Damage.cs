using UnityEngine;
using UnityEngine.AI;

public class Melee_Damage : MonoBehaviour
{
    public EnemyStats eStats;
    public float damage;
    public GameObject player;
    public float waitTime;
    private float attackTime;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        eStats = GetComponentInParent<EnemyStats>();
        attackTime = waitTime;
        damage = eStats.damage;
        GetComponentInParent<NavMeshAgent>().isStopped = false;

    }
    void Update()
    {
        GetComponentInParent<NavMeshAgent>().SetDestination(player.transform.position);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponentInParent<NavMeshAgent>().isStopped = true;
            if (attackTime <= 0)
            {
                other.GetComponent<PlayerStats>().TakeDamage(damage);
                attackTime = waitTime;
            }
            else
                attackTime -= Time.deltaTime;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            attackTime = waitTime;
        }
    }
}