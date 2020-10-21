using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TESTattackArrow : MonoBehaviour
{
    public Camera ATCKCam;
    public LayerMask GroundLayer;
    public float GrowScale, ArrowScale;
    public GameObject AxeLandingMarker;
    public float Lenght;

    void Start()
    {
        ATCKCam = GameObject.FindGameObjectWithTag("ATCK2camera").GetComponent<Camera>();
    }

    void Update()
    {
        GetComponent<RectTransform>().position = (GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, -0.49f, 0));

        RaycastHit Hit;

        if(Physics.Raycast(ATCKCam.ScreenToWorldPoint(Input.mousePosition), ATCKCam.transform.forward, out Hit, Mathf.Infinity, GroundLayer))
        {
            
            Debug.DrawRay(ATCKCam.ScreenToWorldPoint(Input.mousePosition), ATCKCam.transform.forward * Hit.distance, Color.cyan);
            Debug.DrawLine(transform.position, Hit.point, Color.magenta);

            transform.rotation = Quaternion.LookRotation(Vector3.up, Hit.point - transform.position);           

            RectTransform Rt = GetComponent<RectTransform>();
            Lenght = Vector3.Distance(Hit.point, transform.position);
            if (Lenght > 10)
            {
                Lenght = 10;
            }
            
            Rt.sizeDelta = new Vector2(50, Lenght * 52.5f);       
        }


        if (GameObject.FindGameObjectsWithTag("ATCK2axeMarker").Length == 0)
        {
            Instantiate(AxeLandingMarker, Hit.point, Quaternion.identity);
        }   
            GameObject.FindGameObjectWithTag("ATCK2axeMarker").transform.position = Vector3.ClampMagnitude(Hit.point - transform.position, Lenght) + transform.position;

        if (Input.GetButtonUp("Fire2"))
        {            
            Destroy(this.gameObject);
        }
    }
}
