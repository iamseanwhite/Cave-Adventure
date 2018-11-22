using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.05f;

    public bool LookAtPlayer = false;

    public bool RotateAroundPlayer = true;

    public float RotationSpeed = 5.0f;

    // Use this for initialization
	void Start () {
        _cameraOffset = transform.position - PlayerTransform.position;
	}

    //LateUpdate is called after Update methods
    void LateUpdate()
    {
        if(RotateAroundPlayer)
        {
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            _cameraOffset = camTurnAngle * _cameraOffset;
        }
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotateAroundPlayer)
            transform.LookAt(PlayerTransform);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
