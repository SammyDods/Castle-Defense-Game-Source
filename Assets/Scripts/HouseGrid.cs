using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGrid : MonoBehaviour //Building grid game object, checks for collisions with other buildings before placement
{
    public static HouseGrid Instance { get; private set; }    // Static singleton property
    public bool isTouchingBuilding;

    void Awake()
    {
        Instance = this; // Save as our singleton instance
        isTouchingBuilding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)//Detects buildings
    {  
        if (collision.gameObject.CompareTag("Building"))
        {
            isTouchingBuilding = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)//Detects buildings
    {
        if (collision.gameObject.CompareTag("Building"))
        {
        isTouchingBuilding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)//Sets IsTouchingBuilding to false
    {
        if (collision.gameObject.CompareTag("Building"))
        {
        isTouchingBuilding = false;
        }
    }
}
