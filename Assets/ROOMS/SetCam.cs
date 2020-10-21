using UnityEngine;

public class SetCam : MonoBehaviour
{
    int cols;
    public Transform otherCamPos;
    float timer = 2;

    public bool Colliding()
    {
        if (cols == 0)
            return false;

        else
            return true;
    }

    public void Update()
    {
        bool isColliding = Colliding();
        GameObject parent = this.transform.parent.gameObject;
        if (isColliding == false)
        {
            if (timer < 0)
            {
                Destroy(parent);
            }
            else
                timer -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Room")
        {
            otherCamPos = other.gameObject.transform.Find("CamHolder");
            cols++;
        }
    }
    
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Boss Room")
        {
            transform.parent.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}