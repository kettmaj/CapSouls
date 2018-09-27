using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour {

    public float lookSensitivityX = 5;
    public float lookSensitivityY = 5;
    public bool invertLookX = false;
    public bool invertLookY = false;

    float pitch = 0;
    float yaw = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        LookAround();
	}

    private void LookAround()
    {
        float lookX = Input.GetAxis("Mouse X") * (invertLookX ? -1 : 1) * lookSensitivityX;
        float lookY = Input.GetAxis("Mouse Y") * (invertLookY ? -1 : 1) * lookSensitivityY;

        float Th = Input.GetAxis("Right Thumbstick X") * (invertLookX ? -1 : 1) * lookSensitivityX;
        float Tv = Input.GetAxis("Right Thumbstick Y") * (invertLookY ? -1 : 1) * lookSensitivityY;

        //transform.Rotate(0, lookX, 0);

        pitch += Tv;
        pitch = Mathf.Clamp(pitch, 5, 80);

        yaw += Th;

        transform.localEulerAngles = new Vector3(pitch, yaw, 0);
    }
}
