using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowbarmove : MonoBehaviour
{

    bool rightslideUp;
    private bool isJumpPressed;


    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(5,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        // left 2.83  1.33  -0.17
       if (Input.GetKeyDown(KeyCode.D))
      {
        rightslideUp = true;
        new WaitForSeconds(1);
        rightslideUp = false;
      }
      else
      {
          rightslideUp = false;
      }
     
      if (Input.GetKeyDown(KeyCode.LeftArrow))
      {
        GetComponent<Rigidbody>().velocity = new Vector3(5,0,2);
      }
      if (Input.GetKeyDown(KeyCode.A))
      {
        GetComponent<Rigidbody>().velocity = new Vector3(5,0,2);
      }
      if (Input.GetKeyDown(KeyCode.Space))
      {
        isJumpPressed = true;
      }
    }
}
