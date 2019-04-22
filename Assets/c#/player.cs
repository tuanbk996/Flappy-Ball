using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour {
   public Rigidbody2D rb;
    public float speed = 10f;
    public bool isdead = false;
    public AudioClip getcoin;
    public AudioClip dead;
    private AudioSource audios;
    private GameObject audioobject;
    public GameObject effectdie;
    public GameObject gameover;
    public GameObject bullet;
    public GameObject sliderheath;
   
    int highscore;
    public Text highscoretext;
    float time1 = 2f;
    float time = 1f;
    float timer2 = 3f;
    public Text timer2text;
    public GameObject texttimer;
    public GameObject textscore;
    private Vector3 screenbounds;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        audioobject = gameObject;
        audios = audioobject.GetComponent<AudioSource>();
       audios.clip= getcoin ;
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb.isKinematic = true;
        
    }
   
    

    // Update is called once per frame
    void Update () {
        timer2 -= Time.deltaTime;
        timer2text.text = string.Format("{0:0}", timer2);
        if (timer2 < 0)
        {
            rb.isKinematic = false;
            texttimer.SetActive(false);
            textscore.SetActive(true);
        }
       
       if (Input.GetKeyDown(KeyCode.Space)&&isdead==false)
           // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began&& timer2 < 0&& isdead == false)
           if(timer2<0)
            {
           // rb.velocity = Vector2.zero;
            moveplayer();
            audios.Play();
             }
        fire();

       if(sliderheath.GetComponent<heath>().currentheath < 0)
        {
            sliderheath.SetActive(false);
            PlayerPrefs.SetInt("highscore", 1000);
            GameObject.Find("scoremanager").GetComponent<scoremanager>().score = 1000;
            StartCoroutine(delay1());
        }
       if(transform.position.y> screenbounds.y)
        {
            transform.position = new Vector3(transform.position.x, screenbounds.y);
        }
       
            

    }
    IEnumerator delay1()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("win");
        yield break;
    }

    private void fire()
    {
        if (GameObject.Find("scoremanager").GetComponent<scoremanager>().score >= 10 && isdead == false)
        {
            time1 -= Time.deltaTime;
            
            if (time1 < 0)
            {
                sliderheath.SetActive(true);

                time -= Time.deltaTime;
                if (time < 0)
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);

                    time = 1f;
                }
            }
        }
    }


    void moveplayer()
    {
        //rb.AddForce(new Vector2(0, 200f));
        rb.velocity=    Vector2.up * speed;
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "die"&&isdead==false)
        { 
            isdead = true;
            audios.clip = dead;
            audios.Play();
            //Destroy(gameObject.GetComponent<player>());
            Destroy(Instantiate(effectdie, transform.position, Quaternion.identity), 0.8f);
            gameover.SetActive(true);
            if (PlayerPrefs.GetInt("highscore") < GameObject.Find("scoremanager").GetComponent<scoremanager>().score)
            {
                PlayerPrefs.SetInt("highscore", GameObject.Find("scoremanager").GetComponent<scoremanager>().score);
            }
            highscore = PlayerPrefs.GetInt("highscore");
            highscoretext.text = "Highscore: " + highscore.ToString();

        }
        if (other.gameObject.tag == "addscore"&&isdead==false)
        {
            
            GameObject.Find("scoremanager").GetComponent<scoremanager>().addscore();
            // audios.clip = getcoin;
            Destroy(other.gameObject);
           
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "die" && isdead == false)
        {
            Debug.Log("gameover");
            isdead = true;
            audios.clip = dead;
            audios.Play();
            //Destroy(gameObject.GetComponent<player>());
            Destroy(Instantiate(effectdie, transform.position, Quaternion.identity), 0.8f);
           
            gameover.SetActive(true);
            
            if (PlayerPrefs.GetInt("highscore") < GameObject.Find("scoremanager").GetComponent<scoremanager>().score)
            {
                PlayerPrefs.SetInt("highscore", GameObject.Find("scoremanager").GetComponent<scoremanager>().score);
            }
            highscore = PlayerPrefs.GetInt("highscore");
            highscoretext.text = "Highscore: " + highscore.ToString();

        }
    }
}
