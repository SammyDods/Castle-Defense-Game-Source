using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building //Subclass of Building: the house class is designed to be the players gold stream.
{

    private void Awake()//Setting up properties of a house
    {
        upgradeGoldCost = level * 150;
        upgradeStoneCost = level * 100;
        cost = 100;
        level = 1;
        healthMultiplier = 50;
        maxHealth = level * healthMultiplier;
        health = maxHealth;
        InvokeRepeating("ReapTax", 1.0f, 5.0f); //Starts co-routine


    }

    private void ReapTax()//Collects money from house but at the cost of food
    {

        PlayerRescources.Instance.money += 15 * level;
        PlayerRescources.Instance.food -= 10 * level;

    }

    protected void CheckForFood()//Checks for food, if its less or equal to 0 the house is destroyed due to hunger.
    {

        if(PlayerRescources.Instance.food <= 0)
        {

            Destroy(gameObject);

        }

    }

    void Update()//Overloaded update function to include CheckForFood protocal
    {

        CheckForFood();
        CheckHealth();
        CheckForBuildingClick();

    }
}