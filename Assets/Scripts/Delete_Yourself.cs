using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Delete_Yourself : MonoBehaviour
{
    [SerializeField]
    public GameObject crowbar;  // for some reason game doesn't recognize this find a way
    public int distance;
    void Update()
    {

        crowbar = (GameObject.Find("Crowbar"));
        distance = (int)crowbar.transform.position.x - (int)transform.position.x;
        //Debug.Log(distance + " currrent distance is ");
        if (crowbar.transform.position.x > transform.position.x + 50)
        {
            Invoke("Die", 2f);
        }
    }
    void OnBecameInvisible()
    {
        Invoke("Die", 0.5f);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}