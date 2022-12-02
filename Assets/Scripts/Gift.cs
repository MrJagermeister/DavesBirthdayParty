using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;

    public GameObject balloon;
    public GameObject balloonExplosion;
    public Transform explosionPosition;
    private Floating floating;

    public AudioSource explosionSound;

    void Start()
    {
        explosionSound = GameObject.FindGameObjectWithTag("ExplosionSound").GetComponent<AudioSource>();
        floating = GetComponent<Floating>();
        boxCol = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            explosionSound.Play();
            Destroy(floating);
            Destroy(boxCol);
            Destroy(collision.gameObject);
            rb.gravityScale = 1;
            Instantiate(balloonExplosion, explosionPosition.position, Quaternion.identity);
            Destroy(balloon);
            ScoreCounter.giftScore += 1;
        }
    }
}
