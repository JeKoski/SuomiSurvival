using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMechanics : MonoBehaviour
{
    [Header("References:")]
    public GameplayVariables gpv;
    

    void Start()
    {
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
            Debug.Log("Colliding with Mosquito Field");
            gpv.playerMosquitoes = gpv.playerMosquitoes + Time.deltaTime * gpv.playerMosquitoesRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SaweTrigger")
        {
            Debug.Log("Entering Store");
            // Move player to Store exit point
        }
    }
}
