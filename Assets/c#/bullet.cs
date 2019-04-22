using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public GameObject effect;
    public AudioClip dame;
    private GameObject audioobj;
    private AudioSource dameaudio;
	// Use this for initialization
	void Start () {
        audioobj = gameObject;
        dameaudio = audioobj.GetComponent<AudioSource>();
        dameaudio.clip = dame;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * 3f * Time.deltaTime);
        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            GameObject.Find("slider").GetComponent<heath>().adddame();
            dameaudio.Play();
            Destroy(Instantiate(effect, other.gameObject.transform.position, Quaternion.identity), 0.5f);
            
        }
    }
}
