﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    private float speed = 200;
    public GameObject player;
    public ParticleSystem speedUpIndicator;
   
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        transform.position = player.transform.position; // Move focal point with player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speedUpIndicator.Play();
            

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            speedUpIndicator.Stop();
          

        }
    }
}
