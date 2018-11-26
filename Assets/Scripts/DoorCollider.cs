using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Door Collision Detected");

        if (other.gameObject.name == "Girl")
        {
            GameObject.Find("Girl").GetComponent<Cutscene>().GiveKey();
        }
    }
}
