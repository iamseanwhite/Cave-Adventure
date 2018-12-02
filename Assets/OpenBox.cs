using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    static Animator anim;
    public GameObject fireworks;
    // Use this for initialization

    //#region Singleton
    //public static OpenBox instance;

    //void Awake()
    //{
    //    instance = this;
    //    Debug.Log("in openbox awake");

    //}
    //#endregion

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnTriggerEnter(Collider other)
    //{

    //    if (other.name == "Melvin" && Inventory.instance.haskey == true)
    //    {
    //        //Inventory.instance.isNextToChest = true;
    //        anim.SetBool("isOpen", true);
    //        fireworks.SetActive(!fireworks.activeSelf);
    //    }
    //}
    
    public void OpenTheBox()
    {
        Debug.Log("In OpenTheBox");
        anim.SetBool("isOpen", true);
        fireworks.SetActive(!fireworks.activeSelf);        
    }

}
