using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
    private Animator playerAnim;

    public ParticleSystem obstacleExposion;
    public ParticleSystem dirtSplatter;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    AudioSource audioSource;

    public float ForceMultiplier;
    public float gravityMultiplier;
    public bool onGround = true;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityMultiplier;

        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround &&!gameOver)
        {
            playerRB.AddForce(Vector3.up * ForceMultiplier, ForceMode.Impulse);
            onGround = false;
            dirtSplatter.Stop();
            playerAnim.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("obstacle"))
        {
            gameOver = true;
            dirtSplatter.Stop();
            obstacleExposion.Play();
            audioSource.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

        } else if (collision.gameObject.CompareTag("ground") && !gameOver)
        {
            onGround = true;
            dirtSplatter.Play();
        }
        
    }
}
