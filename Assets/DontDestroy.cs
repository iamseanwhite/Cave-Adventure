using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {

    GameObject mainCamera;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().name == "Island")
        {
            //transform.position = new Vector3(150, 165, 10);
            //GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        }

        //else
        //{
        //    GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        //    transform.position = new Vector3(-70, 78, -191);
        //    mainCamera = allObjects.FirstOrDefault(x => x.name.Equals("Camera"));
        //    mainCamera.transform.position = new Vector3(-.0735f, 2.549f, -2.3754f);
        //}
        //GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;

    }
	// Update is called once per frame
	void Update () {
		
	}
}
