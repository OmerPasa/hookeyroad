using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Delete_Yourself : MonoBehaviour
{
    /*public Transform crowbar;  // for some reason game doesn't recognize this find a way
    void Update()
    {
        float distance = Vector3.Distance (crowbar.position, transform.position);
        Debug.Log(distance);
        if (distance > 5)
        {
            Invoke("Die",2f);
        }
    }*/
    void OnBecameInvisible()
    {
        Invoke("Die",0.5f);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}