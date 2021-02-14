using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    public Transform bars;
    private Vector3 nextBarsSpawn;

    void Start()
    {
        nextBarsSpawn.x=24;
        nextBarsSpawn.y=4;
        StartCoroutine(spawnBars());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnBars()
    {
        yield return new WaitForSeconds(1);
        Instantiate(bars, nextBarsSpawn, bars.rotation);
        nextBarsSpawn.x += 8;
        StartCoroutine(spawnBars());
    }
}
