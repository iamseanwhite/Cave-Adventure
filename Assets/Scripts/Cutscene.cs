using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cutscene : MonoBehaviour {

    Animator animator;
    GameObject whereToGo, House, Melvin, Door, keyInHand;
    public Item key;

    bool beenToHouse = false;
    bool voiceOverTriggered = false;

	// Use this for initialization
	void Start () {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        keyInHand = allObjects.FirstOrDefault(x => x.CompareTag("KeyInHand"));

        animator = GetComponent<Animator>();
        House = GameObject.FindWithTag("RunToPoint");
        Melvin = GameObject.Find("Melvin");
        Door = GameObject.Find("PhantomDoor");
    }

	// Update is called once per frame
	void Update ()
    {
        LookTowards(whereToGo);

        if (beenToHouse == true && Vector3.Distance(transform.position, Melvin.transform.position) < 2)
        {
            animator.SetBool("ReachedMelvin", true);

            if (voiceOverTriggered == false)
            {
                GetComponent<AudioSource>().Play();
                voiceOverTriggered = true;
                TakeKey();
            }


        }
    }

    public void RunScene()
    {
        animator.SetBool("TigerIsGone", true);
        GameObject.Find("GirlCanvas").SetActive(false);
        whereToGo = House;
    }

    public void WalkToDoor()
    {
        beenToHouse = true;
        animator.SetBool("ReachedHouse", true);
        whereToGo = Door;
    }

    public void GiveKey()
    {
        if (beenToHouse == true)
            whereToGo = Melvin;
    }

    public void TakeKey()
    {
        //Destroy(keyInHand);
        //Inventory.instance.Add(key);
    }

    void LookTowards(GameObject destination)
    {
        var targetRotation = Quaternion.LookRotation(destination.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
    }
}
