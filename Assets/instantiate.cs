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
    private int randomZ;
    double[] barrierleftList = {1.23, 4.56, 7.89};
    //double[] barrierrightList = {1.23, 4.56, 7.89};
    List<double> items = new List<double>();
    items.Add(1.23);
    items.Add(4.56);
    items.Add(7.89);
    // This will give you a double[3] array with the items of the list.
    double[] barrierleftList = barrierleftList.ToArray();

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
        //randomZ=Random.Range(-1,2);
        randomZ = barrierleftList[Random.Range(0, barrierleftList.Length)];
        nextbarrierleftSpawn.z=randomZ;
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
