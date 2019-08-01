using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingValueController : MonoBehaviour
{
    [SerializeField] private GameplayVariables gpv;
    [SerializeField] private StartingValues sv;

    void Start()
    {
        SetStartingValues();
    }

    public void SetStartingValues()
    {
        gpv.CleanUpReset();

        gpv.timeOfDay = sv.startingTimeOfDay;
        gpv.timeScale = sv.startingTimeScale;

        gpv.playerMoney = sv.startingMoney;
        gpv.playerFirewood = sv.startingFirewood;
        gpv.playerSausages = sv.startingSausages;
        gpv.playerBeer = sv.startingBeer;
        gpv.playerCoffeeCups = sv.startingCoffeeCups;
        gpv.playerRepellent = sv.startingRepellent;

        gpv.fridgeSausageCount = sv.startingFridgeSausages;
        gpv.fridgeWarmBeerCount = sv.startingFridgeBeer;
        gpv.fridgeColdBeerCount = sv.startingFridgeColdBeer;

        gpv.sausageCost = sv.startingSausageCost;
        gpv.beerCost = sv.startingBeerCost;
        gpv.coffeeCost = sv.startingCoffeeCost;
        gpv.repellentCost = sv.startingRepellentCost;

        gpv.playerHealth = sv.startingPlayerHealth;
        gpv.playerCoffee = sv.startingPlayerCoffee;
        gpv.playerWarmth = sv.startingPlayerWarmth;
        gpv.playerMosquitoes = sv.startingPlayerMosquitoes;
        gpv.playerHunger = sv.startingPlayerHunger;
        gpv.playerThirst = sv.startingPlayerThirst;
    }
}
