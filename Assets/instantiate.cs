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
    double[] barrierleftList = {1.23, 4.56, 7.89};
    double[] barrierrightList = {1.23, 4.56, 7.89};
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
    }
    void Update()
    {
        
    }
     IEnumerator spawnbarrierleft()
    {
        yield return new WaitForSeconds(1);
        //randomZ=Random.Range(-1,2);
        //randomZ += 1.56; 
        //randomZ = barrierleftList[Random.Next(barrierleftList.Length)];
        randomZ = ran.Next(barrierleftList.Length);
        //Randomizer.Randomize(barrierleftList);
        nextbarrierleftSpawn.z = (float)randomZ;
        Instantiate(barrierleft, nextbarrierleftSpawn, barrierleft.rotation);
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
