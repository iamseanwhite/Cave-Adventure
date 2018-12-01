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
    AudioSource footstepSand, footstepWater, footstepDock;
  
        
    float timeStart = 0;
    float timeEnd = 0;
    bool isAttacking = false;
    float waterLevel;
    bool isCave = false;
    //Quaternion rotation;

    // Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

        var audioSources = GetComponents<AudioSource>();
        footstepSand = audioSources[0];
        footstepWater = audioSources[1];
        footstepDock = audioSources[2];
        waterLevel = SceneManager.GetActiveScene().name == "Island" ? 78.6f : 9f;
        //DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded()
    {
        animator.SetBool("IsDead", false);
        transform.position = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        
        PlayerHealth.instance.TakeHit(-100);

        if (SceneManager.GetActiveScene().name == "Island")
        {            
            waterLevel = 78.6f;
        }
        else 
        {
            isCave = true;
        }
        //else
        //{
        //    waterLevel = 9f;
        //}
        
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
               /*
                for (int x =0; x < enemies.Length; x++)
                {
                    Vector3 direction = enemies[x].transform.position - this.transform.position;
                    float angle = Vector3.Angle(direction, this.transform.forward);

                    if (Vector3.Distance(this.transform.position, enemies[x].transform.position) < 20 && angle < 40)
                    {
                        if (direction.magnitude > 2)
                        {

                           // SpiderHealth.instance.TakeHit(2);


                          //  if (SpiderHealth.instance.currentHealth == 0)
                            //{
                          //      Debug.Log("You Died");
                           //     FindObjectOfType<GameManager>().EndGame();
                            //}
                        }
                    }

                }*/
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHealth.instance.TakeHit(0);
        }

        if (PlayerHealth.instance.currentHealth == 0)
        {
            Debug.Log("You Died");
        }

        
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Rock1" || other.name == "Rock2")
        {
            PlayerHealth.instance.TakeHit(2);
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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, .3f))
        {
            var floortag = hit.collider.gameObject.tag;
            Debug.Log(floortag);

            if (transform.position.y <= waterLevel && !isCave)
            {
                footstepWater.pitch = UnityEngine.Random.Range(.95f, 1.2f);
                footstepWater.volume = UnityEngine.Random.Range(.1f, .35f);
                footstepWater.Play();

            }
            if (floortag == "Terrain")
            {
                footstepSand.pitch = UnityEngine.Random.Range(.9f, 1.2f);
                footstepSand.volume = UnityEngine.Random.Range(.75f, 1f);
                footstepSand.Play();

            }

            else if (floortag == "Dock")
            {
                footstepDock.pitch = UnityEngine.Random.Range(.8f, .9f);
                footstepDock.volume = UnityEngine.Random.Range(.3f, .4f);
                footstepDock.Play();

            }
        }
    }
}
