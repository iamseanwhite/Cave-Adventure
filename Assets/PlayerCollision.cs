using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    //public ThirdPersonCharacter movement;
	// Use this for initialization
	void OnTriggerEnter(Collider other)
    {
        if(other.name == "SpikesCollider")
        {
            FindObjectOfType<GameManager>().EndGame();
           
            
        }
    }
}
