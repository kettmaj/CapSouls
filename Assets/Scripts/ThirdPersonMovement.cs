using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonMovement : MonoBehaviour {
    public float speed = 5;
    //get reference for camera position to orientate to line up
    public OrbitalCamera orbitCam;
    CharacterController pawn;
    float dodgeCooldown = 0;
    Vector3 dodgeDistance = new Vector3(0, 0, 3);
    public float smoothFactor = 2;

	// Use this for initialization
	void Start () {
        pawn = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveAround();
        dodgeCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dodgeCooldown <= 0)
        {
            Dodge();
            dodgeCooldown = 0;
        }
        //b is joystick button 1

        if (Input.GetButtonDown("B Button"))
        {
            if(dodgeCooldown <= 0)
            {
                Dodge();
                dodgeCooldown = 0;
            }
            
        }
        
    }
    /// <summary>
    /// Allows the player object to move in an direction based on axis' set up already by Unity
    /// </summary>
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
    /// <summary>
    /// Translates the player object forward the distance stored in dodgeDidstance (along their Z axis)
    /// </summary>
    private void Dodge()
    {
        //causes the player to dodge in the direction they are facing
        pawn.transform.position = Vector3.Lerp(pawn.transform.position, pawn.transform.position + dodgeDistance, Time.deltaTime * smoothFactor);
        pawn.transform.Translate(dodgeDistance);
        print("Dodge");
    }

}
