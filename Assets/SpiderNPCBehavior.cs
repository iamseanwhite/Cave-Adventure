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
    }

    void Update()
    {
        var pc = GameObject.Find("Melvin");
        if (!playerSeen && Vector3.Distance(pc.transform.position, this.transform.position) < 20)
        {
            animator.Play("Jump");
            SpiderMovement.isAttacking = true;
            var cm = GameObject.Find("Melvin");
            var tf = cm.transform;
            this.gameObject.transform.LookAt(tf);
            playerSeen = true;
        }

        if (playerSeen)
        {
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
            _playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
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