using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveScript : MonoBehaviour {

    public GameObject mainCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(mainCamera.transform);
	}
}
