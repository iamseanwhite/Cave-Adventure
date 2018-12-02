using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollider : MonoBehaviour {

    Animator PlayerAnimator;
    public GameObject torch;
    public GameObject rapier;

    void Start()
    {
        PlayerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");

        if (other.CompareTag("Tiger") && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3") && !rapier.activeSelf)
        {
            Debug.Log("You damaged the Tiger");
            TigerHealth.instance.TakeHit(9);
            Debug.Log("Tiger Health: " + TigerHealth.instance.currentHealth);
        }
        else if(other.name== "Big Spider" && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3") )
        {
            Debug.Log("You damaged the Big Spider");
            SpiderHealth.instance.TakeHit(20);
            Debug.Log("Big Spider: " + SpiderHealth.instance.currentHealth);
        }
        else if(other.name=="Skeleton 1" && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
            {
            Debug.Log("You damaged the Skeleton");
            SkeletonHealth.instance.TakeHit(20);
            Debug.Log("Skeleton: " + SkeletonHealth.instance.currentHealth);
        }
        else if (other.name == "Skeleton 2" && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            Debug.Log("You damaged the Skeleton");
            Skeleton2Health.instance.TakeHit(25);
            Debug.Log("Skeleton: " + Skeleton2Health.instance.currentHealth);
        }
        else if (other.name == "Skeleton 3" && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            Debug.Log("You damaged the Skeleton");
            Skeleton3Health.instance.TakeHit(20);
            Debug.Log("Skeleton: " + Skeleton3Health.instance.currentHealth);
        }
        else if (other.name == "Skeleton 4" && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            Debug.Log("You damaged the Skeleton");
            Skeleton4Health.instance.TakeHit(20);
            Debug.Log("Skeleton: " + Skeleton4Health.instance.currentHealth);
        }
        else if (other.name == "mini Spider (1)" && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            Debug.Log("You damaged the Skeleton");
            Spider1Health.instance.TakeHit(20);
            Debug.Log("mini Spider (1) " + Spider1Health.instance.currentHealth);
        }
        else if (other.name == "mini Spider (2)" && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            Debug.Log("You damaged the Skeleton");
            Spider2Health.instance.TakeHit(20);
            Debug.Log("mini Spider (2) " + Spider2Health.instance.currentHealth);
        }
        else if (other.name == "mini Spider (3)" && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            Debug.Log("You damaged the Skeleton");
            Spider3Health.instance.TakeHit(20);
            Debug.Log("mini Spider (3) " + Spider3Health.instance.currentHealth);
        }
        else if (other.name == "mini Spider (4)" && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            Debug.Log("You damaged the Skeleton");
            Spider4Health.instance.TakeHit(20);
            Debug.Log("mini Spider (4) " + Spider4Health.instance.currentHealth);
        }
        else if (other.CompareTag("spider") && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            Debug.Log("You damaged the spider");
            IslandSpiderHealth.instance.TakeDamage(10);
            Debug.Log("spider: " + IslandSpiderHealth.instance.currentHealth);
        }
    }
}
