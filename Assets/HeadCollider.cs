using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   /* void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Rock1" || other.gameObject.name == "Rock2")
        {
            Debug.Log(other.gameObject.name + " hit player");
            PlayerHealth.instance.TakeHit(9);

            
        }
        }
*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Rock1" || other.name == "Rock2")
        {
            Debug.Log(other.name + " hit player");
            PlayerHealth.instance.TakeHit(9);

        }
    }
}
