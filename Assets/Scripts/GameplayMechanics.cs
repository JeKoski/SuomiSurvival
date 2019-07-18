using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayMechanics : MonoBehaviour
{
    [Header("References:")]
    [Tooltip("GameplayVariables Data Package")]
    public GameplayVariables gpv;
    private GameObject player;
    [Tooltip("GameObject to disable when player walks into the cabbin")]
    public GameObject cabbinRoof;
    public GameObject playerStoreMarker;
    public static Vector2 playerStoreLocation;
    private GameObject playerInStoreTrigger;
    [SerializeField] GameObject playerSpawnPoint;
    [SerializeField] GameObject playerCabbinPoint;

    [Space]

    [Header("Functional Checks:")]
    [Tooltip("Is the sauna on?")]
    public bool saunaOn = false;
    public bool campfireBuilt = false;
    public bool playerInMosquitoField = false;
    public bool playerInWater = false;
    public bool playerInSauna = false;
    public bool playerInStore = false;
    public bool playerInCabbin = false;
    public bool playerInLogging = false;
    public bool playerInTable = false;
    public bool playerInFridge = false;
    public bool playerInFireplace = false;
    public bool playerDead = false;

    [Space]

    [Header("Action variables")]
    public int firewoodRequiredForSauna = 3;
    public float saunaOnProgress = 0.0f;
    public float saunaOnProgressRate = 30.0f;
    public int firewoodRequiredForCampfire = 5;
    public float campfireBuildProgress = 0.0f;
    public float campfireBuildProgressRate = 30.0f;
    public float chopWoodProgress = 0.0f;
    public float chopWoodProgressRate = 20.0f;

    [Space]

    [Header("Night Time Overlay stuff")]

    [SerializeField] private GameObject nightTimeOverlay;
    [SerializeField] private SpriteRenderer nightTimeSprite;
    [SerializeField] private Color nightTimeColor = new Color(15, 0, 50);
    [SerializeField] private float nightTimeOverlayAlpha;
    [SerializeField] private float nightTimeTargetAlpha;
    [SerializeField] private float nightTimeGradMax = 1.0f;
    [SerializeField] private float nightTimeGradMin = 0.0f;
    [SerializeField] private float nightTimeGradOffset = 0.2f;
    [SerializeField] private float nightTimeColorBlendTime = 5.0f;

    [Space]

    [Header("dunno lol")]
    [SerializeField] private float inputDelay = 1.0f;
    [SerializeField] private float inputDelayTimer = 0.0f;
    private bool freezePlayer = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerStoreLocation = playerStoreMarker.transform.position;
        playerInStoreTrigger = GameObject.FindWithTag("PlayerInStoreTrigger");
        playerInStoreTrigger.SetActive(false);
        MovePlayerToSpawn();
        gpv.ResetAll();

        nightTimeColor.a = nightTimeGradMax;
    }
    
    void Update()
    {
        // Update thingies
        GameTimeUpdate();
        PlayerStatsUpdate();
        NightOverlayUpdater();

        // Actions
        BuildCampfire();
        FireUpSauna();
        ChopWood();

        // System things
        DisableInputsForABit();
        CheckIfPlayerIsDead();
    }

    void GameTimeUpdate()
    {
        if (gpv.timeOfDay > 0)
        {
            gpv.timeOfDay = gpv.timeOfDay - Time.deltaTime * gpv.timeScale;
        }

        else
        {
            Mathf.Clamp(gpv.timeOfDay, 0.0f, 1000.0f);
        }
    }

    void NightOverlayUpdater()
    {
        if (gpv.timeOfDay < 500.0f)
        {
            nightTimeTargetAlpha = nightTimeGradMax - (gpv.timeOfDay / 1000.0f * (nightTimeGradMax - nightTimeGradMin) + nightTimeGradOffset);
        }

        if (!playerDead)
        {
            nightTimeColor.a = nightTimeTargetAlpha;
        }

        else if (playerDead)
        {
            nightTimeTargetAlpha = 1f;
        }

        Mathf.Clamp(nightTimeTargetAlpha, 0.0f, 1.0f);
        nightTimeSprite.color = Color.Lerp(nightTimeSprite.color, nightTimeColor, Time.deltaTime * nightTimeColorBlendTime);
    }

    void MovePlayerToSpawn()
    {
        transform.position = playerSpawnPoint.transform.position;
    }

    void MovePlayerToCabbin()
    {
        transform.position = playerCabbinPoint.transform.position;
    }

    void CheckIfPlayerIsDead()
    {
        if (gpv.playerHealth <= 0)
        {
            playerDead = true;
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        Application.Quit();
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

            freezePlayer = true;
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

        if (other.gameObject.tag == "DrunkDriver")
        {
            MovePlayerToCabbin();
            gpv.playerHealth = gpv.playerHealth - gpv.drunkDriverDamage;
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

    public void DisableInputsForABit()
    {
        if (freezePlayer)
        {
            gpv.inputsDisabled = true;

            inputDelayTimer = inputDelayTimer + Time.deltaTime;

            if (inputDelayTimer > inputDelay)
            {
                gpv.inputsDisabled = false;
                freezePlayer = false;
                inputDelayTimer = 0;
            }
        }
    }

    private void BuildCampfire()
    {
        if (playerInFireplace && !campfireBuilt && Input.GetKey(KeyCode.E) && gpv.playerFirewood >= firewoodRequiredForCampfire)
        {
            campfireBuildProgress = campfireBuildProgress + (Time.deltaTime * campfireBuildProgressRate);

            if (campfireBuildProgress >= 100.0f)
            {
                campfireBuilt = true;
                campfireBuildProgress = 0.0f;
                gpv.playerFirewood = gpv.playerFirewood - firewoodRequiredForCampfire;
            }
        }
    }

    private void ChopWood()
    {
        if (playerInLogging && Input.GetKey(KeyCode.E))
        {
            chopWoodProgress = chopWoodProgress + (Time.deltaTime * chopWoodProgressRate);

            if (chopWoodProgress >= 100.0f)
            {
                gpv.playerFirewood = gpv.playerFirewood + 2;
                chopWoodProgress = 0;
            }
        }

        if (!playerInLogging)
        {
            chopWoodProgress = 0.0f;
        }
    }

    private void FireUpSauna()
    {
        if (playerInSauna && !saunaOn && Input.GetKey(KeyCode.E) && gpv.playerFirewood >= firewoodRequiredForSauna)
        {
            saunaOnProgress = saunaOnProgress + (Time.deltaTime * saunaOnProgressRate);

            if (saunaOnProgress >= 100.0f)
            {
                saunaOn = true;
                saunaOnProgress = 0.0f;
                gpv.playerFirewood = gpv.playerFirewood - firewoodRequiredForSauna;
            }
        }
    }
}
