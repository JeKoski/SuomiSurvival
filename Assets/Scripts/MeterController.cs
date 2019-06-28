using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterController : MonoBehaviour
{
    [Header("References:")]
    [SerializeField] private GameplayVariables gpv;
    [SerializeField] private Slider healthMeter;
    [SerializeField] private Slider coffeeMeter;
    [SerializeField] private Slider warmthMeter;
    [SerializeField] private Slider mosquitoesMeter;
    [SerializeField] private Slider hungerMeter;
    [SerializeField] private Slider thirstMeter;
    
    void Update()
    {
        UpdateMeters();
    }

    void UpdateMeters()
    {
        healthMeter.value = gpv.playerHealth;
        coffeeMeter.value = gpv.playerCoffee;
        warmthMeter.value = gpv.playerWarmth;
        mosquitoesMeter.value = gpv.playerMosquitoes;
        hungerMeter.value = gpv.playerHunger;
        thirstMeter.value = gpv.playerThirst;
    }
}
