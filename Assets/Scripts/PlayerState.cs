using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    /// <summary>
    /// a new type to hold all the different states the player can be in
    /// </summary>
    public enum CurrentState //playerstate.state
    {
        idle,
        walking,
        running,
        dodging,
        attacking
    }
    public CurrentState state;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(state);
        //i really don't know here
	}
}
