using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner11 : MonoBehaviour
{


    public GameObject[] enemy;
   // float nun = 0f;
    float time = 1f;
    float time1 = 2f;
    // int numberenemy=0;
    int numberindex;
    // Use this for initialization
    void Start()
    {
        Invoke("khoitao", 2);
    }
    void khoitao()
    {
        Instantiate(enemy[numberindex], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x = transform.position.x;
        pos.y = Random.Range(-3f, 3f);
        transform.position = pos;
        time1 -= Time.deltaTime;
        if (time1 < 0)
        {
            time -= Time.deltaTime;

            //if (GameObject.Find("scoremanager").GetComponent<scoremanager>().score > 5)
            //{
            //    numberindex = 1;
            //}
            if (GameObject.Find("player").GetComponent<player>().isdead == false)
            {
                if (time < 0 && GameObject.Find("scoremanager").GetComponent<scoremanager>().score <= 5)
                {
                    numberindex = Random.Range(0, enemy.Length);
                    GameObject vatcan = Instantiate(enemy[numberindex], transform.position, Quaternion.identity);
                    //nun = nun + 1;
                   // if (nun == 3)
                   // {
                    //    vatcan.AddComponent<floor>();
                  //}

                    time = 1f;

                    if (GameObject.Find("scoremanager").GetComponent<scoremanager>().score == 1)
                    {
                        vatcan.AddComponent<floor>();
                    }



                }
            }
        }
    }
}
