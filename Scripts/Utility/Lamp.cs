﻿using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (GetComponent<Light>().enabled)
                GetComponent<Light>().enabled = false;
            else
                GetComponent<Light>().enabled = true;
        }
	}
}
