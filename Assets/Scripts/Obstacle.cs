using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] protected int scoreToDeduct;
    [SerializeField] protected AudioClip hitSound;
    protected PlayerController playerController;
    protected AudioSource audioSource;

    protected float destroyDelay = 0.05f;
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
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
