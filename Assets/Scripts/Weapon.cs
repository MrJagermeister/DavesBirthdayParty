using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector3 mousePos;

    public GameObject projectile;
    public Transform firePoint;

    private float fireRate;
    public float startFireRate;
    public float recoilPower;

    public GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public GameObject poofSmoke;
    public AudioSource shootSound;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!Settings.Paused)
        {
            mousePos = Input.mousePosition;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            if (mousePos.x > 0)
            {
                sr.flipY = false;
            }
            if (mousePos.x < 0)
            {
                sr.flipY = true;
            }

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            if (fireRate <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    shootSound.Play();
                    Instantiate(poofSmoke, firePoint.position, firePoint.rotation);
                    GameObject bullet = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject;
                    Destroy(bullet, 5f);
                    Recoil();

                    fireRate = startFireRate;
                }
            }
            else
            {
                fireRate -= Time.deltaTime;
            }
        }
    }

    void Recoil()
    {
        var direction = player.transform.position - mousePos;

        rb.AddForce(direction * recoilPower);
    }
}
