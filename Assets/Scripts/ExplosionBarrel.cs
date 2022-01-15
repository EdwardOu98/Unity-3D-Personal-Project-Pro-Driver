using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBarrel : Obstacle
{
    [SerializeField] private ParticleSystem explosionParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
        destroyDelay = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.UpdateScore(scoreToDeduct);
            audioSource.PlayOneShot(hitSound, 1.0f);
            explosionParticle.Play();
            StartCoroutine(DestroyObstacle());
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        playerController.UpdateScore(scoreToDeduct);
    //        audioSource.PlayOneShot(hitSound, 1.0f);
    //        explosionParticle.Play();
    //        StartCoroutine(DestroyObstacle());

    //    }
    //}

    IEnumerator DestroyObstacle()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
