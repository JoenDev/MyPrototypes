using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePreFab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    public float spawnDelay = 2;
    public float repeatRate = 2;
    public float randomDelay;
    public float randomRate;
    public int minDelay = 3;
    public int maxDelay = 5;
    public float rand;
    

    public PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
  
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //InvokeRepeating("spawnRepeat", spawnDelay, repeatRate);|
        StartCoroutine(WaitAndSpawn());
    }

    // Update is called once per frame
    void Update()
    {

      
    }

    public IEnumerator WaitAndSpawn()
    {
        while ((playerControllerScript.gameOver == false))
        {
            int rand = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(rand);
            Instantiate(obstaclePreFab, spawnPos, obstaclePreFab.transform.rotation);
        }
    }


}

