using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2 : MonoBehaviour {

    public float rotateVelocity = 1;
    //float forwardInput, turnInput;
    public float x = 0;
    public float z = 0;

    private Animator animator;
    Rigidbody rigidBody;
    AudioSource footstep;

    float timeStart = 0;
    float timeEnd = 0;
    bool isAttacking = false;
    //Quaternion rotation;
	
    // Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        footstep = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        //if (x > .1 || z > .1) animator.SetBool("Attack", false);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SceneManager.LoadScene(1);

        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            animator.SetBool("Attack", false);
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            animator.SetFloat("Run", z, .05f, Time.deltaTime );
            animator.SetFloat("Turn", x, 1f, Time.deltaTime * 5 );
        
        

            transform.rotation *= Quaternion.AngleAxis(rotateVelocity * x , Vector3.up);
        }

    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack", true);
            isAttacking = true;
        }

        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            Vector3 movement;
            if (z > 0) { 
                movement = transform.forward * 5 * z;
                //InvokeRepeating("PlayFootstep", .1f, 1.0f);
            }
            else
                movement = transform.forward * 2 * z;
        
            movement.y = rigidBody.velocity.y;
            rigidBody.velocity = movement;
        }

        
    }

    //void PlayFootstep()
    //{
    //    footstep.Play();
    //}
}
