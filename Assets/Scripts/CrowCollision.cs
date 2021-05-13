using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrowCollision : MonoBehaviour
{
void OnTriggerEnter(Collider other)
    {
        if (other.tag == "barrier") 
        {
            Debug.Log("has collide");
        }
    }

}
