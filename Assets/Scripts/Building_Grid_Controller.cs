using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Grid_Controller : MonoBehaviour {//Grid handler for moveing around grid and placeing buildings. 

    public GameObject building_Grid;
    public string newBuilding;
    public Transform InstantiateMe;
    public List<GameObject> Buildings;
    private GameObject spawnedBuilding;
    public GameObject farm;
    public GameObject house;
    public GameObject archerTower;
    public GameObject stoneMason;
    public HouseGrid houseGridScript;

    void Update () { //Check if building mode is on if so Run PlaceBuilding
        if (UI_Settings.buildingModeOn == true)
        {

            Place_Building();

        }
	}

    public void TurnOnBuildingMode(int building)//Turns off build menu, turns on building grid and lets you build said building per argument
    {

        BuildMenu_ButtonController.Instance.buttonBuildMenu(false);//Turn of building menu
        UI_Settings.buildingModeOn = true;

        switch (building)//Sets the spawnable building as per argument
        {
            case 1:
                spawnedBuilding = farm;
                break;
            case 2:
                spawnedBuilding = house;
                break;
            case 3: spawnedBuilding = archerTower;
                break;
            case 4:
                spawnedBuilding = stoneMason;
                break;
        }

        if (PlayerRescources.Instance.money >= spawnedBuilding.GetComponent<Building>().cost)//Check to see if player can afford buying the building
        {
            PlayerRescources.Instance.money -= spawnedBuilding.GetComponent<Building>().cost;//Take money from player
            Place_Building();//Open grid mode

            Debug.Log(spawnedBuilding.GetComponent<Building>().cost);
        }
    }

    void Place_Building(){//Grid mode is activated allowing you to place down your building

        if (UI_Settings.buildingModeOn == true){

            building_Grid.SetActive(true);
            Vector3 mouse_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Get Mouse Location
            mouse_Pos.z = 0;
            mouse_Pos.y = -170;     

            float remainder = mouse_Pos.x % 32;
            float roundDown = mouse_Pos.x - remainder;
            float roundUp = roundDown + 32;
            //Debug.Log(roundDown);
            //Debug.Log(roundUp);

            float differenceUp = -Mathf.Abs(mouse_Pos.x - roundUp);
            float differenceDown = Mathf.Abs(mouse_Pos.x - roundDown);

            if (differenceUp < differenceDown) //Round transform location to nearest grid point.
            {
                mouse_Pos.x = roundUp;
             }
            else
            {
                mouse_Pos.x = roundDown;
            }

            Vector3 grid_Pos = mouse_Pos;
            mouse_Pos.x += 32;

            building_Grid.transform.position = new Vector3(grid_Pos.x-32, -105, 0);
            
            if (Input.GetMouseButtonDown(0)) // On leftClick place building
            {

                if (houseGridScript.isTouchingBuilding == false) //as long as the building isn't touching other buildings it's fine
                {
                    
                    var go = Instantiate(spawnedBuilding, mouse_Pos, transform.rotation);
                    spawnedBuilding.SetActive(true);
                    UI_Settings.buildingModeOn = false;
                    building_Grid.SetActive(false);
                    //Debug.Log("Placing Building");
                }

            }

            if (Input.GetMouseButtonDown(1))//If Rightclick close grid menu, cancel building.
            {
                UI_Settings.buildingModeOn = false;
                building_Grid.SetActive(false);
            }
        }
    }
}
