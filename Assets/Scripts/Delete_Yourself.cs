using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Delete_Yourself : MonoBehaviour
{
    public Gameobject crowbar;  // for some reason game doesn't recognize this find a way
    public float distance;
    void Update()
    {
        distance = Vector3.Distance (crowbar.position, transform.position);
        Debug.Log(distance);
        if (distance >= 50 )
        {
            Invoke("Die",2f);
        }
    }
    void OnBecameInvisible()
    {
       // Invoke("Die",0.5f);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}