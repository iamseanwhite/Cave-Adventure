using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour {

    public float rotateVelocity = 1;
    //float forwardInput, turnInput;
    public float x = 0;
    public float z = 0;

    private Animator animator;
    Rigidbody rigidBody;
    //Quaternion rotation;
	
    // Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        animator.SetFloat("Run", z);
        animator.SetFloat("Turn", x, 1f, Time.deltaTime * 5f);
     
        transform.rotation *= Quaternion.AngleAxis(rotateVelocity * x , Vector3.up);
        
    }

    void FixedUpdate()
    {
        Vector3 movement = transform.forward * 5 *z;
        movement.y = rigidBody.velocity.y;
        rigidBody.velocity = movement;
    }
}
