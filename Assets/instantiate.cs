using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    public Transform tileObj;
    private Vector3 nextBaseSpawn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnBase()
    {
        yield return new WaitForSeconds(1);
        instantiate(tileObj, nextBaseSpawn, tileObj.rotation);
    }
}
