using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PerspectiveScript : MonoBehaviour {

    GameObject mainCamera;
	// Use this for initialization
	void Start () {
		
	}
	
    void OnLevelWasLoaded()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        mainCamera = allObjects.FirstOrDefault(x => x.name.Equals("Camera"));
    }

	// Update is called once per frame
	void Update () {
        transform.LookAt(mainCamera.transform);
	}
}
