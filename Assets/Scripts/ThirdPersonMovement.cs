using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Keeping track of the player's current state and allosw for camera movement. Keeps track of the player's stats
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
    /// the player's maximum heath, reduced by taking damage and restored by health potions
    /// </summary>
    public float Health = 100;
    /// <summary>
    /// the time that needs to pass until the player's stamina begins to regenerate
    /// </summary>
    private const float STAMINACOOLDOWN = 1.5f;
    /// <summary>
    /// how much time has passed since the last stamina-consuming action (to a maximum of 2 as to not have an infinitely tracking variable
    /// </summary>
    public float lastAction = 0;
    /// <summary>
    /// abstract player state for state machine
    /// </summary>
    private PlayerState state;
    /// <summary>
    /// boolean tracking if the player did a stamina-consuming action
    /// </summary>
    public bool didAction = false;
    /// <summary>
    /// tracking how much current stamina the player has versus maximum stamina
    /// </summary>
    private Vector3 staminaPercentage;
    private Vector3 healthPercentage;
    /// <summary>
    /// stamina bar UI element
    /// </summary>
    public Image StaminaBar;
    /// <summary>
    /// refence to the Health bar UI element
    /// </summary>
    public Image HPBar;
    /// <summary>
    /// refence to the sword box attached to the player object
    /// </summary>
    public GameObject sword;
    /// <summary>
    /// refence to the shield box attached to the player object
    /// </summary>
    public GameObject shield;


    void Start () {
        state = new StateWalking();
        pawn = GetComponent<CharacterController>();
        SwitchPlayerState(new StateWalking());
	}
	
	void Update () {
        staminaPercentage = new Vector3(stamina/100, 1, 1);
        StaminaBar.rectTransform.localScale = staminaPercentage;
        stamina = Mathf.Clamp(stamina, 0, 100);
        healthPercentage = new Vector3(Health / 100, 1, 1);
        HPBar.rectTransform.localScale = healthPercentage;
        Health = Mathf.Clamp(Health, 0, 100);

        if (state != null)
        {
            PlayerState newState = state.Update();

            SwitchPlayerState(newState);
        }
        if (stamina < 100)
        {
            StaminaRegen();
        }
        dodgeCooldown -= Time.deltaTime;
        if(didAction == true) lastAction += Time.deltaTime;

    }
    private void StaminaRegen()
    {
        if(lastAction >= STAMINACOOLDOWN )
        {
                stamina += 0.2f;
            didAction = false;

        }
        if (stamina >= 100)
        {
            lastAction = 0;

        }
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
        
    }
    




}
