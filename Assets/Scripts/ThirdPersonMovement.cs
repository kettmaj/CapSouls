using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// moving the player along the X and Z axises in any direction
/// </summary>
public class ThirdPersonMovement : MonoBehaviour {
    /// <summary>
    /// the player's movement speed (affects final velocity)
    /// </summary>
    public float speed = 5;
    /// <summary>
    /// get reference for camera position to orientate the player to
    /// </summary>
    public OrbitalCamera orbitCam;
    /// <summary>
    /// the player object
    /// </summary>
    CharacterController pawn;
    /// <summary>
    /// how often the player can dodge, depends on the reset called in the dodge function
    /// </summary>
    float dodgeCooldown = 0;
    /// <summary>
    /// contains the distance (new location) for the player object
    /// </summary>
    Vector3 dodgeDistance = new Vector3(0, 0, 3);
    /// <summary>
    /// variable for the LERP used to smooth character dodge movement
    /// </summary>
    public float smoothFactor = 2;
    /// <summary>
    /// where the player is currently
    /// </summary>
    public Vector3 currentPOS;
    /// <summary>
    /// where the player will be at the end of their roll
    /// </summary>
    public Vector3 newPOS;
    
    void Start () {
        pawn = GetComponent<CharacterController>();
        currentPOS = pawn.transform.position;
        newPOS = currentPOS;
	}
	
	void Update () {
        MoveAround();
        dodgeCooldown -= Time.deltaTime;
        if (currentPOS != newPOS)
        {
            pawn.transform.position = Vector3.Lerp(currentPOS, newPOS, Time.deltaTime * smoothFactor);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dodgeCooldown <= 0)
        {
            Dodge();
            dodgeCooldown = 2;
        }
        //b is joystick button 1

        if (Input.GetButtonDown("B Button"))
        {
            if(dodgeCooldown <= 0)
            {
                Dodge();
                dodgeCooldown = 2;
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
        currentPOS = pawn.transform.position;
        newPOS = currentPOS += dodgeDistance;
        //causes the player to dodge in the direction they are facing
        //pawn.transform.position = Vector3.Lerp(pawn.transform.position, pawn.transform.position + dodgeDistance, Time.deltaTime * smoothFactor);
        //pawn.transform.Translate(dodgeDistance);
        print("Dodge");
    }

}
