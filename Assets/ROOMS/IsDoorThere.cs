using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDoorThere : MonoBehaviour
{
  private void OnTriggerEnter(Collider other) {
      if(other.tag != "Door"){
          Destroy(transform.parent.gameObject);
      }
  }
}
