using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class TiggerTriggers : MonoBehaviour {

    public GameObject Melvin;
    public GameObject Girl;

    Animator animator;
    Rigidbody rigidBody;
    Vector3 tigerMovemement;
    Collider girlCollider, tigerCollider;
    Camera mainCamera;

    bool isLookingAtMelvin = false;
    
    void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }
	
	void Update () {

        //when Melvin is close enough
        if (Vector3.Distance(Melvin.transform.position, this.transform.position) < 40)
        {
            animator.SetBool("IsClose", true);

            if (Vector3.Distance(Melvin.transform.position, this.transform.position) > 5)
            {
                if (Vector3.Distance(Girl.transform.position, this.transform.position) > 3)
                {
                    animator.SetBool("TooFarToAttack", true);
                    animator.SetBool("Attack1", false);
                    //animator.SetBool("Walk", false);
                }
                else
                {
                    animator.SetBool("TooFarToAttack", false);                    
                }
                //start running towards girl               
                var targetRotation = Quaternion.LookRotation(Girl.transform.position - transform.position);
                //tigerMovemement = transform.forward * 3;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
               
            }

            else
            {
                //run towards melvin
                if (Vector3.Distance(Melvin.transform.position, this.transform.position) < 2)
                {
                    animator.SetBool("Attack1", true);
                    animator.SetBool("TooFarToAttack", false);
                    isLookingAtMelvin = true;
                }
                else
                { 
                    animator.SetBool("Attack1", false);
                    animator.SetBool("TooFarToAttack", true);                    
                }
                var targetRotation = Quaternion.LookRotation(Melvin.transform.position - transform.position);
                //tigerMovemement = transform.forward * 3;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
            }

            //while account for gravity
            tigerMovemement.y = rigidBody.velocity.y;
            rigidBody.velocity = tigerMovemement;

            //and when they meet, start attacking her
            if (Vector3.Distance(Girl.transform.position, this.transform.position) < 2)
            {
                //animator.SetBool("Walk", true);
                Random.InitState(System.DateTime.Now.Millisecond);
                int randomNumber = Random.Range(1, 2);
                animator.SetBool("Attack" + randomNumber, true);
                isLookingAtMelvin = false;
                //animator.SetBool("TooFarToAttack", false);                
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("hit"))
            {
                tigerMovemement = transform.forward * .1f;                                
            }
            else
            {
                tigerMovemement = transform.forward * 5f;
            }                        
            
        }
	}

    void DamageEvent()
    {
        if (isLookingAtMelvin == true)
        { 
            PlayerHealth.instance.TakeHit(10);
            //mainCamera.GetComponent<CameraMotionBlur>().enabled = true;
        }
    }


}
