using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMechanics : MonoBehaviour
{
    [Header("References:")]
    [SerializeField] private GameplayVariables gpv;

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


        //if (player is in mosquito field) {gpv.playerMosquitoes = gpv.playerMosquitoes - Time.deltaTime * gpv.playerMosquitoesRate;}
    }
}
