using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowScript : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    Transform player;
    private Animator anim;
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;
    NavMeshAgent _navMeshAgent;
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    private int current;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
         GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void OnLevelWasLoaded()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void SetDestination()
    {
        if (player != null)
        {

            //Vector3 targetVector = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            Vector3 targetVector = player.transform.position;
            _navMeshAgent.SetDestination(targetVector);

        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("isDead")) {
            _navMeshAgent.SetDestination(this.transform.position);
        }
        else if(Vector3.Distance(player.position, this.transform.position) < 20 && angle < 40)
            {
                direction.y = 0;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
                if (direction.magnitude > 2)
                {
                    // this.transform.Translate(0, 0, 0.05f);
                    anim.SetBool("isRunning", true);
                    SetDestination();
                    speed = 2;
                    anim.SetBool("isAttacking", false);
                    anim.SetBool("isTaunting", false);
                }
                else
                {
                    _navMeshAgent.SetDestination(this.transform.position);
                    anim.SetBool("isAttacking", true);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isTaunting", false);
                    anim.SetBool("isRunning", false);

                    PlayerHealth.instance.TakeHit(0);


                    if (PlayerHealth.instance.currentHealth == 0)
                    {
                        Debug.Log("You Died");
                        FindObjectOfType<GameManager>().EndGame();

                    }
                }

            }
            else
            {
                /*  if (transform.position != target[current].position)
                  {
                      Vector3 dir = target[current].position - this.transform.position;
                      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dir), 0.1f);

                      Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                      GetComponent<Rigidbody>().MovePosition(pos);
                  }
                  else current = (current + 1) % target.Length;

                  anim.SetBool("isTaunting", false);
                  anim.SetBool("isWalking", true);
                  anim.SetBool("isAttacking", false);*/


                anim.SetBool("isWalking", false);
                SetDestination();
                anim.SetBool("isTaunting", false);
                anim.SetBool("isRunning", true);
                anim.SetBool("isAttacking", false);

                if (isWandering == false)
                {
                    StartCoroutine(Wander());

                }
                if (isRotatingRight == true)
                {
                    transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
                }
                if (isRotatingLeft == true)
                {
                    transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
                }
                if (isWalking == true)
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                }
            }
        }
    

        IEnumerator Wander()
        {
            int rotTime = Random.Range(1, 3);
            int rotateWait = Random.Range(1, 3);
            int rotateLorR = Random.Range(0, 3);
            int walkWait = Random.Range(1, 3);
            int walkTime = Random.Range(1, 5);

            isWandering = true;

            yield return new WaitForSeconds(walkWait);
            isWalking = true;
            yield return new WaitForSeconds(walkTime);
            isWalking = false;
            anim.SetBool("isTaunting", true);
            yield return new WaitForSeconds(rotateWait);
            if (rotateLorR == 1)
            {
                isRotatingRight = true;
                yield return new WaitForSeconds(rotTime);
                isRotatingRight = false;
            }
            if (rotateLorR == 2)
            {
                isRotatingLeft = true;
                yield return new WaitForSeconds(rotTime);
                isRotatingLeft = false;
            }
            isWandering = false;
        }
    }
