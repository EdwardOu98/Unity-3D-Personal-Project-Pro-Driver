using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 20000;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed = 50.0f;
    [SerializeField] private List<WheelCollider> allWheels;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private Text currentScoreText;

    private int currentScore = 100;

    // [SerializeField] AudioClip engineSound;
    // [SerializeField] private GameObject CenterOfMass;
    private Rigidbody playerRb;
    // private AudioSource audioSource;
    private int wheelsOnGround;
    private float speedLimit = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        currentScoreText.text = "Score: " + currentScore;
        // audioSource = GetComponent<AudioSource>();
        // playerRb.centerOfMass = CenterOfMass.transform.position;
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

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speed: " + speed + " KM/H");

            // audioSource.PlayOneShot(engineSound, 0.005f * speed);
        }

        
    }

    public void UpdateScore(int scoreToDeduct)
    {
        currentScore -= scoreToDeduct;
        currentScoreText.text = "Score: " + currentScore;
    }

    private void FixedUpdate()
    {
        playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, speedLimit);
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
