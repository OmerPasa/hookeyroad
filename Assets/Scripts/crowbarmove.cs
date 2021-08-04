using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowbarmove : MonoBehaviour
{
      void Start()
    {
      transform.position = new Vector3(0.15f,3.2f,2.05f);
      GetComponent<Rigidbody>().velocity = new Vector3(-5,0,0);
    }
    
    void Update()
    {
      //this if makes sure , crowbar in certain positions
      if (transform.position.z <= 0.55 || transform.position.z >=3.55)
{
    // Create values between this range (minY to maxY) and store in yPos
    float zPos = Mathf.Clamp(transform.position.z, 0.55f, 3.55f);

    // Assigns these values to the Transform.position component of the Player
    transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
}
      transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.55f, 0.55f), transform.position.y, transform.position.z);
      
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
