using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
    private float rand;
    public int minDelay = 1;
    public int maxDelay = 3;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
       // InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        StartCoroutine(SpawnObjects());
    }
    

    // Spawn obstacles
    public IEnumerator SpawnObjects()
    {
        // Set random spawn location and random object index
       

        // If game is still active, spawn new object
        while (!playerControllerScript.gameOver )
        {
            int rand = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(rand);
            Vector3 spawnLocation = new Vector3(30, Random.Range(4, 13), 0);
            int index = Random.Range(0, objectPrefabs.Length);
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }

    }
}
