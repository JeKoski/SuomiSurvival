using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionUIHandler : MonoBehaviour
{
    [SerializeField] private GameplayMechanics gpm;
    private bool campfireBuilt = false;

    public Slider woodChoppingBar;
    public Slider buildCampfireBar;
    public Slider saunaOnBar;

    public GameObject firewoodCount;

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

        UpdateProgressBars();
        UpdateResourceUI();
    }

    public void UpdateProgressBars()
    {
        buildCampfireBar.value = gpm.campfireBuildProgress;
        woodChoppingBar.value = gpm.chopWoodProgress;
        saunaOnBar.value = gpm.saunaOnProgress;
    }

    public void UpdateResourceUI()
    {
        firewoodCount.GetComponent<TextMeshProUGUI>().text = "X " + gpm.playerFirewood;
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
}
