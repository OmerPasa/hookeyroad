using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrowCollision : MonoBehaviour
{
void OnTriggerEnter(Collider other)
    {   
        Debug.Log("has collide");
    }
}
