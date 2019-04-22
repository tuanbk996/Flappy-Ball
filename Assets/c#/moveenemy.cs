using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveenemy : MonoBehaviour {
    public Vector3 target;
    public float speed=5f;
    public GameObject effect;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once pever frame
	void Update () {
        
        transform.Translate((transform.position - target) * speed * -1 * Time.deltaTime);
       
            StartCoroutine(delay());  
          
      
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(Instantiate(effect, transform.position, Quaternion.identity), 0.5f);
        Destroy(gameObject);


 
        yield break;
    }

}
