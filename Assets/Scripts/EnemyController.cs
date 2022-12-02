using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    private Transform player;
    private Rigidbody2D rb;
    Vector3 direction;

    private bool scared;
    private AudioSource birdHitSound;
    private BoxCollider2D boxCol;

    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        birdHitSound = GameObject.FindGameObjectWithTag("BirdHitSound").GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!Settings.Died)
        {
            direction = player.transform.position - transform.position;
        }

        if (direction.x >= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        

        if (rb.velocity.magnitude > moveSpeed)
        {
            rb.velocity = rb.velocity.normalized * moveSpeed;
        }

        if (scared)
        {
            boxCol.isTrigger = true;
        }
    }

    void FixedUpdate()
    {
        if (!scared && !Settings.Died)
        {
            rb.AddForce(direction * moveSpeed);
        }
        else
        {
            rb.AddForce(-direction * moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scared = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            birdHitSound.Play();
            scared = true;
        }
    }
}
