using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkDriverPrefabScript : MonoBehaviour
{
    [SerializeField] private float driverSpeed = 15.0f;
    private float targetSpeed;
    private float currentSpeed;
    [SerializeField] private float lerpTime = 5f;

    private Rigidbody2D rb;
    [SerializeField] private Vector2 drivingDirection = new Vector2(0.0f, 1.0f);
    [SerializeField] private float minSpeed = 1.0f;
    [SerializeField] private float maxSpeed = 20.0f;

    [SerializeField] private float rngDelay = 1.0f;
    private float delayTimer = 0.0f;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        targetSpeed = driverSpeed;
        currentSpeed = driverSpeed;
        RNG();
    }

    
    void Update()
    {
        RNGDelay();
        Drive();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DrunkDriverDespawner")
        {
            Destroy(gameObject);
        }
    }

    private void Drive()
    {
        driverSpeed = Mathf.Lerp(driverSpeed, targetSpeed, Time.deltaTime * lerpTime);
        rb.velocity = drivingDirection * driverSpeed;
    }

    private void RNGDelay()
    {
        delayTimer = Time.deltaTime + delayTimer;
        if (delayTimer > rngDelay)
        {
            RNG();
            delayTimer = 0;
        }
    }

    private void RNG()
    {
        driverSpeed = targetSpeed;
        targetSpeed = Random.Range(minSpeed, maxSpeed);
    }
}
