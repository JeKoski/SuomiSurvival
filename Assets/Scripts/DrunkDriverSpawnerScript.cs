using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkDriverSpawnerScript : MonoBehaviour
{
    public GameObject drunkDriver;

    [SerializeField] float spawnDelay = 2.0f;
    [SerializeField] float minSpawnDelay = 10.0f;
    [SerializeField] float maxSpawnDelay = 30.0f;
    [SerializeField] float rotation = 0.0f;
    private float spawnTimer = 0.0f;

    private void Start()
    {
        RNG();
    }

    void FixedUpdate()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnDelay)
        {
            RNG();
            Instantiate(drunkDriver, transform.position, Quaternion.Euler(0, 0, rotation));
            spawnTimer = 0;
        }
    }

    private void RNG()
    {
        spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
    }
}
