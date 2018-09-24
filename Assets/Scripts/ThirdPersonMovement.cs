using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour {
    public float speed = 5;
    //get reference for camera position to orientate to line up
    public OrbitalCamera orbitCam;
    CharacterController pawn;

	// Use this for initialization
	void Start () {
        pawn = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveAround();
	}

    private void MoveAround()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //rotate to orient with camera
        if (v!= 0 || h != 0)
        {
            float camYaw = orbitCam.transform.localEulerAngles.y;
            transform.eulerAngles = new Vector3(0, camYaw, 0);
        }

        Vector3 velocity = Vector3.zero;
        velocity += transform.forward * v * speed;
        velocity += transform.right * h * speed;

        pawn.SimpleMove(velocity);
    }
}
