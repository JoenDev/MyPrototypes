using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem playerExplosion;
    public ParticleSystem playerDirt;
    public AudioSource playerAudio;
    public AudioClip playerJump;
    public AudioClip playerCrash;
    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
   
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
     
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& isOnGround && !gameOver)
        {
            playerAnim.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
          
            playerAudio.PlayOneShot(playerJump,1.0f);
            playerDirt.Stop();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerDirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerDirt.Stop();

            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            playerExplosion.Play();
            playerAudio.PlayOneShot(playerCrash,1.0f);
       


        }
    }
}
