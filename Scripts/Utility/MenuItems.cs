using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;


public class MenuItems : MonoBehaviour
{

    Texture2D tex;
    byte menuSet = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (menuSet == 0)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 64, Screen.height / 2 - 32 - 128, 128, 64), "Generate world!"))
            {
                LoadSave.loading = false;
                Application.LoadLevel("World");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 64, Screen.height / 2 - 32 - 128 + 128, 128, 64), "Load world"))
            {
                menuSet = 1;
            }
        }
        if (menuSet == 1)
        {
            worldMenu();
        }
        if (menuSet == 2)
        {
            // // // //
        }

    }

    void worldMenu()
    {

    }
}
