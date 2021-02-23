using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTheLeft : MonoBehaviour
{
    public float speed = 30;
    public PlayerController playerControllerScript;
    public float leftBound = -10;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle") )
        {
            Destroy(gameObject);
        }
       
    }
}
