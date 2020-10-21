using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressTool : MonoBehaviour
{
    [Header("W press")]
    public GameObject wPressedKey;

    [Header("A press")]
    public GameObject aPressedKey;

    [Header("S press")]
    public GameObject sPressedKey;

    [Header("D press")]
    public GameObject dPressedKey;

    [Header("LMB press")]
    public GameObject lmbPressedKey;

    [Header("Q press")]
    public GameObject qPressedKey;

    [Header("E press")]
    public GameObject ePressedKey;

    void Start()
    {
        
    }

    void Update()
    {
        #region W key
        if (Input.GetKey(KeyCode.W))
        {
            wPressedKey.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            wPressedKey.SetActive(false);
        }
        #endregion

        #region A key
        if (Input.GetKey(KeyCode.A))
        {
            aPressedKey.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            aPressedKey.SetActive(false);
        }
        #endregion

        #region S key
        if (Input.GetKey(KeyCode.S))
        {
            sPressedKey.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            sPressedKey.SetActive(false);
        }
        #endregion

        #region D key
        if (Input.GetKey(KeyCode.D))
        {
            dPressedKey.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            dPressedKey.SetActive(false);
        }
        #endregion

        #region LMB key
        if (Input.GetButton("Fire1"))
        {
            lmbPressedKey.SetActive(true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            lmbPressedKey.SetActive(false);
        }
        #endregion

        #region Q key
        if (Input.GetKey(KeyCode.Q))
        {
            qPressedKey.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            qPressedKey.SetActive(false);
        }
        #endregion

        #region E key
        if (Input.GetKey(KeyCode.E))
        {
            ePressedKey.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            ePressedKey.SetActive(false);
        }
        #endregion
    }
}
