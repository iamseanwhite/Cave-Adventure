using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollider : MonoBehaviour {

    Animator PlayerAnimator;
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
            TigerHealth.instance.TakeHit(5);
            Debug.Log("Tiger Health: " + TigerHealth.instance.currentHealth);
        }
    }
}
