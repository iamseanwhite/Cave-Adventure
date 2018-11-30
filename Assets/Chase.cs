using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour {

    // Use this for initialization

    public Transform player;
    private Animator anim;
    public float speed;
    NavMeshAgent _navMeshAgent;


   // [SerializeField]
   // Transform _destination;

    

    void Start () {
        anim = this.GetComponent<Animator>();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
      


    }
   private void SetDestination()
    {
        if (player != null)
        {

            //Vector3 targetVector = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
           Vector3 targetVector = (player.transform.position);
            _navMeshAgent.SetDestination(targetVector);

        }
    }

    // Update is called once per frame
    void Update () {

        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(player.position, this.transform.position) < 10)
        {
            
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
           // Vector3 pos = Vector3.MoveTowards(transform.position,player.position, speed * Time.deltaTime);

            anim.SetBool("isIdle", false);
            if(direction.magnitude > 2)
            {
                Debug.Log("Run");
                anim.SetBool("isIdle", false);
                anim.SetBool("isWalking", true);
                speed = 10;
                SetDestination();
                //this.transform.Translate(player.position);                
                anim.SetBool("isAttacking", false);
            }
            else
            {
                _navMeshAgent.SetDestination(this.transform.position);
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);

                PlayerHealth.instance.TakeHit(2);

                if (PlayerHealth.instance.currentHealth == 0)
                {
                    Debug.Log("You Died");
                    FindObjectOfType<GameManager>().EndGame();
                }

            }

        }else
        {
            
            anim.SetBool("isIdle", true);          
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
	}
}
