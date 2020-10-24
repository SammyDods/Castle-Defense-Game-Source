using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour //This script handles mose of the UI's interactions as well as updating UI values.
{

    public Text food;
    public Text money;
    public Text stone;

    public Text upgradeCostStoneText;
    public Text upgradeCostMoneyText;

    public static Sprite newUpgradeSprite;

    public GameObject UpgradeMenu;
    public GameObject GameWinMenu;
    public GameObject GameInstrucMenu;
    public GameObject CurrentSelectedBuilding;
    
    public static UI_Controller Instance { get; private set; }    // Static singleton property

    void Awake()
    {
        Instance = this;// Save a reference as our singleton instance
        InvokeRepeating("UpdateUI", 0, 1.0f);
        CurrentSelectedBuilding = null;
        GameInstrucMenu.SetActive(true);
    }


    private void UpdateUI()//Certain UI elements display dynamic values, this function updates them
    {
        food.text = "Food: " + PlayerRescources.Instance.food.ToString();
        money.text = "Gold: " + PlayerRescources.Instance.money.ToString() + "/5000";
        stone.text = "Stone: " + PlayerRescources.Instance.stone.ToString();
        upgradeCostStoneText.text = "Stone: " + UI_Settings.upgradeCostStone.ToString();
        upgradeCostMoneyText.text = "Gold: " + UI_Settings.upgradeCostMoney.ToString();
    }

    void Update()//Checks if upgrade menu should be turned on
    {
        if (UI_Settings.upgradeMenuOn)
        {
            UpgradeMenu.SetActive(true);
        }  
    }

    public void TurnUpgradeMenuOn()//Sets Upgrade Menu as inactive
    {
        UpgradeMenu.SetActive(true);
        UI_Settings.upgradeMenuOn = false;
    }

    public void TurnUpgradeMenuOff()//Sets upgrade Menu as active
    {
        UpgradeMenu.SetActive(false);
        UI_Settings.upgradeMenuOn = false;

    }

    public void BuyBuildingUpgrade()//Upgrades the current selected building if the building is under lvl 3 and has enough rescources
    {
        Building currentBuildingScript = CurrentSelectedBuilding.GetComponent<Building>();
        /*
        Debug.Log(PlayerRescources.Instance.stone);
        Debug.Log(UI_Settings.upgradeCostStone);
        Debug.Log(PlayerRescources.Instance.money);
        Debug.Log(UI_Settings.upgradeCostMoney);
        */
        if ((PlayerRescources.Instance.stone >= UI_Settings.upgradeCostStone) && (PlayerRescources.Instance.money >= UI_Settings.upgradeCostMoney))//Checks if player has enough rescources
        {
            //Debug.Log("ok");

            if (currentBuildingScript.level < 3)//Checks if the building isn't max lvl.
            {
                UI_Settings.upgradeMenuOn = false;
                UI_Controller.Instance.TurnUpgradeMenuOff();
                CurrentSelectedBuilding.GetComponent<SpriteRenderer>().sprite = newUpgradeSprite;
                currentBuildingScript.maxHealth = currentBuildingScript.healthMultiplier * currentBuildingScript.level;//Applies property upgrades as well as visual upgrades.
                currentBuildingScript.health = currentBuildingScript.maxHealth;
                Debug.Log(currentBuildingScript.maxHealth);
                Debug.Log(currentBuildingScript.healthMultiplier);
                Debug.Log(currentBuildingScript.level);

                currentBuildingScript.level += 1;
                Debug.Log("Upgrading");

                PlayerRescources.Instance.stone -= UI_Settings.upgradeCostStone;//Charges upgrade cost
                PlayerRescources.Instance.money -= UI_Settings.upgradeCostMoney;
            }
        }
    }

    public void AttackGoblinCamp()//Checks if player has 5000 gold to win the game.
    {
        if (PlayerRescources.Instance.money >= 5000)
        {
            GameWinMenu.SetActive(true);
        }
    }

    public void CloseInstructionsScreen()// Sets instructions screen as inactive
    {
        GameInstrucMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
