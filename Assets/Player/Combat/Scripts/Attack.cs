using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    [Header("Basic Attack")]
    public float CoolDownTime, AtkDelay;
    public GameObject BasicHitBox, CD;
    public Vector3 Offset; // offset of attack from the player

    [Header("Second Attack")]
    public float CoolDownTime2, AtkDelay2;
    public GameObject SecondHitBox, TargetIndicator, CD2, AxeOnMap;
    public GameObject ATCK2canvas;
    public bool Charching = true, GotAxe = true, SpawnArrow = true;

    [Header("Third Attack")]
    public float CoolDownTime3, AtkDelay3;
    public GameObject ThirdHitBox, CD3;

    public bool Attacking;
    public GameObject Player;
    [Header("Movement")]
    float halvedSpeed;

    private void Start()
    {
        Player = this.gameObject;
    }

    void Update()
    {
        #region BasicAttack
        if (AtkDelay >= 0) AtkDelay -= Time.deltaTime * 0.1f;
        else
        {
            CD.SetActive(false);
        }
        CD.GetComponentInChildren<Text>().text = (AtkDelay * 10).ToString();
        if (Input.GetButton("Fire1") && GameObject.FindGameObjectWithTag("ATCK") == null && GameObject.FindGameObjectWithTag("ATCK3") == null && GameObject.Find("arrow(Clone)") == null)
        {
            if (AtkDelay <= 0)
            {
                Attacking = true;
               halvedSpeed = Player.GetComponent<PlayerStats>().speed / 2;
                Player.GetComponent<PlayerStats>().speed = halvedSpeed;
                Instantiate(BasicHitBox, (transform.position + Offset) + transform.forward, Quaternion.Euler(0, 0, 0), this.transform);
                CD.SetActive(true);
                AtkDelay = CoolDownTime;
            }
        }
        #endregion

        #region SecondAttack

        AxeOnMap.SetActive(!GotAxe);
        if (GotAxe)
        {
            if (AtkDelay2 >= 0)
            {
                AtkDelay2 -= Time.deltaTime * 0.1f;
            }
            else
            {
                CD2.SetActive(false);
            }
            CD2.GetComponentInChildren<Text>().text = (AtkDelay2 * 10).ToString();

            //creates indicator
            if (Input.GetButton("Fire2") && AtkDelay2 <= 0 && GameObject.FindGameObjectWithTag("ATCK") == null && GameObject.FindGameObjectWithTag("ATCK3") == null)
            {
                    Attacking = true;
                    ATCK2canvas = GameObject.FindGameObjectWithTag("ATCK2canvas");

                if (SpawnArrow)
                {
                    Instantiate(TargetIndicator, transform.position + transform.forward, Quaternion.Euler(0, 0, 0), ATCK2canvas.transform);
                    SpawnArrow = false;
                }
            }

            //creates throwing axe
            if (Input.GetButtonUp("Fire2"))
            {
                if (AtkDelay2 <= 0 && GameObject.FindGameObjectWithTag("ATCK") == null && GameObject.FindGameObjectWithTag("ATCK3") == null )
                {
                    Attacking = false;
                    Instantiate(SecondHitBox, transform.position + transform.forward, Quaternion.Euler(0, 0, 0), null);
                    AtkDelay2 = CoolDownTime2;
                    GotAxe = false;

                }
            }
        }     
        
        #endregion
        
        #region ThridAttack
        if (AtkDelay3 >= 0) AtkDelay3 -= Time.deltaTime * 0.1f;
        else
        {
            CD3.SetActive(false);
        }
        CD3.GetComponentInChildren<Text>().text = (AtkDelay3 * 10).ToString();
        if (Input.GetButtonDown("Fire3") && GameObject.FindGameObjectWithTag("ATCK") == null && GameObject.FindGameObjectWithTag("ATCK3") == null && GameObject.Find("arrow(Clone)") == null)
        {
            if (AtkDelay3 <= 0)
            {
                Attacking = true;
               GameObject tempAss = Instantiate(ThirdHitBox, transform.position, Quaternion.Euler(0, 0, 0), this.transform);
               Destroy(tempAss, 1f);
                CD3.SetActive(true);
                AtkDelay3 = CoolDownTime3;
            }
        }
        #endregion       
    }
}
