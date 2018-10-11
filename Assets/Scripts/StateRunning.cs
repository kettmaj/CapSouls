using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// In this state the player can move at a faster speed 
/// Transitions:
/// -To Walk by releasing Shift
/// -To Dodge by pressing Space
/// </summary>
public class StateRunning : PlayerState
{
    /// <summary>
    /// how long the player has been running
    /// </summary>
    private float timeinState = 0;
    /// <summary>
    /// the longest time a player can be running and still dodge
    /// </summary>
    private const float dodgeTimer = 0.5f;
    /// <summary>
    /// the player's movement speed (affects final velocity)
    /// </summary>
    public float speed = 8;
    /// <summary>
    /// the player's renderer element material
    /// </summary>
    Material mat;
    /// <summary>
    /// the code that runs upon initialization of the state
    /// </summary>
    /// <param name="controller"></param>
    public override void OnBegin(ThirdPersonMovement controller)
    {
        base.OnBegin(controller);
        damageMult = 1.2f;
        mat = controller.GetComponent<Renderer>().material;
        mat.color = Color.blue;
        controller.lastAction = 0;

    }
    /// <summary>
    /// everything the player can do while in the running state
    /// </summary>
    /// <returns></returns>
    override public PlayerState Update()
    {
        //put behavior here
        controller.stamina -= 0.4f;
        timeinState += Time.deltaTime;
        if(controller.stamina > 0)
        {
            MoveAround();

        }
        else
        {
            return new StateWalking();
        }


        //put transitions here
        //if transtion condition is true, return new state
        if (Input.GetMouseButtonDown(0))
        {
            return new StateAttacking();
        }

        //if the player releases the dodge button in less than 0.5 seconds, send to dodge. Otherwise returned to walking
        if (Input.GetButtonUp("Dodge"))
        {
            if(timeinState <= dodgeTimer && controller.dodgeCooldown <= 0)
            {
                return new StateDodging();
            }
            else return new StateWalking();
        }
        //b is joystick button 1
        if (Input.GetButtonUp("B Button"))
        {
            if (timeinState <= dodgeTimer && controller.dodgeCooldown <= 0)
            {
                return new StateDodging();
            }
            else return new StateWalking();

        }

        return null;
    }
    /// <summary>
    /// what the player should do as they exit this state
    /// </summary>
    public override void OnEnd()
    {
        base.OnEnd();
        controller.didAction = true;
        controller.lastAction = 0;
    }
    /// <summary>
    /// Allows the player object to move in an direction based on axis' set up already by Unity
    /// using both WASD and the left thumbstick on an Xbox One Controller
    /// </summary>
    private void MoveAround()
    {

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (v != 0 || h != 0)
        {
            float camYaw = controller.orbitCam.transform.localEulerAngles.y;
            controller.transform.eulerAngles = new Vector3(0, camYaw, 0);
        }

        controller.currentVelocity = Vector3.zero;
        controller.currentVelocity += controller.transform.forward * v * (speed * 70)* Time.deltaTime;
        controller.currentVelocity += controller.transform.right * h * (speed * 70) * Time.deltaTime;

        controller.pawn.SimpleMove(controller.currentVelocity);
    }
}
