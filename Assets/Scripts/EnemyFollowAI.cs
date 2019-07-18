using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //[SerializeField] private Transform target;
    private Vector2 targetLocation;
    public Vector2 mDirection;
    [SerializeField] public float enemySpeed = 5f;
    public Rigidbody2D enemyRb;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
        UpdatePlayerLocation();
        MoveTo();
    }

    void MoveTo()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetLocation, Time.deltaTime * enemySpeed);
        mDirection = enemyRb.velocity;
        mDirection.Normalize();
    }

    void UpdatePlayerLocation()
    {
        targetLocation = player.GetComponent<Transform>().position;
    }

}
