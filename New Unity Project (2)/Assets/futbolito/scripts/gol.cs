using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gol : MonoBehaviour {
    public iniciopelota Reset;
    public GameObject other;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = new Vector3(0.93f, 0.9099884f, 0.7400146f);
        Reset.GoPelota();
    }
}
