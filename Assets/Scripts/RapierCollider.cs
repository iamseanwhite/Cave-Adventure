using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapierCollider : MonoBehaviour {

    Animator PlayerAnimator;

    void Start()
    {
        PlayerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if (other.CompareTag("Tiger") && PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-L3"))
        {
            Debug.Log("You damaged the Tiger");
            TigerHealth.instance.TakeHit(15);
            Debug.Log("Tiger Health: " + TigerHealth.instance.currentHealth);
        }
    }
}
