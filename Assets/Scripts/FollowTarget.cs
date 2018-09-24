using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Transform target;
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
