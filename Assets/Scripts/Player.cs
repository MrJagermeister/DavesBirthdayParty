using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float maxSpeed;

    public int health = 3;
    private BoxCollider2D boxCol;

    public float invincibleTime = 1;
    private float invincibleTimer = 0;
    public float knockBack = 5;

    public GameObject balloonExplosion;
    public Transform balloonPosition1;
    public Transform balloonPosition2;
    public Transform balloonPosition3;
    public GameObject balloon1;
    public GameObject balloon2;
    public GameObject balloon3;

    public AudioSource explosionSound;
    public AudioSource bgMusicNormal;
    public AudioSource bgMusicFaster;
    public AudioSource bgMusicFastest;

    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!Settings.Died)
        {
            if (!Settings.Paused)
            {
                Vector3 mousePos = Input.mousePosition;
                Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
                mousePos.x = mousePos.x - objectPos.x;

                if (mousePos.x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if (mousePos.x < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                invincibleTimer -= Time.deltaTime;

                if (rb.velocity.magnitude > maxSpeed)
                {
                    rb.velocity = rb.velocity.normalized * maxSpeed;
                }

                if (invincibleTimer > 0)
                {
                    boxCol.isTrigger = true;
                }
                else
                {
                    boxCol.isTrigger = false;
                }
            }

            balloonExplosions();

            if (health <= 0)
            {
                Settings.Died = true;
            }
        }
    }

    void balloonExplosions()
    {

        if (balloon1 != null)
        {
            if (health == 2)
            {
                bgMusicNormal.volume = 0;
                bgMusicFaster.volume = 0.5f;
                bgMusicFaster.pitch = 1;
                Destroy(balloon1);
                Instantiate(balloonExplosion, balloonPosition1.position, Quaternion.identity);
            }
        }

        if (balloon2 != null)
        {
            if (health == 1)
            {
                bgMusicFaster.volume = 0;
                bgMusicFastest.volume = 0.5f;
                bgMusicFastest.pitch = 1;
                Destroy(balloon2);
                Instantiate(balloonExplosion, balloonPosition2.position, Quaternion.identity);
            }
        }

        if (balloon3 != null)
        {
            if (health == 0)
            {
                bgMusicFastest.volume = 0;
                bgMusicNormal.volume = 0.5f;
                Destroy(balloon3);
                Instantiate(balloonExplosion, balloonPosition3.position, Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ThisHurts"))
        {
            health -= 1;
            maxSpeed += 1;
            explosionSound.Play();

            var direction = transform.position - collision.gameObject.transform.position;
            rb.AddForce(direction * knockBack);

            invincibleTimer = invincibleTime;
        }
    }
}
