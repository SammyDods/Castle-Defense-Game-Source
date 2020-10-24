using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour//Base class for buildings. As an abstract class it provides basic functionality but cannot be instantiatied on its own.
{
    
    protected string type;
    public int level;
    public int cost;
    public int maxHealth;
    public int health;
    public int healthMultiplier;
    protected int upgradeStoneCost;
    protected int upgradeGoldCost;

    public Sprite[] upgradeSprites;

    virtual protected void CheckForBuildingClick() //Depending on what building is clicked the upgrade menu is opened and optimized.
    {

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mouse_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D>();
            Debug.Log("Clicked");

            if (coll.OverlapPoint(mouse_Pos))
            {

                UI_Settings.upgradeMenuOn = true;

                UI_Controller.Instance.TurnUpgradeMenuOn();

                UI_Settings.upgradeCostMoney = upgradeGoldCost * level;
                UI_Settings.upgradeCostStone = upgradeStoneCost * level;
                UI_Controller.newUpgradeSprite = upgradeSprites[level - 1];
                UI_Controller.Instance.CurrentSelectedBuilding = gameObject;

                Debug.Log("Clicked Building");

            }
        }
    }
       
    virtual protected void CheckHealth() //If Building health is 0 or below it is destroyed
    {

        if (health <= 0)
        {

            Destroy(gameObject);

        }

    }

    void Update() //Basic functionbality of buildings, checking for health and clicks for upgrades.
    {

        CheckHealth();
        CheckForBuildingClick();

    }
}
