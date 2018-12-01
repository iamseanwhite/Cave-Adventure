using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().name == "Island")
        {
            transform.position = new Vector3(150, 162, 10);
        }

    }
	// Update is called once per frame
	void Update () {
		
	}
}
