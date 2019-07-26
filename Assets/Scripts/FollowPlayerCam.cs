using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCam : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("PlayerPH");
    }

    
    void Update()
    {
        gameObject.transform.position = player.transform.position + new Vector3(0, 0, -10);
    }
}
