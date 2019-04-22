using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerenemy : MonoBehaviour {
    public GameObject enemy;
    private GameObject ball;
    public GameObject effect;
   // public GameObject box;
    float time = 2f;
    float time1 = 1f;
    bool creat;
    public bool bossdie;
    // Use this for initialization
    void Start () {
        ball = GameObject.FindGameObjectWithTag("player");
       
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("scoremanager").GetComponent<scoremanager>().score >= 5 && GameObject.Find("player").GetComponent<player>().isdead == false)
        {
            time1 -= Time.deltaTime;

            if (time1 < 0)
            {

                time -= Time.deltaTime;
                if (time < 0)
                {
                    GameObject boom = Instantiate(enemy, transform.position, Quaternion.identity) as GameObject;
                    boom.GetComponent<moveenemy>().target = ball.transform.position;
                    time = 2f;
                }
                //if (creat == false)
                //{
                //    Instantiate(box, new Vector3(transform.position.x - 2f, 0f, 0f), Quaternion.identity);
                //    creat = true;
                //}
            }
        }
        if (GameObject.Find("slider").GetComponent<heath>().currentheath < 0)
        {
            Destroy(gameObject);
            Destroy(Instantiate(effect, transform.position, Quaternion.identity), 0.5f);
            bossdie = true;

        }
      
       

    }
   
}
