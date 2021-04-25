using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowbarmove : MonoBehaviour
{
      void Start()
    {
      transform.position = new Vector3(-0.91f,4.17f,0.15f);
      GetComponent<Rigidbody>().velocity = new Vector3(-5,0,0);
    }

    // Update is called once per frame
    void Update()
    {
      //transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, 3.15f, 0.15f));
      if (transform.position.z <= 0.15 || transform.position.z >=3.15)
{
    // Create values between this range (minY to maxY) and store in yPos
    float zPos = Mathf.Clamp(transform.position.z, 0.15f, 3.15f);

    // Assigns these values to the Transform.position component of the Player
    transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
}
      transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.15f, 0.15f), transform.position.y, transform.position.z);
      
      if (Input.GetKeyDown(KeyCode.A))
      {
        Vector3 position = transform.position;
        position.z += 1.5f;
        transform.position = position;
      }
      if (Input.GetKeyDown(KeyCode.D))
      {
        Vector3 position = transform.position;
        position.z -= 1.50f;
        transform.position = position;
      }
    }
}
