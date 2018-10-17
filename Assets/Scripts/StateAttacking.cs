using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player is attacking
/// Transitions
/// -To Walking after attack button is released 
/// -To Dodging if Space is pressed
/// </summary>
public class StateAttacking : PlayerState {

    /// <summary>
    /// the player's renderer element material
    /// </summary>
    Material mat;
    /// <summary>
    /// reference to the sword arm attached to the player
    /// </summary>
    private GameObject sword;
    /// <summary>
    /// the angle the sword needs to end at
    /// </summary>
    private float attackAngle = -20;
    /// <summary>
    /// the angle the sword starts at
    /// </summary>
    private float currentAttackAngle = 90;
    /// <summary>
    /// the code that runs upon initialization of the state
    /// </summary>
    /// <param name="controller"></param>
    public override void OnBegin(ThirdPersonMovement controller)
    {

        base.OnBegin(controller);
        damageMult = 1.1f;
        mat = controller.GetComponent<Renderer>().material;
        mat.color = Color.yellow;
        sword = controller.sword;
        sword.transform.localEulerAngles = new Vector3(0, currentAttackAngle, 0);
        sword.SetActive(true);
        controller.lastAction = 0;
        controller.stamina -= 10;
    }

    /// <summary>
    /// everything the player can do during the attack
    /// </summary>
    /// <returns></returns>
    public override PlayerState Update()
    {
        //behavior
        if(currentAttackAngle != attackAngle)
        {
            currentAttackAngle -= 5;
        }
        sword.transform.localEulerAngles = new Vector3(0, currentAttackAngle, 0);
        
        
        //transitions
        if (currentAttackAngle == attackAngle)
        {
            return new StateWalking();
        }
        return null;

    }
    /// <summary>
    /// what should happen as the player exits the attacking state
    /// </summary>
    public override void OnEnd()
    {
        base.OnEnd();
        controller.didAction = true;
        sword.SetActive(false);
    }

}
