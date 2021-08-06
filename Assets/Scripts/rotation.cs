using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
//THAT SCRİPT HAS TO BE PUTTEN TO CHİLD OBJECT!
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
      {
        transform.eulerAngles = new Vector3(
        transform.eulerAngles.x,
        transform.eulerAngles.y + 180,
        transform.eulerAngles.z
);
      }
      if (Input.GetKeyDown(KeyCode.S))
      {
        transform.eulerAngles = new Vector3(
        transform.eulerAngles.x,
        transform.eulerAngles.y - 180,
        transform.eulerAngles.z
);
      }
    }
}
