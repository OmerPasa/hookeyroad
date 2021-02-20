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
       if (Input.GetKeyDown(KeyCode.RightArrow))
      {
        GetComponent<Rigidbody>().velocity = new Vector3(5,0,-2);
      }
      if (Input.GetKeyDown(KeyCode.D))
      {
        GetComponent<Rigidbody>().velocity = new Vector3(5,0,-2);
      }
      if (Input.GetKeyDown(KeyCode.LeftArrow))
      {
        GetComponent<Rigidbody>().velocity = new Vector3(5,0,2);
      }
      if (Input.GetKeyDown(KeyCode.A))
      {
        GetComponent<Rigidbody>().velocity = new Vector3(5,0,2);
      }
    }
}
