using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
    private Animator playerAnim;


    public float ForceMultiplier;
    public float gravityMultiplier;
    public bool onGround = true;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
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
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        } else if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
        
    }
}
