using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float rotateVelocity;
    //float forwardInput, turnInput;
    public float x = 0;
    public float z = 0;
    public GameObject myCamera;
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
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {            
            SceneManager.LoadScene(0);
        }
            
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {           
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {           
            SceneManager.LoadScene(2);
        }
        

        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            animator.SetBool("Attack", false);
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            animator.SetFloat("Run", z, .05f, Time.deltaTime );
            animator.SetFloat("Turn", x, 1f, Time.deltaTime * 10 );

            //transform.rotation *= Quaternion.AngleAxis(x, Vector3.up);
            transform.Rotate(Vector3.up * rotateVelocity * x * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!Input.GetButton("Fire3"))
            {
                Debug.Log(!Input.GetButton("Fire1"));
                animator.SetBool("Attack", true);
                isAttacking = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHealth.instance.TakeHit(9);
        }

        if (PlayerHealth.instance.currentHealth == 0)
        {
            Debug.Log("You Died");
        }

    }

    void FixedUpdate()
    {        

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

            //transform.Rotate(Vector3.up * rotateVelocity * x);
        }

        
    }

    void FootstepEvent()
    {
        footstep.pitch = UnityEngine.Random.Range(.9f, 1.2f);
        footstep.volume = UnityEngine.Random.Range(.75f, 1f);
        //footstep.volume -= .03f * (Vector3.Distance(myCamera.transform.position, this.transform.position));
        footstep.Play();
    }
}
