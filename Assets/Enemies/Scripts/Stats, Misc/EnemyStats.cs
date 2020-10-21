using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float hp, damage;
    public bool souls;
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
            if (souls == true)
            {

                GameObject bossRoom = GameObject.FindGameObjectWithTag("BossRoom");
                GetComponent<Collider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(true);
                transform.position = Vector3.Lerp(transform.position, bossRoom.transform.position, .1f * Time.deltaTime);
                Destroy(gameObject, 3f);
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