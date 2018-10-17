using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Orbits the camera around the player (in tangent with FollowTarget to keep it a set distance away
/// </summary>
public class OrbitalCamera : MonoBehaviour {
    /// <summary>
    /// how quickly the camera moves horizontally
    /// </summary>
    public float lookSensitivityX = 5;
    /// <summary>
    /// how quickly the camera moves vertically
    /// </summary>
    public float lookSensitivityY = 5;
    /// <summary>
    /// if the horizontal camera movement is inverted
    /// </summary>
    public bool invertLookX = false;
    /// <summary>
    /// if the vertical camera movement is inverted
    /// </summary>
    public bool invertLookY = false;
    /// <summary>
    /// the upward and downward direction of the camera
    /// </summary>
    float pitch = 0;
    /// <summary>
    /// the side to side direction of the camera
    /// </summary>
    float yaw = 0;

    
	
	/// <summary>
    /// everything the camera should do every frame
    /// </summary>
	void Update () {
        LookAround();
	}
    /// <summary>
    /// Allows the player object to look around using either mouse or right thumbstick (xbox controller)
    /// </summary>
    private void LookAround()
    {
        //mouse controls
        float lookX = Input.GetAxis("Mouse X") * (invertLookX ? -1 : 1) * lookSensitivityX;
        float lookY = Input.GetAxis("Mouse Y") * (invertLookY ? -1 : 1) * lookSensitivityY;
        //thumbstick controls
        float Th = Input.GetAxis("Right Thumbstick X") * (invertLookX ? -1 : 1) * lookSensitivityX;
        float Tv = Input.GetAxis("Right Thumbstick Y") * (invertLookY ? -1 : 1) * lookSensitivityY;
        
        //mouse camera movement
        pitch += lookY;
        pitch = Mathf.Clamp(pitch, 5, 80);
        yaw += lookX;
        //thumbstick camera movement
        pitch += Tv;
        pitch = Mathf.Clamp(pitch, 5, 80);
        yaw += Th;

        transform.localEulerAngles = new Vector3(pitch, yaw, 0);
    }
}
