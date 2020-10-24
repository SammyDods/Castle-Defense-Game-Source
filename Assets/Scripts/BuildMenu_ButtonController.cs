using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu_ButtonController : MonoBehaviour {//Opens and closes building Menu

    public bool buildMenuStatus;
    public GameObject buildMenu;

    public static BuildMenu_ButtonController Instance { get; private set; }     // Static singleton property

    void Awake()
    {
        Instance = this;  // Save as our singleton instance
        buildMenuStatus = false;

    }

    public void buttonBuildMenu()  {        //Sets building menu's active state to it's opposite state.
        Debug.Log("Accesing build Menu");
        if(buildMenuStatus == true) {

            buildMenuStatus = false;
            buildMenu.SetActive(false);
        }
        else{

            buildMenuStatus = true;
            buildMenu.SetActive(true); 
        }
    }

    public void buttonBuildMenu(bool status) //Overloaded function turns build button UI on/off with a boolean
    {       
        Debug.Log("Accesing build Menu");
        if (status == true)
        {

            buildMenuStatus = true;
            buildMenu.SetActive(true);
        }
        else
        {

            buildMenuStatus = false;
            buildMenu.SetActive(false);
        }
    }

    private void Update(){ // If "B" is pressed build UI is opened.
        if (Input.GetKeyDown(KeyCode.B)) 
        {
            buttonBuildMenu();
        }
    }
}
