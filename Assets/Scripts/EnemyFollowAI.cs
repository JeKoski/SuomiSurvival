using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform target;
    private Vector2 targetLocation;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveTo()
    {

    }

    void UpdatePlayerLocation()
    {
        targetLocation = player.GetComponent<Transform>().position;
    }

}
