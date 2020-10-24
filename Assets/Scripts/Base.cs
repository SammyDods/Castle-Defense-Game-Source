using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Building //Subclass of Building: the Base class is the players main building, and if destroyed will cause the player to lose the game.
{

    public GameObject GameEndMenu;// UI element for end of game screen

    private void Awake()//Set properties of a base
    {
        cost = 100;
        level = 1;
        healthMultiplier = 400;
        maxHealth = level * healthMultiplier;
        health = maxHealth;

        upgradeGoldCost = level * 200;
        upgradeStoneCost = level * 150;
    }

    override protected void CheckHealth()//Overloaded CheckHealth function from the Building class, the base has to end the game when it get's destroyed.
    {
        if (health <= 0)
        {
            GameEndMenu.SetActive(true);
            Destroy(gameObject);
        }
    }
}