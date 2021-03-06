﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// constrains the camera to the target at a set distance
/// </summary>
public class FollowTarget : MonoBehaviour {
    /// <summary>
    /// reference to the target (a game object above the player)
    /// </summary>
    public Transform target;
    /// <summary>
    /// a variable smoothing the camera follow, used in a Lerp during update
    /// </summary>
    public float easeMultiplier = 10;

    
	
	/// <summary>
    /// things the camera should do each time
    /// </summary>
	void Update () {
		if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * easeMultiplier);
        }
	}
}
