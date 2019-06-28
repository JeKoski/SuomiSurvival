using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayVariables", menuName = "SuomiSurvival/GameplayVariables")]
public class GameplayVariables : ScriptableObject
{
    [Header("Player stats")]
    [Range(0.0f, 100.0f)]
    public float playerHealth;
    [Range(0.0f, 100.0f)]
    private float playerHealthDefault = 100.0f;

    [Range(0.0f, 100.0f)]
    public float playerCoffee;
    [Range(0.0f, 100.0f)]
    private float playerCoffeeDefault = 50.0f;

    [Range(-100.0f, 100.0f)]
    public float playerWarmth;
    [Range(-100.0f, 100.0f)]
    private float playerWarmthDefault = 0.0f;

    [Range(0.0f, 100.0f)]
    public float playerMosquitoes;
    [Range(0.0f, 100.0f)]
    private float playerMosquitoesDefault = 0.0f;

    [Range(0.0f, 100.0f)]
    public float playerHunger;
    [Range(0.0f, 100.0f)]
    private float playerHungerDefault = 100.0f;

    [Range(0.0f, 100.0f)]
    public float playerThirst;
    [Range(0.0f, 100.0f)]
    private float playerThirstDefault = 100.0f;

    [Space]

    [Header("Player stat change rates")]
    [Tooltip("How fast coffee level changes. Default: -0.5")]
    public float playerCoffeeRate = -0.5f;

    [Tooltip("How fast warmth level changes. Default: 0.5")]
    public float playerWarmthRate = 0.5f;

    [Tooltip("How fast mosquito level changes. Default: 0.5")]
    public float playerMosquitoesRate = 0.5f;

    [Tooltip("How fast hunger level changes. Default: -0.5")]
    public float playerHungerRate = -0.5f;

    [Tooltip("How fast thirst level changes. Default: -0.5")]
    public float playerThirstRate = -0.5f;



    public void ResetAll()
    {
        playerHealth = playerHealthDefault;
        playerCoffee = playerCoffeeDefault;
        playerWarmth = playerWarmthDefault;
        playerMosquitoes = playerMosquitoesDefault;
        playerHunger = playerHungerDefault;
        playerThirst = playerThirstDefault;
    }
}
