using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    [SerializeField] private GameplayVariables gpv;
    // [SerializeField] private GameplayMechanics gpm;

    [SerializeField] private GameObject mineExplosion;
    [SerializeField] private GameObject mineNotification;
    [SerializeField] private GameObject mineParent;
    //[SerializeField] private GameObject mineComponents;

    [SerializeField] private bool mineTriggered = false;
    [SerializeField] private bool mineExploded = false;
    [SerializeField] private bool playerInDangerZone = false;
    [SerializeField] private float mineDelay = 0.6f;
    [SerializeField] private float mineTimer = 0.0f;

    private void Awake()
    {
        mineNotification = gameObject.transform.Find("MineNotificationBG").gameObject;
        //mineComponents = gameObject.transform.Find("MineComponents").gameObject;
    }

    private void Start()
    {
        mineNotification.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mineTriggered = true;
            playerInDangerZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInDangerZone = false;
        }
    }

    private void Update()
    {
        if (mineTriggered)
        {
            mineTimer = mineTimer + Time.deltaTime;
            mineNotification.SetActive(true);

            if (mineTimer > mineDelay)
            {
                if (playerInDangerZone)
                {
                    gpv.playerHealth = gpv.playerHealth - 100;
                }

                Instantiate(mineExplosion, transform.position, Quaternion.Euler(0, 0, 0));

                mineNotification.SetActive(false);

                mineExploded = true;
                gameObject.SetActive(false);
                mineParent.SetActive(false);
            }
        }
    }
}
