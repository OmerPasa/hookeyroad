using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowCollision : MonoBehaviour
{
    public crowbarmove crow;
   void OnCollisinonEnter (Collision collisionInfo)
   {
       if (collisionInfo.collider.tag == "barrier")
       {
           Debug.Log("GAMEOVER");
           GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
       }
   }
}
