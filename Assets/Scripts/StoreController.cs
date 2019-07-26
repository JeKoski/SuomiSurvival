using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StoreController : MonoBehaviour
{
    [SerializeField] GameplayVariables gpv;

    [Header("Store Prices Updates")]
    [SerializeField] private GameObject sausagePrice;
    [SerializeField] private GameObject beerPrice;
    [SerializeField] private GameObject coffeePrice;
    [SerializeField] private GameObject repellentPrice;


    private void Start()
    {
        SetStorePriceTags();
    }

    public void BuySausage()
    {
        if (gpv.playerMoney >= gpv.sausageCost)
        {
            gpv.playerSausages++;
            gpv.playerMoney = gpv.playerMoney - gpv.sausageCost;
        }
    }

    public void BuyBeer()
    {
        if (gpv.playerMoney >= gpv.beerCost)
        {
            gpv.playerBeer++;
            gpv.playerMoney = gpv.playerMoney - gpv.beerCost;
        }
    }

    public void BuyCoffee()
    {
        if (gpv.playerMoney >= gpv.coffeeCost)
        {
            gpv.playerCoffeeCups++;
            gpv.playerMoney = gpv.playerMoney - gpv.coffeeCost;
        }
    }

    public void BuyRepellent()
    {
        if (gpv.playerMoney >= gpv.repellentCost)
        {
            gpv.playerRepellent++;
            gpv.playerMoney = gpv.playerMoney - gpv.repellentCost;
        }
    }

    public void ExitStore()
    {
        // When clicking Exit store
    }

    private void SetStorePriceTags()
    {
        sausagePrice.GetComponent<TextMeshProUGUI>().text = gpv.sausageCost + " €";
        beerPrice.GetComponent<TextMeshProUGUI>().text = gpv.beerCost + " €";
        coffeePrice.GetComponent<TextMeshProUGUI>().text = gpv.coffeeCost + " €";
        repellentPrice.GetComponent<TextMeshProUGUI>().text = gpv.repellentCost + " €";
    }
}
