using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMechanics : MonoBehaviour
{
    [Header("References:")]
    public GameplayVariables gpv;
    public GameObject player;
    public GameObject cabbinRoof;
    public GameObject playerStoreMarker;
    public static Vector2 playerStoreLocation;
    public GameObject playerInStoreTrigger;

    [Space]

    [Header("Functional Checks:")]
    [Tooltip("Is the sauna on?")]
    public bool saunaOn = false;
    public bool playerInMosquitoField = false;
    public bool playerInWater = false;
    public bool playerInSauna = false;
    public bool playerInStore = false;
    public bool playerInCabbin = false;
    public bool playerInLogging = false;
    public bool playerInTable = false;
    public bool playerInFridge = false;
    public bool playerInFireplace = false;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerStoreLocation = playerStoreMarker.transform.position;
        playerInStoreTrigger = GameObject.FindWithTag("PlayerInStoreTrigger");
        playerInStoreTrigger.SetActive(false);
        gpv.ResetAll();
    }
    
    void Update()
    {
        PlayerStatsUpdate();
    }

    void PlayerStatsUpdate()
    {
        if (!playerInCabbin)
        {
            gpv.playerCoffee = gpv.playerCoffee + Time.deltaTime * gpv.playerCoffeeRate;
            gpv.playerWarmth = gpv.playerWarmth + Time.deltaTime * gpv.playerWarmthRate;
            gpv.playerHunger = gpv.playerHunger + Time.deltaTime * gpv.playerHungerRate;
            gpv.playerThirst = gpv.playerThirst + Time.deltaTime * gpv.playerThirstRate;

            if (playerInSauna && saunaOn)
            {
                gpv.playerWarmth = gpv.playerWarmth + Time.deltaTime * gpv.playerWarmthSaunaRate;
            }
        }
        
        gpv.playerMosquitoes = gpv.playerMosquitoes + Time.deltaTime * gpv.playerMosquitoesDecayRate;

        ClampPlayerStats();
    }

    public void ClampPlayerStats()
    {
        gpv.playerHealth = Mathf.Clamp(gpv.playerHealth, 0.0f, 100.0f);
        gpv.playerCoffee = Mathf.Clamp(gpv.playerCoffee, 0.0f, 100.0f);
        gpv.playerWarmth = Mathf.Clamp(gpv.playerWarmth, -100.0f, 100.0f);
        gpv.playerHunger = Mathf.Clamp(gpv.playerHunger, 0.0f, 100.0f);
        gpv.playerThirst = Mathf.Clamp(gpv.playerThirst, 0.0f, 100.0f);
        gpv.playerMosquitoes = Mathf.Clamp(gpv.playerMosquitoes, 0.0f, 100.0f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "MosquitoField")
        {
            Debug.Log("You're in a Mosquito Field!");
            gpv.playerMosquitoes = gpv.playerMosquitoes + Time.deltaTime * gpv.playerMosquitoesRate;
        }

        if (other.gameObject.tag == "WaterTrigger")
        {
            Debug.Log("You're in water!");
            gpv.playerWarmth = gpv.playerWarmth + Time.deltaTime * gpv.playerWaterCoolingRate;
        }

        if (other.gameObject.tag == "SaunaTrigger")
        {
            Debug.Log("You're in the sauna!");

            if (saunaOn)
            {
                gpv.playerWarmth = gpv.playerWarmth + Time.deltaTime * gpv.playerWarmthSaunaRate;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MosquitoField")
        {
            Debug.Log("You've entered a Mosquito Field!");
            playerInMosquitoField = true;
        }

        if (other.gameObject.tag == "WaterTrigger")
        {
            Debug.Log("You're swimming!");
            playerInWater = true;
        }

        if (other.gameObject.tag == "SaunaTrigger")
        {
            Debug.Log("You've entered the sauna!");
            playerInSauna = true;
        }

        if (other.gameObject.tag == "SaweTrigger")
        {
            Debug.Log("You're entered the Store");
            // Move player to Store exit point

            playerInStoreTrigger.SetActive(true);
            player.transform.position = playerStoreLocation;
            playerInStore = true;
        }

        if (other.gameObject.tag == "PlayerInStoreTrigger")
        {
            playerInStore = true;
        }

        if (other.gameObject.tag == "CabbinTrigger")
        {
            Debug.Log("You've entered the Cabbin, disabling roof.");
            cabbinRoof.SetActive(false);
            playerInCabbin = true;
        }

        if (other.gameObject.tag == "LoggingPlaceTrigger")
        {
            Debug.Log("You've entered the logging place trigger");
            playerInLogging = true;
        }

        if (other.gameObject.tag == "CabbinTableTrigger")
        {
            Debug.Log("You've entered the cabbin table trigger");
            // Open menu to brew coffee?
            playerInTable = true;
        }

        if (other.gameObject.tag == "FridgeTrigger")
        {
            Debug.Log("You've entered the cabbin fridge trigger");
            // Open menu for getting/placing beer & sausages?'
            playerInFridge = true;
        }

        if (other.gameObject.tag == "FireplaceTrigger")
        {
            Debug.Log("You've entered the fireplace trigger");
            // Open menu for fireplace?
            playerInFireplace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MosquitoField")
        {
            Debug.Log("You've left the Mosquito Field!");
            playerInMosquitoField = false;
        }

        if (other.gameObject.tag == "WaterTrigger")
        {
            Debug.Log("You've stopped swimming!");
            playerInWater = false;
        }

        if (other.gameObject.tag == "SaunaTrigger")
        {
            Debug.Log("You've exited the sauna!");
            playerInSauna = false;
        }

        //if (other.gameObject.tag == "SaweTrigger")
        //{
            
        //}

        if (other.gameObject.tag == "PlayerInStoreTrigger")
        {
            Debug.Log("You've left the Store");
            playerInStore = false;
            playerInStoreTrigger.SetActive(false);
            // Close store window
        }

        if (other.gameObject.tag == "CabbinTrigger")
        {
            Debug.Log("You've exited the Cabbin, enabling roof.");
            cabbinRoof.SetActive(true);
            playerInCabbin = false;
        }

        if (other.gameObject.tag == "LoggingPlaceTrigger")
        {
            Debug.Log("You've left the logging place trigger");
            playerInLogging = false;
        }

        if (other.gameObject.tag == "CabbinTableTrigger")
        {
            Debug.Log("You've left the cabbin table trigger");
            // Close table menu
            playerInTable = false;
        }

        if (other.gameObject.tag == "FridgeTrigger")
        {
            Debug.Log("You've left the fridge trigger");
            // Close fridge menu
            playerInFridge = false;
        }

        if (other.gameObject.tag == "FireplaceTrigger")
        {
            Debug.Log("You've left the fireplace trigger");
            // Close menu for fireplace?
            playerInFireplace = false;
        }
    }
}
