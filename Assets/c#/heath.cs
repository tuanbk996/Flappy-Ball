using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heath : MonoBehaviour {

    public int heathbar = 100;
    public int currentheath=100;
    public Slider heathslider;
   
	// Use this for initialization
	void Start () {
        currentheath = heathbar;

    }
	
	// Update is called once per frame
	void Update () {
       
	}
    public void adddame()
    {
        currentheath -= 10;
        heathslider.value = currentheath;
    }
}
