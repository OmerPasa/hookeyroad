using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionCam : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().velocity= new Vector3(5,0,0);
    }
}
