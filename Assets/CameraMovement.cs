using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float HorizontalSpeed = 2.0f;
    public float VerticalSpeed = 2.0f;
    public GameObject Character;
    public Terrain terrain;

    //public float yaw = 0.0f;
    //public float pitch = 0.0f;
    //private Transform characterTransformOld;

    // Use this for initialization
    void Start ()
    {
        //characterTransformOld = Character.transform;
        this.transform.LookAt(Character.transform);
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void LateUpdate()
    {
        if (!Input.GetButton("Fire1"))
        {
            Cursor.visible = false;
            //rotation
            this.transform.LookAt(Character.transform, Vector3.up);

            //vertical revolution
            var path = Character.transform.position - this.transform.position;
            Vector3 perpendicular = Vector3.Cross(path, Vector3.up);
            this.transform.RotateAround(Character.transform.position, perpendicular, (Input.GetAxis("Mouse Y")));

            //horizonal revolultion
            this.transform.RotateAround(Character.transform.position, Vector3.up, (Input.GetAxis("Mouse X")));

            //zoom in
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && (Vector3.Distance(this.transform.position, Character.transform.position) > 3))
                this.transform.position = (this.transform.position + Character.transform.position) / 2;

            //zoom out
            if (Input.GetAxis("Mouse ScrollWheel") < 0f && (Vector3.Distance(this.transform.position, Character.transform.position) < 50))
                this.transform.position += (this.transform.position - Character.transform.position);
        }

        else
        {
            Cursor.visible = true;
        }
        //characterTransformOld = Character.transform;

        //yaw += HorizontalSpeed * Input.GetAxis("Mouse X");
        //pitch -= VerticalSpeed * Input.GetAxis("Mouse Y");

        //if(Input.GetAxis("Mouse X") > 1 || Input.GetAxis("Mouse Y") > 1)
        //    transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);       
    }
}
