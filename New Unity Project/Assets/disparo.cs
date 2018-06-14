using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour {
    public GameObject shuriken;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float shuriken = Time.deltaTime;
        transform.Translate(0f, shuriken, 0f);
        
        
        
        
	}
       void disparo()
    {
        Instantiate(shuriken, transform.position, transform.rotation);
    }
       
}
