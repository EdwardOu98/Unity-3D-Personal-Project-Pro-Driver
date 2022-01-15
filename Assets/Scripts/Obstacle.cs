using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int scoreToDeduct;
    [SerializeField] AudioClip hitSound;
    private PlayerController playerController;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerController.UpdateScore(scoreToDeduct);
            audioSource.PlayOneShot(hitSound, 1.0f);
            StartCoroutine(DestroyObstacle());
            
        }
    }

    IEnumerator DestroyObstacle()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
