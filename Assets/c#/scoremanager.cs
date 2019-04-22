using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoremanager : MonoBehaviour {
    public Text scoretext;
    public int score = 0;
    float randomcolor;
	// Use this for initialization
	void Start () {
		randomcolor= Random.Range(0, 1);
        

    }

    
    // Update is called once per frame
    void Update () {
        scoretext.text = score.ToString();
	}
    public void addscore()
    {
        score += 1;
       Camera.main.backgroundColor = Color.HSVToRGB(randomcolor, 0.6f, 0.8f);
        randomcolor += 0.05f;
        if (randomcolor > 1)
        {
            randomcolor = 0;
        }
    }

}
