using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 20000;
    // [SerializeField] private float speed = 20.0f;
    [SerializeField] private float turnSpeed = 50.0f;
    [SerializeField] private List<WheelCollider> allWheels;
    // [SerializeField] private GameObject centerOfMass;
    private Rigidbody playerRb;
    private int wheelsOnGround;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        // playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnGround())
        {
            float forwardInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");

            // transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
        
    }

    int CountWheels()
    {
        int wheelCount = 0;

        foreach (WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                ++wheelCount;
            }
        }

        return wheelCount;
    }

    bool isOnGround()
    {
        wheelsOnGround = CountWheels();

        if(wheelsOnGround == 4)
        {
            return true;
        }


        return false;
    }
}
