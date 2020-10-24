using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Settings : MonoBehaviour
{

    public static bool buildingModeOn;
    public static bool upgradeMenuOn;

    public static int upgradeCostMoney;
    public static int upgradeCostStone;


    void Start()    // Start is called before the first frame update

    {
        buildingModeOn = false;
        upgradeMenuOn = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
