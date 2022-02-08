using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 20000;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed = 50.0f;
    [SerializeField] private List<WheelCollider> allWheels;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text congratsText;
    [SerializeField] private Text palyerNameText;
    [SerializeField] private Text highScoreText;

    private int currentScore = 100;

    // [SerializeField] AudioClip engineSound;
    // [SerializeField] private GameObject CenterOfMass;
    private Rigidbody playerRb;
    // private AudioSource audioSource;
    private int wheelsOnGround;
    private float speedLimit = 20.0f;
    private bool isGameOver = false;
    private bool isSaved = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        currentScoreText.text = "Score: " + currentScore;
        palyerNameText.text = "Player: " + GameManager.Instance.username;
        highScoreText.text = "High Score: " + GameManager.Instance.recordKeeper + ": " + GameManager.Instance.highScore.ToString();
        // audioSource = GetComponent<AudioSource>();
        // playerRb.centerOfMass = CenterOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, speedLimit);
        if (currentScore <= 0 || gameObject.transform.position.z >= 155f || gameObject.transform.position.y < -5)
        {
            isGameOver = true;
        }

    }

    public void UpdateScore(int scoreToDeduct)
    {
        currentScore -= scoreToDeduct;
        currentScoreText.text = "Score: " + currentScore;
    }

    private void FixedUpdate()
    {
        
        if (isOnGround() && !isGameOver)
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
        else if (isGameOver)
        {
            playerRb.velocity = Vector3.zero;
            if (transform.position.z >= 155f)
            {
                congratsText.gameObject.SetActive(true);
                if (currentScore > GameManager.Instance.highScore && !isSaved)
                {
                    GameManager.Instance.score = currentScore;
                    GameManager.Instance.SaveScore();
                }
                isSaved = true;
            }
            else
            {
                gameOverText.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
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
