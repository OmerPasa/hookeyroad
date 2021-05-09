using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowCollision : MonoBehaviour
{
    public crowbarmove crow;
   void OnCollisinonEnter (Collision collision)
   {
       Debug.Log("Game Over");
   }
}
