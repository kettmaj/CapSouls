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
    /// how often the player can dodge, depends on the reset at the transition out of StateDodging
    /// </summary>
    public float dodgeCooldown = 0;
    /// <summary>
    /// the player's current velocity to be used in movement updates
    /// </summary>
    public Vector3 currentVelocity = Vector3.zero;
    /// <summary>
    /// The player's maximum stamina, consumed by various actions, regerated after not doing actions for a certain period of time
    /// </summary>
    public float stamina = 100;
    /// <summary>
    /// the time that needs to pass until the player's stamina begins to regenerate
    /// </summary>
    private const float STAMINACOOLDOWN = 1.2f;
    /// <summary>
    /// how much time has passed since the last stamina-consuming action (to a maximum of 2 as to not have an infinitely tracking variable
    /// </summary>
    private float lastAction = 0;
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
        
        dodgeCooldown -= Time.deltaTime;
        
        
        
    }
    /// <summary>
    /// Changing between current player state and what is passed in
    /// if null passed in, player remains in current state
    /// if new state is passed in, call current state's "OnEnd" method
    /// once state has been changed, call new state's "OnBegin" method
    /// </summary>
    /// <param name="newState"></param>
    private void SwitchPlayerState(PlayerState newState)
    {
        if (newState == null) return;
        if (newState != null) state.OnEnd();
        state = newState;
        state.OnBegin(this);
        print(state);
    }

    
    

}
