using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class highscoremanager : MonoBehaviour {
    public Text highscoretext;
	// Use this for initialization
	void Start () {
        highscoretext.text ="Highscore: "+ PlayerPrefs.GetInt("highscore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
