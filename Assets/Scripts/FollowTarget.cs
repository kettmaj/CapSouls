using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    /// <summary>
    /// reference to the target (a game object above the player)
    /// </summary>
    public Transform target;
    /// <summary>
    /// a variable smoothing the camera follow, used in a Lerp during update
    /// </summary>
    public float easeMultiplier = 10;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * easeMultiplier);
        }
	}
}
