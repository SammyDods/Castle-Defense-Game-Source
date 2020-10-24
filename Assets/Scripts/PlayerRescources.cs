using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRescources : MonoBehaviour // Holds game data for player
{
    public int money;
    public int wood;
    public int food;
    public int stone;
    public int numHouses;
    public int population;

    public static PlayerRescources Instance { get; private set; }    // Static singleton property

    void Awake()//Starting Rescources
    {
        Instance = this;        // Save as our singleton instance

        food = 500;
        money = 1000;
        stone = 0;
        //numHouses = 1;
    }

}
