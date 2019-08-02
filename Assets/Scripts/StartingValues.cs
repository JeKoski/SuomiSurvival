using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StartingValues", menuName = "SuomiSurvival/StartingValues")]
public class StartingValues : ScriptableObject
{
    [Range(0.0f, 1000.0f)]
    public float startingTimeOfDay = 1000.0f;
    public float startingTimeScale = 2.0f;
    
    [Space]

    public float startingWarmthRate = 0.5f;
    public float startingWarmthRateNight = -5.0f;

    [Space]

    public float startingMoney = 20;
    public int startingFirewood = 0;
    public int startingSausages = 0;
    public int startingBeer = 0;
    public int startingCoffeeCups = 0;
    public int startingRepellent = 0;

    [Space]

    public int startingFridgeSausages = 0;
    public int startingFridgeBeer = 0;
    public int startingFridgeColdBeer = 0;

    [Space]

    public float startingSausageCost = 3.0f;
    public float startingBeerCost = 3.0f;
    public float startingCoffeeCost = 3.0f;
    public float startingRepellentCost = 3.0f;

    [Space]

    [Range(0.0f, 100.0f)]
    public float startingPlayerHealth = 100.0f;

    [Range(0.0f, 100.0f)]
    public float startingPlayerCoffee = 100.0f;

    [Range(-100.0f, 100.0f)]
    public float startingPlayerWarmth = 0.0f;

    [Range(0.0f, 100.0f)]
    public float startingPlayerMosquitoes = 0.0f;

    [Range(0.0f, 100.0f)]
    public float startingPlayerHunger = 100.0f;

    [Range(0.0f, 100.0f)]
    public float startingPlayerThirst = 100.0f;
}
