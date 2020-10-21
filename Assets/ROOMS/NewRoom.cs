using UnityEngine;
using UnityEngine.AI;

public class NewRoom : MonoBehaviour {
    private Room rooms;
    private Transform spawns;
    private void Start () {
        rooms = GameObject.FindGameObjectWithTag ("RoomMaster").GetComponent<Room> ();
        spawns = transform.Find ("Spawns");
        rooms.roomsList.Add (this.gameObject);
        rooms.surfaces.Add(this.GetComponent<NavMeshSurface>());
        
    }

    public void Update () {

        if (this.transform.name == "Boss Room" && spawns != null || this.transform.name == "Treasure Room" && spawns != null) {
            Destroy (spawns.gameObject);
        }
    }

    public void OnCollisionEnter (Collision collision) {
        if (collision.transform.tag == "Player" && transform.name != "Treasure Room") {
            transform.GetComponentInChildren<SpawnEnemy> ().Invoke ("Spawn", 0);
        } else
            transform.GetComponentInChildren<SpawnTreasure> ().Invoke ("Spawn", 0);

        if (collision.transform.tag == "Player" && spawns != null) {
            GetComponentInChildren<SpawnEnemy> ().Invoke ("Spawn", 0);
        }

        if (collision.transform.tag == "Room") {
            Destroy (gameObject);
        }

    }
}