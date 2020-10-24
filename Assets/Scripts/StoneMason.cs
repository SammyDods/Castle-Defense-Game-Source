using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMason : Building //Subclass of Building: the StoneMason class is designed to be the source of rock, a lategame rescource for upgrades. 
{

    private void Awake()//Setting up properties of StoneMason
    {
        level = 1;
        healthMultiplier = 200;
        maxHealth = level * healthMultiplier;
        health = maxHealth;
        cost = 150;

        upgradeGoldCost = level * 150;
        upgradeStoneCost = level * 50;

        InvokeRepeating("GetStone", 1.0f, 6.0f);//Begins coRoutine

    }

    private void GetStone() //CoRoutine that collects stone per level
    {

        PlayerRescources.Instance.stone += 15*level;

    }


}
