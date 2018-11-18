using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    private GameObject character;
    public float radius;
    private bool isFocus = false;

	// Use this for initialization
	void Start () {
        character = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(this.transform.position, character.transform.position);
		if (distance < radius && Input.GetKeyDown(KeyCode.E))
        {
            isFocus = true;
            Interact();
        }
	}

    public virtual void Interact()
    {

    }
}
