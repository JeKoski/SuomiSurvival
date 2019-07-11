using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayVariables", menuName = "SuomiSurvival/GameplayVariables")]
public class GameplayVariables : ScriptableObject
{
    [Header("Game World things")]
    [Range(0.0f, 1000.0f)]
    public float timeOfDay = 1000.0f;

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

    [Header("Default Starting Values.")]
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

    [Tooltip("At what rate warmth level changes. Default: 0.5")]
    public float playerWarmthRate = 0.5f;

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

    [Space]

    [Header("Misc.")]
    [Tooltip("When true, player can't move.")]
    public bool inputsDisabled = false;

    public void ResetAll()
    {
        timeOfDay = timeOfDayDefault;
        inputsDisabled = false;

        playerHealth = playerHealthDefault;
        playerCoffee = playerCoffeeDefault;
        playerWarmth = playerWarmthDefault;
        playerMosquitoes = playerMosquitoesDefault;
        playerHunger = playerHungerDefault;
        playerThirst = playerThirstDefault;
    }
}
