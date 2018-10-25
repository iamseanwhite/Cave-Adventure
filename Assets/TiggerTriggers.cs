using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerTriggers : MonoBehaviour {

    public GameObject character;

    Animator animator;
    Rigidbody rigidBody;
	
    // Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(character.transform.position, this.transform.position) < 40)
        {
            animator.SetBool("IsClose", true);

            Vector3 movement;
           
            movement = transform.forward * 5;

            movement.y = rigidBody.velocity.y;
            rigidBody.velocity = movement;
        }
	}
}
