using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    static Animator anim;
    public GameObject fireworks;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Melvin" && Inventory.instance.haskey==true)
        {

            anim.SetBool("isOpen", true);
            fireworks.SetActive(!fireworks.activeSelf);
        }
    }

}
