using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScroling : MonoBehaviour
{
    public float xRand, yRand;
    public Material rend;

    void Start()
    {
         xRand = Random.Range(.1f, 1);
         yRand = Random.Range(.1f, 1);

        rend = GetComponent<MeshRenderer>().material;

        rend.mainTextureOffset = new Vector2(xRand,yRand);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
