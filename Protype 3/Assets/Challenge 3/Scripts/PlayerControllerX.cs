using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    public bool isOutOfBoundery;
    public bool isOnLowBoundery;
    public bool baloonDelay;
    public float bounderyPenalty;
    public float penaltyForce = -5;



    public float floatForce = 2f;
    private float gravityModifier = 1.5f;

    public float floatInterval = .7f;
    public float floatRate;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;



    // Start is called before the first frame update
    void Start()
    {

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();


        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && !isOutOfBoundery )
        {
         


            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }


    else if (isOnLowBoundery == true && Time.time > floatRate && !gameOver)
        {
            floatRate = Time.time + floatInterval;
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }


    }

   





    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true

        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }



    }

    private void OnTriggerEnter(Collider other)
    {
                if (other.gameObject.CompareTag("TopBoundery"))
        {
            isOutOfBoundery = true;
            
        }
                else if (other.gameObject.CompareTag("LowBoundery"))
        {

            isOnLowBoundery = true;
        }

    } 


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("TopBoundery"))
        {
            isOutOfBoundery = false;
            
     
        }
        else if (other.gameObject.CompareTag("LowBoundery"))
        {
            isOnLowBoundery = false;
        }


    }
}