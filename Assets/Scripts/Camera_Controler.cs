using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controler : MonoBehaviour {//Based on "a" or"d" keys the camera is moved in a given direction

    public float camera_Speed;//Multiplier for how fast the camera moves
    public int mapLimit;

    public void Awake()
    {
        mapLimit = 2000;
    }

    void Update()//Detects if keys are pressed and if the camera is not at the map edge to then move the camera.
    {
        if ((Input.GetKey(KeyCode.D)) && (transform.position.x <= mapLimit))
        {
            transform.Translate(new Vector3(camera_Speed * Time.deltaTime, 0, 0));
        }
        if ((Input.GetKey(KeyCode.A)) && (transform.position.x >= -mapLimit))
        {
            transform.Translate(new Vector3(-camera_Speed * Time.deltaTime, 0, 0));
        }
        /*
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -camera_Speed * Time.deltaTime, 0));
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, camera_Speed * Time.deltaTime, 0));
        }*/
    }
}

