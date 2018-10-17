using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Determines what happens to objects that the sword hits
/// </summary>
public class SwordSwing : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        
        if(col.gameObject.tag == "Breakable")
        {
            Destroy(col.gameObject);
            
        }
        if (col.gameObject.tag == "Enemy")
        {
            //col.EnemyHP -= 10;
            print("You hit an enemy");
        }
    }
}
