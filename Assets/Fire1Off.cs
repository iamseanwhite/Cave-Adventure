using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1Off : MonoBehaviour {
    
   // public ParticleSystem particle;
    public GameObject[] torches;
    public GameObject Wall;
    public GameObject torch;
    static Animator anim;

    // Use this for initialization
    void Start () {
        anim = Wall.GetComponent<Animator>();
        torches[0].GetComponent<ParticleSystem>().enableEmission = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "Has Entered");
        ParticleSystem ps = torches[1].GetComponent <ParticleSystem>();

        var em =ps.emission;

        if (other.name == "Melvin" && Inventory.instance.hasTorch == true)
        {
          //  torches = GameObject.FindGameObjectsWithTag("Torch1");
            InvokeRepeating("StopFire", 1, 1);

            if (em.enabled==true)
            {
                anim.SetBool("isFallingSlow", true);
            }

            
        }
    }

    void StopFire()
    {
        Debug.Log("Fire");
        torches[0].GetComponent<ParticleSystem>().enableEmission = true;
}
}
