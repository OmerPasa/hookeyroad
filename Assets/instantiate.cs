using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    public Transform bars;
    private Vector3 nextBarsSpawn;
    public Transform barrier;
    private Vector3 nextbarrierSpawn;
    private int randomZ;
    void Start()
    {
        nextBarsSpawn.x=24;
        nextBarsSpawn.y=4;
        StartCoroutine(spawnBars());
        StartCoroutine(spawnbarrier());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator spawnbarrier()
    {
        // left barrier
        yield return new WaitForSeconds(1);
        randomZ=Random.Range(-1,2);
        nextbarrierSpawn.z=randomZ;
        Instantiate(barrier, nextbarrierSpawn, barrier.rotation);
        nextbarrierSpawn.x += 8;
        StartCoroutine(spawnbarrier());
    }
    IEnumerator spawnBars()
    {
        yield return new WaitForSeconds(1);
        Instantiate(bars, nextBarsSpawn, bars.rotation);
        nextBarsSpawn.x += 8;
        StartCoroutine(spawnBars());
    }
}
