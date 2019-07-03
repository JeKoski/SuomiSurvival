using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMechanics : MonoBehaviour
{
    [Header("References:")]
    public GameplayVariables gpv;
    public GameObject player;
    public GameObject cabbinRoof;
    public GameObject playerStoreMarker;
    public static Vector2 playerStoreLocation;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerStoreLocation = playerStoreMarker.transform.position;
        gpv.ResetAll();
    }
    
    void Update()
    {
        PlayerStatsUpdate();
    }

    void PlayerStatsUpdate()
    {
        gpv.playerCoffee = gpv.playerCoffee + Time.deltaTime * gpv.playerCoffeeRate;
        gpv.playerWarmth = gpv.playerWarmth + Time.deltaTime * gpv.playerWarmthRate;
        gpv.playerHunger = gpv.playerHunger + Time.deltaTime * gpv.playerHungerRate;
        gpv.playerThirst = gpv.playerThirst + Time.deltaTime * gpv.playerThirstRate;
        gpv.playerMosquitoes = gpv.playerMosquitoes + Time.deltaTime * gpv.playerMosquitoesDecayRate;
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "MosquitoField")
        {
            Debug.Log("You're in a Mosquito Field!");
            gpv.playerMosquitoes = gpv.playerMosquitoes + Time.deltaTime * gpv.playerMosquitoesRate;
        }

        if (other.gameObject.tag == "WaterTrigger")
        {
            Debug.Log("You're in water!");
            gpv.playerWarmth = gpv.playerWarmth + Time.deltaTime * gpv.playerWaterCoolingRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SaweTrigger")
        {
            Debug.Log("You're entered the Store");
            // Move player to Store exit point
            player.transform.position = playerStoreLocation;
        }

        if (other.gameObject.tag == "CabbinTrigger")
        {
            Debug.Log("You've entered the Cabbin, disabling roof.");
            cabbinRoof.SetActive(false);
        }

        if (other.gameObject.tag == "LoggingPlaceTrigger")
        {
            Debug.Log("You've entered the logging place trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CabbinTrigger")
        {
            Debug.Log("You've exited the Cabbin, enabling roof.");
            cabbinRoof.SetActive(true);
        }

        if (other.gameObject.tag == "LoggingPlaceTrigger")
        {
            Debug.Log("You've left the logging place trigger");
        }
    }
}
