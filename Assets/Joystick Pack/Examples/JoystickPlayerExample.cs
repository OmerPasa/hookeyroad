using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        if (variableJoystick.Horizontal >= .2f)  
      {
        Debug.Log("RIGHT_LONG");;
      } else if (variableJoystick.Horizontal <= -.2f)
      {
        Debug.Log("LEFT_LONG");
      } else
      {
        Debug.Log("LIGHTFLICKER");
      }
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}