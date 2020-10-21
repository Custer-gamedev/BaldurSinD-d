using UnityEngine;

public class Generation : MonoBehaviour {
    private Room roomTemplate;
    public int oDirection;
    private int roomRand;
    private bool spawned;

    private void Awake () {
        roomTemplate = GameObject.FindGameObjectWithTag ("RoomMaster").GetComponent<Room> ();
        Invoke ("Spawn", .1f);
    }

    void Spawn () {

        if (roomTemplate.maxAllowedSpawn <= 10) {
            if (spawned == false) {
                switch (oDirection) {
                    case 1:
                        if (roomTemplate.maxAllowedSpawn < 5)
                            roomRand = Random.Range (0, roomTemplate.bottomRooms.Length - 1);
                        else
                            roomRand = Random.Range (0, roomTemplate.bottomRooms.Length);

                        Instantiate (roomTemplate.bottomRooms[roomRand], transform.position, roomTemplate.bottomRooms[roomRand].transform.rotation);
                        roomTemplate.maxAllowedSpawn++;
                        break;
                    case 2:
                        if (roomTemplate.maxAllowedSpawn < 5)
                            roomRand = Random.Range (0, roomTemplate.bottomRooms.Length - 1);
                        else
                            roomRand = Random.Range (0, roomTemplate.bottomRooms.Length);

                        Instantiate (roomTemplate.topRooms[roomRand], transform.position, roomTemplate.topRooms[roomRand].transform.rotation);
                        roomTemplate.maxAllowedSpawn++;
                        break;
                    case 3:
                        if (roomTemplate.maxAllowedSpawn < 5)
                            roomRand = Random.Range (0, roomTemplate.bottomRooms.Length - 1);
                        else
                            roomRand = Random.Range (0, roomTemplate.bottomRooms.Length);

                        Instantiate (roomTemplate.leftRooms[roomRand], transform.position, roomTemplate.leftRooms[roomRand].transform.rotation);
                        roomTemplate.maxAllowedSpawn++;
                        break;
                    case 4:
                        if (roomTemplate.maxAllowedSpawn < 5)
                            roomRand = Random.Range (0, roomTemplate.bottomRooms.Length - 1);
                        else
                            roomRand = Random.Range (0, roomTemplate.bottomRooms.Length);

                        Instantiate (roomTemplate.rightRooms[roomRand], transform.position, roomTemplate.rightRooms[roomRand].transform.rotation);
                        roomTemplate.maxAllowedSpawn++;
                        break;
                }
                spawned = true;
            }
        }
    }
    private void OnTriggerEnter (Collider other) {
        if (other.tag == "Room" || other.tag == "Spawner") {
            Destroy (gameObject);
            spawned = true;
        }
    }
}