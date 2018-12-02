using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    #region Singleton
    public static SpiderMovement instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    // Variables
    public static bool isDie = false; 
    public static bool isAttacking = false;

    public float speed = 5;
    public float directionChangeInterval = 1;
    public float maxHeadingChange = 10;

    Animator spiderAnimator;

    CharacterController controller;
    float heading;
    Vector3 targetRotation;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);
 
        StartCoroutine(NewHeading());
    }

    void Update()
    {
        if (!isDie && !isAttacking)
        {
            Debug.Log("In SpiderMovement script -- !isDie && !isAttacking.");
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
            var forward = transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
    }

    IEnumerator NewHeading()
    {
        while (true)
        {
            NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void NewHeadingRoutine()
    {
        var floor = transform.eulerAngles.y - maxHeadingChange;
        var ceil = transform.eulerAngles.y + maxHeadingChange;
        heading = Random.Range(floor, ceil);
        targetRotation = new Vector3(0, heading, 0);
    }

    public void SetIsDieToTrue()
    {
        isDie = true;
    }

    public void SetIsAttackingToTrue()
    {
        isAttacking = true;
    }

}
