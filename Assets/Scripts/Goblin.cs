using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour //Goblin class, the enemy class in Castle Game
{

    public int speed;
    public int health;

    public bool isTouchingBuilding;
    public Building TouchedBuilding;

    private void Awake()//Set some defailt properties.
    {
        speed = 50;
        isTouchingBuilding = false;
        health = 1;// if health is zero goblin will be deleted right after instantiation.
    }

    void Update()//Check if goblin is touching a building and their health.
    {
        if (isTouchingBuilding == false)
        {
            HeadTowardBase();
        }
        if (isTouchingBuilding == true)//If touching building, damage the building
        {
            TouchedBuilding.health -= 1;
        }
        CheckGoblinHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)//Set isTouchingBuilding as true, get building object.
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            isTouchingBuilding = true;
            TouchedBuilding = collision.gameObject.GetComponent<Building>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)//Set isTouchingBuilding as true, get building object.
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            isTouchingBuilding = true;
            TouchedBuilding = collision.gameObject.GetComponent<Building>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)//Set isTouchingBuilding as false
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            isTouchingBuilding = false;
        }
    }

protected void HeadTowardBase()//Walk towards the players base
    {
        if (transform.position.x < 2)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (transform.position.x > 2)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
    }

    protected void CheckGoblinHealth()//Checks if health is 0, if health is zero the goblin destroys itself.
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
