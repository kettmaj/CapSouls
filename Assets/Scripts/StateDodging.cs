using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player is moving a set distance determined on their last movement vector
/// Transitions
/// -Back to Walking once the dodge is completed
/// </summary>
public class StateDodging : PlayerState {
    /// <summary>
    /// where the player is currently
    /// </summary>
    public Vector3 currentPOS;
    /// <summary>
    /// where the player will be at the end of their roll
    /// </summary>
    public Vector3 newPOS;
    /// <summary>
    /// Tracking how much time has passed since the player started to dodge
    /// </summary>
    public float dodgeCurrent = 0;
    /// <summary>
    /// Total time for the dodge animation to occur
    /// </summary>
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
    /// <summary>
    /// Variable for use in LERP transform, how close the dodgeCurrent is to being equal to DODGETOTAL (from 0 to 1)
    /// </summary>
    public float dodgeProgress;
    /// <summary>
    /// the player's renderer element material
    /// </summary>
    Material mats;

    /// <summary>
    /// the code that runs upon initialization of the state
    /// </summary>
    /// <param name="controller"></param>
    public override void OnBegin(ThirdPersonMovement controller)
    {
        damageMult = 0;
        base.OnBegin(controller);
        controller.lastAction = 0;

        dodgeStart = controller.transform.position;
        dodgeEnd = dodgeStart + controller.currentVelocity.normalized * dodgeDistance;
        mats = controller.GetComponent<Renderer>().material;
        mats.color = Color.green;
        controller.stamina -= 20;

    }
    /// <summary>
    /// everything the player does in the duration of the dodge
    /// in this case, moving a set distance based on player's last forward vector
    /// </summary>
    /// <returns></returns>
    override public PlayerState Update()
    {

        //put behavior here
        dodgeProgress = dodgeCurrent / DODGETOTAL;
        if(controller.stamina > 0)
        {
            Dodge();
        }

        //put transitions here
        //if transtion condition is true, return new state

        if (dodgeCurrent >= DODGETOTAL)
        {
            controller.dodgeCooldown = 0.2f;
            return new StateWalking();
        }
        dodgeCurrent += Time.deltaTime;
        return null;
    }
    /// <summary>
    /// moves the player a set distance based on their last forward vector
    /// </summary>
    private void Dodge()
    {
        controller.pawn.transform.position = Vector3.Lerp(dodgeStart, dodgeEnd, dodgeProgress);
    }

    /// <summary>
    /// what the player should do as they exit this state
    /// </summary>
    public override void OnEnd()
    {
        base.OnEnd();
        controller.didAction = true;

    }

}
//Idea, make all combat record hits, and only do damage based on state multiplier (dodge state would be x0 damage)