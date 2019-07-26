using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceButtonsScript : MonoBehaviour
{
    [SerializeField] private GameplayVariables gpv;
    [SerializeField] private GameplayMechanics gpm;
    [SerializeField] private ActionUIHandler auih;
    
    public void ClickResourceSausage()
    {
        if (gpv.playerSausages > 0)
        {
            gpv.playerSausages--;
            gpv.playerHunger = gpv.playerHunger + gpv.coldSausageRestoreAmount;
            gpv.playerHealth = gpv.playerHealth + gpv.coldSausageRestoreAmount;
        }
    }

    public void ClickResourceBeer()
    {
        if (gpv.playerBeer > 0)
        {
            gpv.playerBeer--;
            gpv.playerThirst = gpv.playerThirst + gpv.warmBeerRestoreAmount;
        }
    }

    public void ClickResourceCoffee()
    {
        if (gpv.playerCoffeeCups > 0)
        {
            gpv.playerCoffeeCups--;
            gpv.playerCoffee = gpv.playerCoffee + gpv.playerRawCoffeeRestoreAmount;
        }
    }

    public void ClickResourceRepellent()
    {
        if (gpv.playerRepellent > 0)
        {
            gpv.playerRepellent--;
            gpv.repellentOn = true;
        }
    }

    public void ClickColdBeerBuff()
    {
        if (gpm.coldBeerRemaining > 0)
        {
            gpm.coldBeerRemaining--;
            gpv.playerThirst = gpv.playerThirst + gpv.coldBeerRestoreAmount;
            auih.UpdateColdBeerBuffCount();
        }

        if (gpm.coldBeerRemaining == 0)
        {
            gpm.coldBeerBuff.SetActive(false);
        }
    }
}
