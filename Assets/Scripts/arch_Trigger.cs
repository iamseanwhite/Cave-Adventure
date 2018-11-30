using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arch_Trigger : MonoBehaviour {
    public GameObject[] rollers;
    public GameObject hurt;
    public float xSpeed=0;
    public float ySpeed=0;
    public float ballspeed;
    // Use this for initialization
    void Start() {
       // rollers = GameObject.FindGameObjectsWithTag("Rocks");
        //InvokeRepeating("Roll", 1, 1); 
	}
	
    	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //xSpeed = xSpeed * .0002f;
        ySpeed = ySpeed +1f;

        Debug.Log(other.name + "Has Entered");

        if (other.name == "Melvin")
        {
         
                rollers = GameObject.FindGameObjectsWithTag("Rock");
                InvokeRepeating("Roll", 1, 1);
        }
        // myTransform.position = Vector3.up * Time.time;
    }

    void Roll()
    {
        Debug.Log("Roll");
        GameObject rock = rollers[Random.Range(0, rollers.Length)];
        Rigidbody body= rock.GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.None;
        body.AddTorque(new Vector3(xSpeed, 0, ySpeed)* ballspeed*Time.deltaTime);
        //rock.transform.position = Vector3.forward ;
        //Instantiate(hurt,rock.transform.position,Quaternion.identity);
    }
}
