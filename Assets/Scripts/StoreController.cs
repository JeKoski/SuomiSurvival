using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    [SerializeField] GameplayVariables gpv;

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
}
