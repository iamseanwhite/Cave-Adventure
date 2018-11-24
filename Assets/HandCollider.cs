using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollider : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if (other.CompareTag("Tiger"))
        {
            Debug.Log("You damaged the Tiger");
            TigerHealth.instance.TakeHit(5);
            Debug.Log("Tiger Health: " + TigerHealth.instance.currentHealth);
        }
    }
}
