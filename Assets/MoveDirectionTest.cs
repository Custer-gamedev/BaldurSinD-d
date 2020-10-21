using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class MoveDirectionTest : MonoBehaviour
{
    public Vector3 Direction;
    public float Horz, Vert;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Horz = Input.GetAxis("Horizontal");
        Vert = Input.GetAxis("Vertical");

        Direction = new Vector3(Horz, 0, Vert);
        transform.position = transform.parent.position + new Vector3(1 * Direction.x, 0, 1 * Direction.z);
    }
}
