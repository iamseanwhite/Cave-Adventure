using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutAttack : MonoBehaviour {

    public Rigidbody coconut;
    public float throwDistance = 2000000000f;
    public float time2Die = 4.0f;

    GameObject coconutHold;

    void Update()
    {
        int count = MelvinManager.currentCoconutCount;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (count >= 1)
            {
                ThrowCoconut();
            }
        }
    }

    public void ThrowCoconut()
    {
        Rigidbody coconutClone = (Rigidbody)Instantiate(coconut, transform.position, transform.rotation);
        coconutClone.gameObject.SetActive(true);
        coconutClone.useGravity = true;
        coconutClone.constraints = RigidbodyConstraints.None;
        coconutClone.AddForce(transform.forward * throwDistance);
        Destroy(coconutClone.gameObject, time2Die);
        MelvinManager.currentCoconutCount = MelvinManager.currentCoconutCount - 1;
    }
}
