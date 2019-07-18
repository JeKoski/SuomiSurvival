using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoFieldScript : MonoBehaviour
{

    [SerializeField] private float enemySpeed;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
    }
}
