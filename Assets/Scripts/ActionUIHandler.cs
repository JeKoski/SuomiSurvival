using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionUIHandler : MonoBehaviour
{
    [SerializeField] private GameplayMechanics gpm;
    [SerializeField] private GameplayVariables gpv;
    private bool campfireBuilt = false;
    [SerializeField] private float popUpTimer = 5.0f;

    public Slider woodChoppingBar;
    public Slider buildCampfireBar;
    public Slider saunaOnBar;
    public Slider brewCoffeeBar;
    public Slider cookSausageBar;

    [SerializeField] private GameObject playerMoneyCount;
    [SerializeField] private GameObject firewoodCount;
    [SerializeField] private GameObject sausageCount;
    [SerializeField] private GameObject beerCount;
    [SerializeField] private GameObject coffeeCount;
    [SerializeField] private GameObject repellentCount;
    [SerializeField] private GameObject coldBeerBuffCount;

    [SerializeField] GameObject woodChoppingUI;
    private Vector2 woodChoppingShow = new Vector2(0.0f, -200.0f);
    private Vector2 woodChoppingAway = new Vector2(0.0f, 1000.0f);
    private bool woodChoppingIsAway = true;

    [SerializeField] GameObject buildCampfireUI;
    private Vector2 buildCampfireShow = new Vector2(0.0f, -200.0f);
    private Vector2 buildCampfireAway = new Vector2(-400.0f, 1000.0f);
    private bool buildCampfireIsAway = true;

    [SerializeField] private GameObject campfireInfoText;
    private Vector2 campfireInfoShow = new Vector2(0.0f, 200.0f);
    private Vector2 campfireInfoAway = new Vector2(-400.0f, 850.0f);
    private bool campfireinfoIsAway = true;

    [SerializeField] GameObject fireUpSaunaUI;
    private Vector2 fireUpSaunaShow = new Vector2(0.0f, -200.0f);
    private Vector2 fireUpSaunaAway = new Vector2(400.0f, 1000.0f);
    private bool fireUpSaunaIsAway = true;

    [SerializeField] private GameObject saunaInfoText;
    private Vector2 saunaInfoShow = new Vector2(0.0f, 200.0f);
    private Vector2 saunaInfoAway = new Vector2(400.0f, 850.0f);
    private bool saunaInfoIsAway = true;
    private bool saunaCheck = false;

    [SerializeField] private GameObject storeUI;
    private Vector2 storeUIShow = new Vector2(0.0f, 0.0f);
    private Vector2 storeUIHide = new Vector2(0.0f, -1500.0f);
    private bool storeUIIsAway = true;

    [SerializeField] private GameObject fridgeUI;
    private Vector2 fridgeUIShow = new Vector2(0.0f, 0.0f);
    private Vector2 fridgeUIHide = new Vector2(-1000.0f, -1500.0f);
    private bool fridgeUIIsAway = true;

    [SerializeField] private GameObject coffeeBrewUI;
    private Vector2 coffeeBrewUIShow = new Vector2(0.0f, -200.0f);
    private Vector2 coffeeBrewUIHide = new Vector2(800.0f, 1000.0f);
    private bool coffeeBrewUIIsAway = true;

    [SerializeField] private GameObject cookSausageUI;
    private Vector2 cookSausageUIShow = new Vector2(0.0f, -200.0f);
    private Vector2 cookSausageUIHide = new Vector2(-800.0f, 1000.0f);
    private bool cookSausageUIIsAway = true;

    [SerializeField] private GameObject metalDudePopupUI;
    private Vector2 metalDudePopupUIShow = new Vector2(-480.0f, 87.5f);
    private Vector2 metalDudePopupUIHide = new Vector2(-480.0f, -1500.0f);
    private bool metalDudePopupUIIsAway = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //MovePauseWindow();
        }

        if (gpm.playerInLogging)
        {
            ShowWoodChoppingBar();
        }

        else if (!gpm.playerInLogging)
        {
            HideWoodChoppingBar();
        }

        if (!gpm.campfireBuilt)
        {
            if (gpm.playerInFireplace)
            {
                ShowBuildCampfireBar();
                ShowCampfireInfo();
            }

            else if (!gpm.playerInFireplace)
            {
                HideBuildCampfireBar();
                HideCampfireInfo();
            }
        }

        if (gpm.campfireBuilt && !campfireBuilt)
        {
            HideBuildCampfireBar();
            HideCampfireInfo();
            campfireBuilt = true;
        }

        if (!gpm.saunaOn)
        {
            if (gpm.playerInSauna)
            {
                ShowFireUpSauna();
                ShowSaunaInfo();
            }

            else if (!gpm.playerInSauna)
            {
                HideFireUpSauna();
                HideSaunaInfo();
            }
        }

        if (gpm.saunaOn && !saunaCheck)
        {
            HideFireUpSauna();
            HideSaunaInfo();
            saunaCheck = true;
        }

        if (gpm.playerInStore)
        {
            ShowStoreUI();
        }

        else if (!gpm.playerInStore)
        {
            HideStoreUI();
        }

        if (gpm.playerInFridge)
        {
            ShowFridgeUI();
        }

        else if (!gpm.playerInFridge)
        {
            HideFridgeUI();
        }

        if (gpm.playerInTable)
        {
            ShowCoffeeBrewUI();
        }

        else if (!gpm.playerInTable)
        {
            HideCoffeeBrewUI();
        }

        if (gpm.playerInFireplace && gpm.campfireBuilt)
        {
            ShowCookSausageUI();
        }

        else if (!gpm.playerInFireplace || !gpm.campfireBuilt)
        {
            HideCookSausageUI();
        }

        UpdateProgressBars();
        UpdateResourceUI();
        MetalDude();
    }

    public void UpdateProgressBars()
    {
        buildCampfireBar.value = gpm.campfireBuildProgress;
        woodChoppingBar.value = gpm.chopWoodProgress;
        saunaOnBar.value = gpm.saunaOnProgress;
        brewCoffeeBar.value = gpm.coffeeBrewProgress;
        cookSausageBar.value = gpm.sausageProgress;
    }

    public void UpdateResourceUI()
    {
        gpv.playerMoney = System.Math.Round(gpv.playerMoney, 2);
        playerMoneyCount.GetComponent<TextMeshProUGUI>().text = gpv.playerMoney + " €";
        firewoodCount.GetComponent<TextMeshProUGUI>().text = "X " + gpv.playerFirewood;
        sausageCount.GetComponent<TextMeshProUGUI>().text = "X " + gpv.playerSausages;
        beerCount.GetComponent<TextMeshProUGUI>().text = "X " + gpv.playerBeer;
        coffeeCount.GetComponent<TextMeshProUGUI>().text = "X " + gpv.playerCoffeeCups;
        repellentCount.GetComponent<TextMeshProUGUI>().text = "X " + gpv.playerRepellent;
    }

    public void MoveWoodChoppingWindow()
    {
        if (woodChoppingIsAway)
        {
            woodChoppingUI.transform.localPosition = woodChoppingShow;
            woodChoppingIsAway = false;
        }

        else if (!woodChoppingIsAway)
        {
            woodChoppingUI.transform.localPosition = woodChoppingAway;
            woodChoppingIsAway = true;
        }
    }

    private void ShowWoodChoppingBar()
    {
        woodChoppingUI.transform.localPosition = woodChoppingShow;
    }

    private void HideWoodChoppingBar()
    {
        woodChoppingUI.transform.localPosition = woodChoppingAway;
    }

    private void ShowBuildCampfireBar()
    {
        buildCampfireUI.transform.localPosition = buildCampfireShow;
    }

    private void HideBuildCampfireBar()
    {
        buildCampfireUI.transform.localPosition = buildCampfireAway;
    }

    private void ShowCampfireInfo()
    {
        campfireInfoText.transform.localPosition = campfireInfoShow;
    }

    private void HideCampfireInfo()
    {
        campfireInfoText.transform.localPosition = campfireInfoAway;
    }

    private void ShowFireUpSauna()
    {
        fireUpSaunaUI.transform.localPosition = fireUpSaunaShow;
    }

    private void HideFireUpSauna()
    {
        fireUpSaunaUI.transform.localPosition = fireUpSaunaAway;
    }

    private void ShowSaunaInfo()
    {
        saunaInfoText.transform.localPosition = saunaInfoShow;
    }

    private void HideSaunaInfo()
    {
        saunaInfoText.transform.localPosition = saunaInfoAway;
    }

    private void ShowStoreUI()
    {
        storeUI.transform.localPosition = storeUIShow;
    }

    private void HideStoreUI()
    {
        storeUI.transform.localPosition = storeUIHide;
    }

    private void HideFridgeUI()
    {
        fridgeUI.transform.localPosition = fridgeUIHide;
    }

    private void ShowFridgeUI()
    {
        fridgeUI.transform.localPosition = fridgeUIShow;
    }

    private void HideCoffeeBrewUI()
    {
        coffeeBrewUI.transform.localPosition = coffeeBrewUIHide;
    }

    private void ShowCoffeeBrewUI()
    {
        coffeeBrewUI.transform.localPosition = coffeeBrewUIShow;
    }

    private void HideCookSausageUI()
    {
        cookSausageUI.transform.localPosition = cookSausageUIHide;
    }

    private void ShowCookSausageUI()
    {
        cookSausageUI.transform.localPosition = cookSausageUIShow;
    }

    private void MetalDude()
    {

        if (gpm.metalDudeTriggered)
        {
            ShowMetalDudePopup();
            UpdateColdBeerBuffCount();

            popUpTimer = popUpTimer - Time.deltaTime;

            if (popUpTimer <= 0)
            {
                gpm.metalDudeTriggered = false;
                HideMetalDudePopup();
                UpdateColdBeerBuffCount();
            }

        }
    }

    private void HideMetalDudePopup()
    {
        metalDudePopupUI.transform.localPosition = metalDudePopupUIHide;
    }

    private void ShowMetalDudePopup()
    {
        metalDudePopupUI.transform.localPosition = metalDudePopupUIShow;
    }

    public void UpdateColdBeerBuffCount()
    {
        coldBeerBuffCount.GetComponent<TextMeshProUGUI>().text = "x " + gpm.coldBeerRemaining;
    }
}
