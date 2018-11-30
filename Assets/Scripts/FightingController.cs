using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingController : MonoBehaviour {

    public GameObject Tiger;
    private Animator tigerAnimator;
    private Animator animator;
    int randomNumber = 2;

    // Use this for initialization
    void Start () {
		tigerAnimator = Tiger.GetComponent<Animator>();
        animator = GetComponent<Animator>();
        animator.SetBool("IsBeingChased", true);        
    }
	
	// Update is called once per frame
	void Update () {

        this.transform.LookAt(Tiger.transform, Vector3.up);

        if (tigerAnimator.GetCurrentAnimatorStateInfo(0).IsName("hit") ||
            tigerAnimator.GetCurrentAnimatorStateInfo(0).IsName("hit 0"))
        {
            if (Vector3.Distance(Tiger.transform.position, this.transform.position) < 2)
            { 
                Random.InitState(System.DateTime.Now.Millisecond);
                animator.SetBool("GetHit2", true);
                randomNumber = Random.Range(1, 2);
            }
            else
            {
                animator.SetBool("GetHit2", false);
            }
        }
        else
        {
            animator.SetBool("GetHit2", false);
        }

    }
}
