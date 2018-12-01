using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class TiggerTriggers : MonoBehaviour {

     GameObject Melvin;
     GameObject Girl;
     GameObject RunawayPoint;

    Animator animator;
    Rigidbody rigidBody;
    Vector3 tigerMovemement;
    Collider girlCollider, tigerCollider;
    GameObject mainCamera;

    bool isLookingAtMelvin = false;
    bool healthIsTooLow = false;

    void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        //mainCamera = Camera.main;
    }

    void OnLevelWasLoaded()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        Melvin = GameObject.FindWithTag("Player");
        mainCamera = allObjects.FirstOrDefault(x => x.name.Equals("Camera"));
        Girl = allObjects.FirstOrDefault(x => x.name.Equals("Girl"));
        RunawayPoint = GameObject.FindWithTag("TigerRunawayPoint");
        
    }
            

    void Update ()
    {

        //when Melvin is close enough
        if (Vector3.Distance(Melvin.transform.position, this.transform.position) < 40)
        {
            if (!healthIsTooLow)
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

            if (TigerHealth.instance.currentHealth < 5)
            {
                animator.SetBool("HealthTooLow", true);

                //while account for gravity
                tigerMovemement.y = rigidBody.velocity.y;
                rigidBody.velocity = tigerMovemement;

                tigerMovemement = transform.forward * 5f;

                healthIsTooLow = true;
                RunAway();
            }
        }


    }

    void RunAway()
    {
        var targetRotation = Quaternion.LookRotation(RunawayPoint.transform.position - transform.position);
        //tigerMovemement = transform.forward * 3;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
        Girl.GetComponent<Animator>().SetBool("IsBeingChased", false);
    }

    void DamageEvent()
    {
        if (isLookingAtMelvin == true)
        {
            PlayerHealth.instance.TakeHit(10);
            //mainCamera.GetComponent<CameraMotionBlur>().enabled = true;
        }

        else
        {
            GirlHealth.instance.TakeHit(5);
        }
    }


}
