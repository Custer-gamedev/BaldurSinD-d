using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorLightChange : MonoBehaviour
{
    public string sNname;
    public Color lightcolor;
    void Start()
    {
       sNname = SceneManager.GetActiveScene().name.ToString();
        if (sNname == "FloorTwo")
        {
            GetComponent<Light>().color = lightcolor;
        }
    }
}
