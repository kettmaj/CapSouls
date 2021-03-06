﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// abstract class to hold inherited methods for other states the player can be in.
/// </summary>
public abstract class PlayerState {
    /// <summary>
    /// reference to the player class
    /// </summary>
    protected ThirdPersonMovement controller;
    /// <summary>
    /// the damage that the player takes depending on what state they are in
    /// </summary>
    public float damageMult = 1;

    /// <summary>
    /// override method for inheritance, virtual to allow for override, abstract to force override
    /// </summary>
    abstract public PlayerState Update();
    /// <summary>
    /// what the inherited objects do when starting
    /// </summary>
    virtual public void OnBegin(ThirdPersonMovement controller)
    {
        this.controller = controller;
    }
    /// <summary>
    /// what the inherited objects do when ending
    /// </summary>
    virtual public void OnEnd()
    {

    }


}
