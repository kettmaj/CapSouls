using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// In this state the player can move at a moderate speed 
/// Transitions:
/// -To Sprint by holding Shift
/// -To Dodge by pressing Space
/// </summary>
public class StateWalking : PlayerState {

    /// <summary>
    /// the player's movement speed (affects final velocity)
    /// </summary>
    public float speed = 5;
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
        damageMult = 1;
        mat = controller.GetComponent<Renderer>().material;
        mat.color = Color.white;

    }
    /// <summary>
    /// the things that the player can do while in the walking state
    /// </summary>
    /// <returns></returns>
    override public PlayerState Update()
    {
        //put behavior here
        MoveAround();
        //put transitions here
        //if transtion condition is true, return new state
        if (Input.GetButtonDown("Dodge"))
        {
            return new StateRunning();
        }
        //b is joystick button 1
        if (Input.GetButtonDown("B Button"))
        {
            return new StateRunning();
        }
        //player clicked left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            return new StateAttacking();
        }
        return null;
    }
    
    /// <summary>
    /// Allows the player object to move in an direction based on axis' set up already by Unity
    /// using both WASD and the left thumbstick on an Xbox One Controller
    /// </summary>
    private void MoveAround()
    {
        
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        //get player's forward vetor and align camera to that vector on movement
        if (v != 0 || h != 0)
        {
            float camYaw = controller.orbitCam.transform.localEulerAngles.y;
            controller.transform.eulerAngles = new Vector3(0, camYaw, 0);
        }

        controller.currentVelocity = Vector3.zero;
        controller.currentVelocity += controller.transform.forward * v * (speed * 65) * Time.deltaTime;
        controller.currentVelocity += controller.transform.right * h * (speed * 65) * Time.deltaTime;

        controller.pawn.SimpleMove(controller.currentVelocity);
    }
}
