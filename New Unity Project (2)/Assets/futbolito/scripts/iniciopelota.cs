using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class iniciopelota : MonoBehaviour {
    public Rigidbody pelotafuerza;
	// Use this for initialization
	void Start () {
        GoPelota();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoPelota() {
        pelotafuerza.velocity = transform.right * 30f;
    }

    
}
