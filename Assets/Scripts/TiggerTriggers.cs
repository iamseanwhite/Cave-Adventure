using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerTriggers : MonoBehaviour {

    public GameObject Melvin;
    public GameObject Girl;

    Animator animator;
    Rigidbody rigidBody;
    Vector3 tigerMovemement;
    Collider girlCollider, tigerCollider;
    
    void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();      
    }
	
	void Update () {

        //when Melvin is close enough
        if (Vector3.Distance(Melvin.transform.position, this.transform.position) < 40)
        {
            //start running towards girl
            animator.SetBool("IsClose", true);
            this.transform.LookAt(Girl.transform, Vector3.up);
            tigerMovemement = transform.forward * 5;
            
            //while account for gravity
            tigerMovemement.y = rigidBody.velocity.y;
            rigidBody.velocity = tigerMovemement;

            //and when they meet, start attacking
            if (Vector3.Distance(Girl.transform.position, this.transform.position) < 3)
            {
                Random.InitState(System.DateTime.Now.Millisecond);
                int randomNumber = Random.Range(1, 2);
                animator.SetBool("Attack" + randomNumber, true);
            }
        }
	}


}
