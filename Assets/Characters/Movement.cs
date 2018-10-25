using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class Movement : MonoBehaviour
{
    //CharacterController characterController;

    //public float speed = 6.0f;
    //public float jumpSpeed = 8.0f;
    //public float gravity = 20.0f;

    public float x = 0;
    public float z = 0;

    //private Vector3 moveDirection = Vector3.zero;

    private Animator animator;
    private Rigidbody rigidBody;

    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        animator.SetFloat("Run", z);
        animator.SetFloat("Turn", x, 1f, Time.deltaTime * 5f);


        //if (z != 0)
            transform.Translate(x *.09f, 0, z * .09f);
        //    rigidBody.velocity = transform.forward * z;
    
    }
}