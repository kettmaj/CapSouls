﻿using System.Collections;
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
    /// the player's movement speed (affects final velocity)
    /// </summary>
    public float speed = 10;
    /// <summary>
    /// the player's renderer element material
    /// </summary>
    Material mats;

    public override void OnBegin(ThirdPersonMovement controller)
    {
        base.OnBegin(controller);
        mats = controller.GetComponent<Renderer>().material;
    }

    override public PlayerState Update()
    {
        mats.color = Color.blue;

        //put behavior here
        MoveAround();


        //put transitions here
        //if transtion condition is true, return new state

        if (Input.GetButtonDown("Space") && controller.dodgeCooldown <= 0)
        {
            return new StateDodging();
        }
        //b is joystick button 1
        if (Input.GetButtonDown("B Button"))
        {
            if (controller.dodgeCooldown <= 0)
            {
                return new StateDodging();
            }

        }

        if (Input.GetButtonUp("Sprint"))
        {
            return new StateWalking();
        }
        //b is joystick button 1
        if (Input.GetButtonUp("B Button"))
        {
            if (controller.dodgeCooldown <= 0)
            {
                return new StateWalking();
            }

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

        if (v != 0 || h != 0)
        {
            float camYaw = controller.orbitCam.transform.localEulerAngles.y;
            controller.transform.eulerAngles = new Vector3(0, camYaw, 0);
        }

        controller.currentVelocity = Vector3.zero;
        controller.currentVelocity += controller.transform.forward * v * speed;
        controller.currentVelocity += controller.transform.right * h * speed;

        controller.pawn.SimpleMove(controller.currentVelocity);
    }
}
