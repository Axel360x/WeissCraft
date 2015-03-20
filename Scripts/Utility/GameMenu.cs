using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;


public class GameMenu : MonoBehaviour {
    bool activeMenu = false;
    World world;
	// Use this for initialization
	void Start () {
        world = GameObject.Find("World").GetComponent<World>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!activeMenu)
            {
                Screen.lockCursor = false;
                activeMenu = true;
                Time.timeScale = 0f;
            }
            else
            {
                Screen.lockCursor = true;
                Time.timeScale = 1f;
                activeMenu = false;
            }
        }
        if (!activeMenu && Time.timeScale == 0f)
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("Chunk");
            foreach (GameObject gg in go)
            {
                gg.GetComponent<Chunk>().old = true;
            }
        }
	}

    void OnGUI()
    {
        if (activeMenu)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 64, Screen.height / 2 - 32 - 128, 128, 64), "Save world"))
            {

                GameObject[] go = GameObject.FindGameObjectsWithTag("Chunk");
                foreach (GameObject gg in go)
                {
                    gg.GetComponent<Chunk>().old = true;
                }
                    //LoadSave.Save(userID, world.data);
                
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 64, Screen.height / 2, 128, 64), "Exit"))
            {

            }

        }
    }
}
