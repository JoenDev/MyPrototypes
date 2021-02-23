using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    
    public float spawnWait;
    public float spawnMostWait = 3.0f;
    public float spawnLesWait = 5.0f;

    public float spawnLimitXLeft = 40.0f;
    public float spawnLimitXRight = 7.0f;
    public float spawnPosY = 30.0f;

    public int startWait;
    public bool stop;
    





    // Start is called before the first frame update
    void Start()
    {
        //// while true
        // int spawnInterval = Random.Range(spawnTimeMin, spawnTimeMax);
        // InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval); 

        StartCoroutine(waitSpawner());
    }
     void Update()
    {
        spawnWait = Random.Range(spawnLesWait,spawnMostWait);
    }
    IEnumerator waitSpawner()
    {
        
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

            int ballIndex = Random.Range(0, ballPrefabs.Length);
            Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
    // Spawn random ball at random x position at top of play area
  



}
