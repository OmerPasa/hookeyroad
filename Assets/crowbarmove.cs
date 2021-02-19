using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowbarmove : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(5,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        // left 2.83  1.33  -0.17
      if (Input.GetKey("a"))
      {
        GetComponent<Rigidbody>().velocity = new Vector3(5,0,1.5);
      }
    }
}
