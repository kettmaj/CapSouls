using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWalking : MonoBehaviour {

    /// <summary>
    /// get reference for camera position to orientate the player to
    /// </summary>
    public OrbitalCamera orbitCam;
    /// <summary>
    /// the player's movement speed (affects final velocity)
    /// </summary>
    public float speed = 5;
    /// <summary>
    /// the player object
    /// </summary>
    CharacterController pawn;
    // Use this for initialization
    void Start () {
        pawn = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        MoveAround();
    }
    /// <summary>
    /// Allows the player object to move in an direction based on axis' set up already by Unity
    /// </summary>
    private void MoveAround()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");


        //rotate to orient with camera
        if (v != 0 || h != 0)
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
