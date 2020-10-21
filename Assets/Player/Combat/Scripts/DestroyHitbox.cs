using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyHitbox : MonoBehaviour
{
    [SerializeField]
    float DurationOfAtk = 1;
    private float halvedSpeed;
    float DestroyTimer;
    void Awake()
    {
        halvedSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().speed;
    }
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        DestroyTimer += Time.deltaTime * DurationOfAtk;

        if (DestroyTimer >= 1)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().speed += halvedSpeed;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>().Attacking = false;
            Destroy(gameObject);           
        }
    }
}
