using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float hp, damage;
    public GameObject soul;
    public bool Souls() {
    int rand = Random.Range(0, 4);
        if (rand == 1)
            return true;
        else
            return false;
    }
    
    Color thisColor;
    private EnemiesList enemiesList;
    void Awake()
    {
        enemiesList = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemiesList>();
        
        thisColor = GetComponent<Renderer>().material.color;
    }
    void Update()
    {
        if (hp <= 0)
        {
            if (Souls() == true)
            {
                Instantiate(soul, transform.position, transform.rotation);
                Destroy(gameObject);
                enemiesList.enemiesAlive.Remove(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
                enemiesList.enemiesAlive.Remove(this.gameObject);
            }

        }
    }
    void OnTriggerEnter(Collider other)
    {
        PlayerStats P = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        switch (other.tag)
        {
            case "ATCK":
                StartCoroutine( TakeDamage(P.damage));
                print(P.damage);
                break;
            case "ATCK2":
              StartCoroutine(TakeDamage(P.damage / 2));
                print(P.damage / 2);
                break;
            case "ATCK3":

                break;
        }
    }
    public IEnumerator TakeDamage(float amount)
    {
        hp -= amount;
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.3f);
        GetComponent<Renderer>().material.color = thisColor;

        //   GetComponent<ParticleSystem>().Play();
    }
}