using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb; //reference ti Rigidbody component "rb"

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, 200, 500);
    }

    // Used FixedUpdate for physics
    void FixedUpdate()
    {
        //Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey("d")) // if d is pressed
        {
            //Add a force to the right
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        
        if (Input.GetKey("a")) // if a is pressed
        {
            //Add a force to the left
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
