using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> Clouds = new List<GameObject>();
    public List<GameObject> StaticObjects = new List<GameObject>();
    public List<GameObject> Enemies = new List<GameObject>();
    public List<GameObject> Gifts = new List<GameObject>();

    public LayerMask mask;
    public LayerMask cloudMask;

    public float timeBetweenSpawningCloud;
    private float timerCloud;
    public float timeBetweenSpawningStatic;
    private float timerStatic;
    public float timeBetweenSpawningEnemies;
    private float timerEnemies;
    public float timeBetweenSpawningGifts;
    private float timerGifts;

    public Transform player;

    void Update()
    {
        timerCloud -= Time.deltaTime;
        timerStatic -= Time.deltaTime;
        timerEnemies -= Time.deltaTime;
        timerGifts -= Time.deltaTime;

        if (timerCloud <= 0)
        {
            SpawnClouds();
            timerCloud = timeBetweenSpawningCloud;
        }

        if (timerStatic <= 0)
        {
            SpawnStaticObject();
            timerStatic = timeBetweenSpawningStatic;
        }

        if (timerEnemies <= 0)
        {
            SpawnEnemies();
            timerEnemies = timeBetweenSpawningEnemies;
        }

        if (timerGifts <= 0)
        {
            SpawnGifts();
            timerGifts = timeBetweenSpawningGifts;
        }
    }

    void SpawnClouds()
    {
        Vector2 spawnPos = new Vector2(player.position.x, player.position.y - 25);
        spawnPos += Random.insideUnitCircle.normalized * 10;

        if (Physics2D.OverlapCircle(spawnPos, 2, cloudMask) == null)
        {
            Instantiate(Clouds[Random.Range(0, Clouds.Capacity - 1)], spawnPos, Quaternion.identity);
        }
    }

    void SpawnStaticObject()
    {
        Vector2 spawnPos = new Vector2(player.position.x, player.position.y - 25);
        spawnPos += Random.insideUnitCircle.normalized * 10;

        if (Physics2D.OverlapCircle(spawnPos, 3, mask) == null)
        {
            Instantiate(StaticObjects[Random.Range(0, StaticObjects.Capacity)], spawnPos, Quaternion.identity);
        }
    }

    void SpawnEnemies()
    {
        int randomSide = Random.Range(1, 3);
        var x = 20;

        if (randomSide == 1) {
            x = 20;
        }
        else
        {
            x = -20;
        }

        Vector2 spawnPos = new Vector2(player.position.x + x, player.position.y);

        spawnPos += Random.insideUnitCircle.normalized * 15;

        if (Physics2D.OverlapCircle(spawnPos, 5, mask) == null)
        {
            Instantiate(Enemies[Random.Range(0, Enemies.Capacity - 1)], spawnPos, Quaternion.identity);
        }
    }

    void SpawnGifts()
    {
        Vector2 spawnPos = new Vector2(player.position.x, player.position.y - 25);
        spawnPos += Random.insideUnitCircle.normalized * 15;

        if (Physics2D.OverlapCircle(spawnPos, 5, mask) == null)
        {
            Instantiate(Gifts[Random.Range(0, Gifts.Capacity - 1)], spawnPos, Quaternion.identity);
        }
    }
}
