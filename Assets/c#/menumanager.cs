﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menumanager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public void restart()
    {
        SceneManager.LoadScene("game");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    
}
