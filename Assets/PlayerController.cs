using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
    public float ForceMultiplier;
    public float gravityMultiplier;
    public bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerRB.AddForce(Vector3.up * ForceMultiplier, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
}
