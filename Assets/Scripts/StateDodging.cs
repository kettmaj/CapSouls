using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDodging : PlayerState {
    /// <summary>
    /// where the player is currently
    /// </summary>
    public Vector3 currentPOS;
    /// <summary>
    /// where the player will be at the end of their roll
    /// </summary>
    public Vector3 newPOS;
    public float dodgeCurrent = 0;
    public const float DODGETOTAL = .5f;
    /// <summary>
    /// the player object
    /// </summary>
    float dodgeDistance = 4f;
    /// <summary>
    /// variable for the LERP used to smooth character dodge movement
    /// </summary>
    public float smoothFactor = 2;
    /// <summary>
    /// where the player is currently
    /// </summary>
    public Vector3 dodgeStart;
    /// <summary>
    /// where the player will be at the end of their roll
    /// </summary>
    public Vector3 dodgeEnd;
    public float dodgeProgress;

    // Use this for initialization
    public override void OnBegin(ThirdPersonMovement controller)
    {
        base.OnBegin(controller);
        dodgeStart = controller.transform.position;
        dodgeEnd = dodgeStart + controller.currentVelocity.normalized * dodgeDistance;
    }

    // Update is called once per frame
    override public PlayerState Update()
    {
        
        //put behavior here
        dodgeProgress = dodgeCurrent / DODGETOTAL;
        controller.pawn.transform.position = Vector3.Lerp(dodgeStart, dodgeEnd, dodgeProgress);

        //put transitions here
        //if transtion condition is true, return new state

        if (dodgeCurrent >= DODGETOTAL)
        {
            return new StateWalking();
        }
        dodgeCurrent += Time.deltaTime;
        return null;
    }
    
}
