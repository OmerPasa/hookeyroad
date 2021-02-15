﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    public Transform bars;
    private Vector3 nextBarsSpawn;
    public Transform barrierleft;
    public Transform barrierright;
    private Vector3 nextbarrierleftSpawn;
    private Vector3 nextbarrierrightSpawn;
    private int randomZ;
    void Start()
    {
        nextBarsSpawn.x=24;
        nextBarsSpawn.y=4;
        nextbarrierleftSpawn.x=18;
        nextbarrierleftSpawn.y=4;
        nextbarrierrightSpawn.x=18;
        nextbarrierrightSpawn.y=4;
        StartCoroutine(spawnBars());
        StartCoroutine(spawnbarrierleft());
        //StartCoroutine(spawnbarrier());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator spawnbarrierleft()
    {
        // left barrier
        yield return new WaitForSeconds(1);
        randomZ=Random.Range(-1,2);
        nextbarrierleftSpawn.z=randomZ;
        Instantiate(barrier, nextbarrierleftSpawn, barrierleft.rotation);
        nextbarrierleftSpawn.x += 8;
        StartCoroutine(spawnbarrierleft());
    }
    IEnumerator spawnBars()
    {
        yield return new WaitForSeconds(1);
        Instantiate(bars, nextBarsSpawn, bars.rotation);
        nextBarsSpawn.x += 8;
        StartCoroutine(spawnBars());
    }
}
