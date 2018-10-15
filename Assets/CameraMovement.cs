using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float HorizontalSpeed = 2.0f;
    public float VerticalSpeed = 2.0f;
    public GameObject Character;
    public Terrain terrain;

    public float yaw = 0.0f;
    public float pitch = 0.0f;
    private Transform characterTransformOld;

    // Use this for initialization
    void Start ()
    {
        characterTransformOld = Character.transform;
        this.transform.LookAt(Character.transform);
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {

        //if (Character.transform.position == characterTransformOld.position && Character.transform != characterTransformOld) { 
            this.transform.LookAt(Character.transform);
        //}

        this.transform.RotateAround(Character.transform.position, Character.transform.position, -(Input.GetAxis("Mouse Y")));
        this.transform.RotateAround(Character.transform.position, Vector3.up, (Input.GetAxis("Mouse X")));

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            this.transform.position = (this.transform.position + Character.transform.position) / 2;

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            this.transform.position += (this.transform.position - Character.transform.position);

        characterTransformOld = Character.transform;

        //yaw += HorizontalSpeed * Input.GetAxis("Mouse X");
        //pitch -= VerticalSpeed * Input.GetAxis("Mouse Y");

        //if(Input.GetAxis("Mouse X") > 1 || Input.GetAxis("Mouse Y") > 1)
        //    transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);       
    }
}
