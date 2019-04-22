using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleobject : MonoBehaviour {
   public float screenweith;
    private Vector2 screenbounds;
    public float XYZ;
    public float ypos;
    // Use this for initialization
    void Start () {
        screenweith = Screen.width;
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        XYZ = screenbounds.x;
        ypos= screenbounds.y;
        transform.localScale= new Vector3(XYZ*2, 1, 0);
        transform.position = new Vector3(0, -ypos-0.4f, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
