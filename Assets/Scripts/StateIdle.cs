using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// if the player is not moving, attacking, or dodging they should be idle, and able to move their camera around. Currently not used and only kept as reference for base Playerstate
/// </summary>
public class StateIdle : PlayerState {
    /// <summary>
    /// override inherited update method
    /// </summary>
    override public PlayerState Update()
    {
        Debug.Log("idle");

        //put behavior here

        //put transitions here
        
        //if transtion condition is true, return new state

        return null;
    }
    

}
