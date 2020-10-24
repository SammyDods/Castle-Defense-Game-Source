using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Building //Subclass of Building: the StoneMason class is designed to be the source of rock, a lategame rescource for upgrades. 
{

    private void Awake() //Set properties of a farm
    {
        upgradeGoldCost = level * 150;
        upgradeStoneCost = level * 75;
        cost = 100;
        level = 1;
        healthMultiplier = 50;
        maxHealth = level * healthMultiplier;
        health = maxHealth;

        InvokeRepeating("GrowFood", 1.0f, 4.0f); //Begin CoRoutine
    }

    private void GrowFood() //CoRoutine that increases food levels, ideal ratio for farms is 1 for every 2 houses.
    {
        PlayerRescources.Instance.food += 20*level;
    }

}
