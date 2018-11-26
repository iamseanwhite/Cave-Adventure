using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Girl")
        {
            GameObject.Find("Girl").GetComponent<Cutscene>().WalkToDoor();
        }
    }
}
