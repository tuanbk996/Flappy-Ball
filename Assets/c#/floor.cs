using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour {
    float angle = 0f;
    public float velocity = 1;
    float distance;//= 3f;
   // player playerscript;
   // private Vector2 screenbounds;
    // Use this for initialization
    void Start()
    {
       // playerscript = GameObject.Find("player").GetComponent<player>();

        //screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //distance = screenbounds.x;
        distance = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerscript.isdead == true) return;
        if(GameObject.Find("scoremanager").GetComponent<scoremanager>().score > 77)
        {
            distance = 3f;
        }
        
            Move();
       
    }
    private void Move()
    {

        // transform.position = new Vector2(Mathf.Sin(angle) * distance, transform.position.y);
        transform.position = new Vector2(transform.position.x, Mathf.Sin(angle) * distance);
        angle += velocity / 100f;
    }
    //public IEnumerator landingeffect()
    //{
    //    Vector2 originalposition = transform.position;
    //    float ychangevalue = 0.7f;
    //    while (ychangevalue > 0)
    //    {
    //        ychangevalue -= 0.1f;
    //        ychangevalue = Mathf.Clamp(ychangevalue, 0, 1.5f);
    //        transform.position = new Vector2(originalposition.x, originalposition.y - ychangevalue);
    //        yield return 0;
    //    }
    //    yield break;
    //}
    

}