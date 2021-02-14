using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    public Transform baseObj;
    private Vector3 nextBaseSpawn;

    void Start()
    {
        nextBaseSpawn.z=20
        StartCoroutine(spawnBase());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnBase()
    {
        yield return new WaitForSeconds(1);
        instantiate(baseObj, nextBaseSpawn, baseObj.rotation);
        nextBaseSpawn.z += 3;
        StartCoroutine(spawnBase());
    }
}
