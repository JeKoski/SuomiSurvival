using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FridgeController : MonoBehaviour
{
    [SerializeField] private GameplayVariables gpv;
    [SerializeField] private GameplayMechanics gpm;
    [SerializeField] private ActionUIHandler auih;

    [SerializeField] private Slider beerCoolingMeter;
    [SerializeField] private float beerCoolingProgress = 0;
    [SerializeField] private float beerCoolingRate = 1.0f;

    [SerializeField] private GameObject fridgeSausageText;
    [SerializeField] private GameObject fridgeWarmBeerText;
    [SerializeField] private GameObject fridgeColdBeerText;


    void Start()
    {
        UpdateFridgeCounts();
    }

    void Update()
    {
        UpdateBeerCoolingMeter();
    }

    public void DepositAllBeerAndSausages()
    {
        gpv.fridgeSausageCount = gpv.fridgeSausageCount + gpv.playerSausages;
        gpv.playerSausages = 0;

        gpv.fridgeWarmBeerCount = gpv.fridgeWarmBeerCount + gpv.playerBeer;
        gpv.playerBeer = 0;

        UpdateFridgeCounts();

        auih.UpdateResourceUI();
    }

    public void TakeSausage()
    {
        if (gpv.fridgeSausageCount > 0)
        {
            gpv.fridgeSausageCount--;
            gpv.playerSausages++;
        }


        UpdateFridgeCounts();

        auih.UpdateResourceUI();
    }

    public void DrinkWarmBeer()
    {
        if (gpv.fridgeWarmBeerCount > 0)
        {
            gpv.fridgeWarmBeerCount--;

            gpv.playerThirst = gpv.playerThirst + gpv.warmBeerRestoreAmount;
        }

        UpdateFridgeCounts();

        auih.UpdateResourceUI();
    }

    public void DrinkColdBeer()
    {
        if (gpv.fridgeColdBeerCount > 0)
        {
            gpv.fridgeColdBeerCount--;

            gpv.playerThirst = gpv.playerThirst + gpv.coldBeerRestoreAmount;
        }

        UpdateFridgeCounts();

        auih.UpdateResourceUI();
    }

    private void UpdateBeerCoolingMeter()
    {
        if (gpv.fridgeWarmBeerCount > 0)
        {
            beerCoolingProgress = beerCoolingProgress + Time.deltaTime * beerCoolingRate;

            if (beerCoolingProgress >= 100)
            {
                gpv.fridgeWarmBeerCount--;
                gpv.fridgeColdBeerCount++;

                beerCoolingProgress = 0;

                UpdateFridgeCounts();
            }
        }

        beerCoolingMeter.value = beerCoolingProgress;
    }

    private void UpdateFridgeCounts()
    {
        fridgeSausageText.GetComponent<TextMeshProUGUI>().text = "X " + gpv.fridgeSausageCount;
        fridgeWarmBeerText.GetComponent<TextMeshProUGUI>().text = "X " + gpv.fridgeWarmBeerCount;
        fridgeColdBeerText.GetComponent<TextMeshProUGUI>().text = "X " + gpv.fridgeColdBeerCount;
    }
}
