using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterController : MonoBehaviour
{
    [Header("References:")]
    public GameplayVariables gpv;
    public Slider healthMeter;
    public Slider coffeeMeter;
    public Slider warmthMeter;
    public Slider mosquitoesMeter;
    public Slider hungerMeter;
    public Slider thirstMeter;
    
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
