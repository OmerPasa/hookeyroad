using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletemovement : MonoBehaviour
{
    void Start()
    {
      transform.position = new Vector3(0.5f,4.186f,3.114f);
      GetComponent<Rigidbody>().velocity = new Vector3(5,0,0);// crowbar and crowbarrot had to have rigidbody to work!!
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
      {
        Vector3 position = transform.position;
        position.z += 1.5f;
        transform.position = position;
      }
      if (Input.GetKeyDown(KeyCode.D))
      {
        Vector3 position = transform.position;
        position.z -= 1.5f;
        transform.position = position;
      }
    }
}
