using System.Collections;
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
    private double randomZ;
    public static System.Random ran = new System.Random();
    double[] barrierleftList = {3.3, 1.79, 0.29};
    double[] barrierrightList = {3, 1.5, 0};
    public float Aralık;
    void Start()
    {
        Aralık = 3f;
        nextBarsSpawn.x=24;
        nextBarsSpawn.y=4;
        nextbarrierleftSpawn.x=18;
        nextbarrierleftSpawn.y=4;
        nextbarrierrightSpawn.x=18;
        nextbarrierrightSpawn.y=4;
        StartCoroutine(spawnBars());
        StartCoroutine(spawnbarrierleft());
        StartCoroutine(spawnbarrierright());
    }
    void Update()
    {
        
    }
     IEnumerator spawnbarrierleft()
    {
        yield return new WaitForSeconds(0.6f);
        //randomZ=Random.Range(-1,2);
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
        yield return new WaitForSeconds(0.6f);
        //randomZ=Random.Range(-1,2);
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
        yield return new WaitForSeconds(1);
        Instantiate(bars, nextBarsSpawn, bars.rotation);
        nextBarsSpawn.x += 8;
        StartCoroutine(spawnBars());
    }
}
