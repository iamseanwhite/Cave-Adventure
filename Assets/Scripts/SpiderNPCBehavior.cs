using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderNPCBehavior : MonoBehaviour
{

    Animator animator;
    public bool playerSeen = false;
    public float smoothTime = 3.0f;
    public Vector3 smoothVelocity = Vector3.zero;
    public PlayerHealth _playerHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Walk");
    }

    void Update()
    {
        var pc = GameObject.Find("Melvin");
        if (!playerSeen && Vector3.Distance(pc.transform.position, this.transform.position) < 20)
        {
            Debug.Log("in first if statement.");
            //animator.SetBool("SeesMelvin", true);
            //animator.Play("Jump");
            //SpiderMovement.isAttacking = true;
            var cm = GameObject.Find("Melvin");
            animator.Play("Walk");
            SpiderMovement.isAttacking = true;
            var tf = cm.transform;
            this.gameObject.transform.LookAt(tf);
            playerSeen = true;
        }

        if (playerSeen)
        {
            Debug.Log("in playerseen if statement.");
            var cm = GameObject.Find("Melvin");
            var tf = cm.transform;
            this.gameObject.transform.LookAt(tf);

            animator.Play("Walk");

            transform.position = Vector3.SmoothDamp(transform.position, tf.position,
                ref smoothVelocity, smoothTime);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("In Collision function");
            Debug.Log("Collision happening.");
            _playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
            animator.SetBool("IsAttacking", true);
            animator.Play("Attack");
            _playerHealth.TakeHit(10);
        }
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSecondsRealtime(4);
        animator.Play("Die");
        Destroy(this.gameObject, 4);
    }
}