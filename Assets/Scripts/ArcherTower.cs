using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Building //Subclass of Building: the ArcherTower class is meant to be the defence building to hold off goblins as players increase their rescources.
{

    protected GameObject NextTarget;
    protected int towerRange;
    protected int arrowSpeed;
    protected float nextFire;
    protected float fireRate;
    protected Vector3 spawnPoint;
    protected Transform target;
    public GameObject arrow;

    private void Awake()//Set properties of an archer tower
    {
        upgradeGoldCost = level * 150;
        upgradeStoneCost = level * 125;

        cost = 50;
        level = 1;
        healthMultiplier = 300;
        maxHealth = level * healthMultiplier;
        health = maxHealth;
        towerRange = 400;
        arrowSpeed = 1000;

        fireRate = 0.5f;
        nextFire = 0.0f;
        spawnPoint = gameObject.transform.position;
        spawnPoint.y += 250;

        InvokeRepeating("findTarget", 0, 1.0f);
        arrow = Resources.Load<GameObject>("Prefabs/Arrow");
    }

    protected void findTarget()//Find the closest Goblin Target then fire arrow
    {
        GameObject[] goblinArray = GameObject.FindGameObjectsWithTag("Goblin");

        float distanceDetect = Mathf.Infinity;
        Transform closestTargetPosition = null;

        foreach(GameObject taggedTarget in goblinArray)//Find closest goblin
        {
            float distance = (taggedTarget.transform.position - transform.position).magnitude;
            if (distance <= towerRange)
            {
                if (distance <= distanceDetect)
                {
                    distanceDetect = distance;
                    closestTargetPosition = taggedTarget.transform;
                    NextTarget = taggedTarget;
                }
            }
        }
        if (NextTarget!= null) //if goblin isn't dead, shoot
        {
            target = closestTargetPosition;
            shoot();
            NextTarget = null;
        }    
    }
    
    protected void shoot()//Instantiate arrow object and give it it's target
    {
        GameObject projectile = (GameObject)Instantiate(arrow, spawnPoint, transform.rotation);
        //Debug.Log("arrow = " + arrow.transform.position);
        arrow.SetActive(true);
        arrow.GetComponent<Arrow>().ArrowTarget = NextTarget;   
        //Debug.Log("Shooting");
    }
}