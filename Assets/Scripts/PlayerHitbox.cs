using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour {
    public ThirdPersonMovement controller;
    private void Start()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Hurt")
        {
            //controller.Health = controller.Health - 20;
            print("Oof");
        }
    }
}
