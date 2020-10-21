using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCollidingRoom : MonoBehaviour
{
    public Room room;
    private void Start() {
        room = GameObject.FindGameObjectWithTag("RoomMaster").GetComponent<Room>();
    }
     /*private void OnTriggerEnter(Collider col) {
           if (room.bossSpawn == true) {

            col.transform.parent.gameObject.GetComponent<Material> ().color = Color.red;
            print ("Made something red" + col.transform.name);

        } 
    }*/
}
