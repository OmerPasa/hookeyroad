﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class instantiate : MonoBehaviour
{
    public Transform bars;     // getting orginal components
    public Transform barrierleft;
    public Transform barrierright;
    public Transform Tunnel;
    private Vector3 nextBarsSpawn;  //locating next spawn point
    private Vector3 nextbarrierleftSpawn;
    private Vector3 nextbarrierrightSpawn;
    private Vector3 nextTunnelSpawn;
    private double randomZ;
    public static System.Random ran = new System.Random();
    double[] barrierleftList = { 3.3, 1.79, 0.29 }; //initial locations    
    double[] barrierrightList = { 3, 1.5, 0 };
    public float Aralık;                // distances between barriers
    public float Diffuculty;            //spawning rate determination
    void Start()
    {
        // float Diffuculty = Console.ReadLine();   // in future needs to be UI
        // all till croutine is initial localizations  
        //Aralık = 5f;//normal
        //Diffuculty = 0.8f;
        nextBarsSpawn.x = 24;
        nextBarsSpawn.y = 4;
        nextbarrierleftSpawn.x = 18;
        nextbarrierleftSpawn.y = 4;
        nextbarrierrightSpawn.x = 18;
        nextbarrierrightSpawn.y = 4;
        nextTunnelSpawn.x = 65;
        nextTunnelSpawn.y = 0;

        StartCoroutine(spawnBars());
        StartCoroutine(spawnbarrierleft());
        StartCoroutine(spawnbarrierright());
        StartCoroutine(spawnTunnel());
    }
    void Update()
    {

    }
    IEnumerator spawnbarrierleft()
    {
        yield return new WaitForSeconds(0.8f);

        randomZ = barrierleftList[ran.Next(barrierleftList.Length)];
        nextbarrierleftSpawn.z = (float)randomZ;
        Instantiate(barrierleft, nextbarrierleftSpawn, barrierleft.rotation);
        randomZ = barrierleftList[ran.Next(barrierleftList.Length)];
        nextbarrierleftSpawn.z = (float)randomZ;
        Instantiate(barrierleft, nextbarrierleftSpawn, barrierleft.rotation);
        nextbarrierleftSpawn.x += Aralık;
        StartCoroutine(spawnbarrierleft());
    }
    IEnumerator spawnbarrierright()
    {
        yield return new WaitForSeconds(0.8f);

        randomZ = barrierrightList[ran.Next(barrierrightList.Length)];
        nextbarrierrightSpawn.z = (float)randomZ;
        Instantiate(barrierright, nextbarrierrightSpawn, barrierright.rotation);
        randomZ = barrierrightList[ran.Next(barrierrightList.Length)];
        nextbarrierrightSpawn.z = (float)randomZ;
        Instantiate(barrierright, nextbarrierrightSpawn, barrierright.rotation);
        nextbarrierrightSpawn.x += Aralık;
        StartCoroutine(spawnbarrierright());
    }
    IEnumerator spawnBars()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(bars, nextBarsSpawn, bars.rotation);
        nextBarsSpawn.x += 8;
        StartCoroutine(spawnBars());
    }
    IEnumerator spawnTunnel()
    {
        yield return new WaitForSeconds(4f);
        Instantiate(Tunnel, nextTunnelSpawn, Tunnel.rotation);// spanwning
        nextTunnelSpawn.x += 45;                               // planning next spawn point
        StartCoroutine(spawnTunnel());                        //restarting routine
    }
}
