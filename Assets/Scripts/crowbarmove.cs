using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowbarmove : MonoBehaviour
{
      void Start()
    {
      transform.position = new Vector3(0.5f,4.186f,3.114f);
      GetComponent<Rigidbody>().velocity = new Vector3(5,0,0);// crowbar and crowbarrot had to have rigidbody to work!!
    }
    
    void Update()
    {
      // doesn't compatible with animator :( 
     /* //this if makes sure , crowbar in Z position
      if (transform.position.z <= 0.08 || transform.position.z >=4.60)
{
    // Create values between this range (minY to maxY) and store in yPos
    float zPos = Mathf.Clamp(transform.position.z, 0.113f,3.161f);    

    // Assigns these values to the Transform.position component of the Player
    transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
}
    transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.5f, 0.5f), transform.position.y, transform.position.z);
      */
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
