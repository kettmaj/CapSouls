using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDodging : MonoBehaviour {
    /// <summary>
    /// where the player is currently
    /// </summary>
    public Vector3 currentPOS;
    /// <summary>
    /// where the player will be at the end of their roll
    /// </summary>
    public Vector3 newPOS;
    /// <summary>
    /// the player object
    /// </summary>
    CharacterController pawn;
    /// <summary>
    /// contains the distance (new location) for the player object
    /// </summary>
    Vector3 dodgeDistance = new Vector3(0, 0, 3);
    /// <summary>
    /// variable for the LERP used to smooth character dodge movement
    /// </summary>
    public float smoothFactor = 2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
