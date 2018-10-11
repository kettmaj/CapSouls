using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player is attacking
/// Transitions
/// -To Walking after attack button is released 
/// -To Dodging if Space is pressed
/// </summary>
public class StateAttacking : PlayerState
{

    /// <summary>
    /// the player's renderer element material
    /// </summary>
    Material mats;

    public override void OnBegin(ThirdPersonMovement controller)
    {
        base.OnBegin(controller);
        mats = controller.GetComponent<Renderer>().material;
    }


    public override PlayerState Update()
    {
        throw new System.NotImplementedException();
        mats.color = Color.yellow;
    }
    
}
