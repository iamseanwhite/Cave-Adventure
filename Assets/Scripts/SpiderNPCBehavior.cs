using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SpiderNPCBehavior : MonoBehaviour
{
    #region Singleton
    public static SpiderNPCBehavior instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    Animator animator;
    public bool playerSeen = false;
    public bool dead = false;
    public float smoothTime = 3.0f;
    public Vector3 smoothVelocity = Vector3.zero;
    public PlayerHealth _playerHealth;
    //public GameObject uiGameObject;
    public IslandSpiderHealth spiderHealth;
    public SpiderMovement spiderMovement;
    //public Animation spiderAnim;
    float timedAttack = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        spiderHealth = GetComponent<IslandSpiderHealth>();
        spiderMovement = GetComponent<SpiderMovement>();
        _playerHealth = GameObject.Find("HealthBorder").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        var pc = GameObject.Find("Melvin");


        if (dead)
        {
            return;
        }

        if (spiderHealth.currentHealth == 0)
        {
            dead = true;
            Debug.Log("Dying now");
            spiderMovement.SetIsDieToTrue();
            animator.SetBool("IsAttacking", false);
            animator.SetBool("SeesMelvin", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsDead", true);
            //spiderAnim["Die"].wrapMode = WrapMode.ClampForever;
            //animator.Play("Die");
        }

        if (!dead && Vector3.Distance(pc.transform.position, this.transform.position) < 2)
        {
            if (timedAttack <= 0f)
            {
                timedAttack = 2f;
            }

            if (timedAttack > 0f)
            {
                timedAttack -= Time.deltaTime;
                if (timedAttack <= 0f)
                {
                    Debug.Log("Fight happening.");
                    _playerHealth = GameObject.Find("HealthBorder").GetComponent<PlayerHealth>();
                    spiderMovement.SetIsAttackingToTrue();
                    animator.SetBool("IsAttacking", true);
                    animator.Play("Attack");
                    _playerHealth.TakeHit(10);
                }
            }
        }


        if (!dead && !playerSeen && Vector3.Distance(pc.transform.position, this.transform.position) < 20)
        {
            Debug.Log("in first if statement.");
            animator.SetBool("SeesMelvin", true);
            spiderMovement.SetIsAttackingToTrue();
            var cm = GameObject.Find("Melvin");
            animator.Play("Walk");
            var tf = cm.transform;
            this.gameObject.transform.LookAt(tf);
            playerSeen = true;
        }

        if (!dead && playerSeen)
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

    /*void OnColliderEnter(Collider col)
    {
        if (col.gameObject.name == "Melvin")
        {
            Debug.Log("In Collision function");
            Debug.Log("Collision happening.");
            _playerHealth = GameObject.Find("Melvin").GetComponent<PlayerHealth>();
            spiderMovement.SetIsAttackingToTrue();
            animator.SetBool("IsAttacking", true);
            animator.Play("Attack");
            _playerHealth.TakeHit(10);
        }
    }*/
}