using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour // Spawns Goblins at an increasing rate over the game
{

    public GameObject GoblinSpawn;//Goblin prefab

    public Vector3 spawn1;
    public Vector3 spawn2;
    private Vector3 spawnPoint;
    private int waveNumber;
    private int randomNum;
    public int waveMultiplier;

    private void Awake()
    {
        spawn1 = new Vector3(-2500, -169, 0);
        spawn2 = new Vector3(2500, -169, 0);

        waveNumber = 1;
        GoblinSpawn = Resources.Load<GameObject>("Prefabs/Enemys/Goblin");

        InvokeRepeating("SpawnGoblinWave", 1.0f, 10.0f);//Start CoRoutine
    }

    private void SpawnGoblinWave()//Spawn Goblins that increase in number and health per wave.
    {
        for (int x = 1; x <= (waveNumber*2); x++)
        {
            SpawnGoblin(50 + (2 * waveNumber), 75);
        }
    }
    
    private void SpawnGoblin(int goblinHealth, int goblinSpeed) //Instantiates Goblins randomly to either side of map. Accepts health and speed as parameters.
    {
        randomNum = Random.Range(0, 2);

        if (randomNum == 0)
        {

            spawnPoint = spawn1;

        }
        if (randomNum == 1)//Choosing spawn location
        {

            spawnPoint = spawn2;

        }
        spawnPoint.x += Random.Range(-100, 100);

        var go = Instantiate(GoblinSpawn, spawnPoint, transform.rotation);
        GoblinSpawn.SetActive(true);

        Goblin goblinScript = go.GetComponent<Goblin>();//Set Goblin location

        goblinScript.health = goblinHealth;
        goblinScript.speed = goblinSpeed;

        //Debug.Log(goblinScript.health);
    }
}
