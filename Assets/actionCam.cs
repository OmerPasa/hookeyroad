using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionCam : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Rigidbody>().velocity= new Vector3(3,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
