using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayVariables", menuName = "SuomiSurvival/GameplayVariables")]
public class GameplayVariables : ScriptableObject
{
    //[Header("Starting Values Reference")]
    //[SerializeField] private StartingValues sv;

    [Header("Game World things")]
    [Range(0.0f, 1000.0f)]
    [Tooltip("How much time is left till the day is over")]
    public float timeOfDay = 1000.0f;

    [Tooltip("How fast time advances/drains")]
    public float timeScale = 1.0f;

    [Space]

    [Header("Player stats")]
    [Range(0.0f, 100.0f)]
    public float playerHealth;

    [Range(0.0f, 100.0f)]
    public float playerCoffee;

    [Range(-100.0f, 100.0f)]
    public float playerWarmth;

    [Range(0.0f, 100.0f)]
    public float playerMosquitoes;

    [Range(0.0f, 100.0f)]
    public float playerHunger;

    [Range(0.0f, 100.0f)]
    public float playerThirst;

    [Space]

    [Header("Player Items")]

    public double playerMoney;
    public int playerFirewood;
    public int playerSausages;
    public int playerBeer;
    public int playerCoffeeCups;
    public int playerRepellent;

    [Space]

    [Header("Damage Values")]

    public float drunkDriverDamage = 50.0f;
    public float bearDamage = 25.0f;

    [Space]

    [Header("Fridge Items")]

    public int fridgeSausageCount;
    public int fridgeWarmBeerCount;
    public int fridgeColdBeerCount;

    [Space]

    [Header("Item Costs")]

    public float sausageCost;
    public float beerCost;
    public float coffeeCost;
    public float repellentCost;

    [Space]

    [Header("Default Starting Values.")]

    [SerializeField] private float playerMoneyDefault = 20.0f;

    [SerializeField] private int playerFirewoodDefault = 0;

    [SerializeField] private int playerSausagesDefault = 0;

    [SerializeField] private int playerBeerDefault = 0;

    [SerializeField] private int playerCoffeeCupsDefault = 0;

    [SerializeField] private int playerRepellentDefault = 0;



    [SerializeField] private float sausageCostDefault = 3.0f;

    [SerializeField] private float beerCostDefault = 3.0f;

    [SerializeField] private float coffeeCostDefault = 3.0f;

    [SerializeField] private float repellentCostDefault = 3.0f;



    [Range(0.0f, 100.0f)]
    [SerializeField] private float playerHealthDefault = 100.0f;

    [Range(0.0f, 100.0f)]
    [SerializeField] private float playerCoffeeDefault = 50.0f;

    [Range(-100.0f, 100.0f)]
    [SerializeField] private float playerWarmthDefault = 0.0f;

    [Range(0.0f, 100.0f)]
    [SerializeField] private float playerMosquitoesDefault = 0.0f;

    [Range(0.0f, 100.0f)]
    [SerializeField] private float playerHungerDefault = 100.0f;

    [Range(0.0f, 100.0f)]
    [SerializeField] private float playerThirstDefault = 100.0f;

    [Range(0.0f, 1000.0f)]
    [SerializeField] private float timeOfDayDefault = 1000.0f;

    [Space]

    [Header("Player stat change rates")]
    [Tooltip("At what rate coffee level changes. Default: -0.5")]
    public float playerCoffeeRate = -0.5f;

    [Tooltip("How much coffee meter one cup of coffee restores")]
    public float playerCoffeeRestoreAmount = 50.0f;

    [Tooltip("How much coffee meter one raw coffee restores")]
    public float playerRawCoffeeRestoreAmount = 5.0f;

    [Tooltip("At what rate warmth level changes. Default: 0.5")]
    public float playerWarmthRate = 0.5f;

    [Tooltip("At what rate warmth level changes at night. Default -5.0")]
    public float playerWarmthRateNight = -5.0f;

    [Tooltip("At what rate warmth level increases in Sauna. Default: 5.0")]
    public float playerWarmthSaunaRate = 5.0f;

    [Tooltip("At what rate player loses warmth when in water. Default: -3.0")]
    public float playerWaterCoolingRate = -3.0f;

    [Tooltip("At what rate mosquito level increases when in field. Default: 0.5")]
    public float playerMosquitoesRate = 0.5f;

    [Tooltip("At what rate mosquito level decays")]
    public float playerMosquitoesDecayRate = -0.5f;

    [Tooltip("At what rate hunger level changes. Default: -0.5")]
    public float playerHungerRate = -0.5f;

    [Tooltip("At what rate thirst level changes. Default: -0.5")]
    public float playerThirstRate = -0.5f;

    [Tooltip("How much hunger a uncooked sausage restores")]
    public float coldSausageRestoreAmount = 10.0f;

    [Tooltip("How much hunger a cooked sausage restores")]
    public float cookedSausageRestoreAmount = 50.0f;

    [Tooltip("How much thirst a warm beer restores")]
    public float warmBeerRestoreAmount = 10.0f;

    [Tooltip("How much thirst a cold beer restores")]
    public float coldBeerRestoreAmount = 50.0f;

    public float warmBeerWarmthAmount = 20.0f;

    [Space]

    [Header("Misc.")]
    [Tooltip("When true, player can't move.")]
    public bool inputsDisabled = false;

    [Tooltip("Repellent effect check")]
    public bool repellentOn;


    public void ResetAll()
    {
        timeOfDay = timeOfDayDefault;
        inputsDisabled = false;
        repellentOn = false;

        playerMoney = playerMoneyDefault;
        playerFirewood = playerFirewoodDefault;
        playerSausages = playerSausagesDefault;
        playerBeer = playerBeerDefault;
        playerCoffeeCups = playerCoffeeCupsDefault;
        playerRepellent = playerRepellentDefault;

        fridgeSausageCount = 0;
        fridgeWarmBeerCount = 0;
        fridgeColdBeerCount = 0;

        sausageCost = sausageCostDefault;
        beerCost = beerCostDefault;
        coffeeCost = coffeeCostDefault;
        repellentCost = repellentCostDefault;

        playerHealth = playerHealthDefault;
        playerCoffee = playerCoffeeDefault;
        playerWarmth = playerWarmthDefault;
        playerMosquitoes = playerMosquitoesDefault;
        playerHunger = playerHungerDefault;
        playerThirst = playerThirstDefault;
    }

    public void CleanUpReset()
    {
        timeOfDay = timeOfDayDefault;
        inputsDisabled = false;
        repellentOn = false;
    }

    
}
