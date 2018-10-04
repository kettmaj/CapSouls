using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// moving the player along the X and Z axises in any direction
/// </summary>
public class ThirdPersonMovement : MonoBehaviour {
    
    /// <summary>
    /// get reference for camera position to orientate the player to
    /// </summary>
    public OrbitalCamera orbitCam;
    /// <summary>
    /// the player object
    /// </summary>
    public CharacterController pawn;
    /// <summary>
    /// how often the player can dodge, depends on the reset called in the dodge function
    /// </summary>
    public float dodgeCooldown = 0;
    public Vector3 currentVelocity = Vector3.zero;
    
    /// <summary>
    /// abstract player state for state machine
    /// </summary>
    private PlayerState state;


    void Start () {
        state = new StateWalking();
        pawn = GetComponent<CharacterController>();
        SwitchPlayerState(new StateWalking());
	}
	
	void Update () {
        
        if (state != null)
        {
            PlayerState newState = state.Update();

            SwitchPlayerState(newState);
        }

        //MoveAround();
        dodgeCooldown -= Time.deltaTime;
        /*
        if (DodgeStart != DodgeEnd)
        {
            pawn.transform.position = Vector3.Lerp(DodgeStart, DodgeEnd, Time.deltaTime * smoothFactor);
        }
        */
        
        
    }

    private void SwitchPlayerState(PlayerState newState)
    {
        if (newState == null) return;
        if (newState != null) state.OnEnd();
        state = newState;
        state.OnBegin(this);
        print(state);
    }

    
    

}
