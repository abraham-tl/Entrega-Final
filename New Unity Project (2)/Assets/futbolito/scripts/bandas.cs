using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bandas : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float vert = Input.GetAxis("Vertical");

        if (gameObject.tag == "Player")
        {
            transform.position = new Vector3(vert*2, 1.7f, -14.07999f);
            if (Input.GetButton("Jump"))
            {
                transform.Rotate(0, 20, 0);
            }
        }
        else {
            transform.position = new Vector3(vert*2, 1.7f, 15);
            if (Input.GetButton("Jump"))
            {
                transform.Rotate(0, -20, 0);
            }

        }

        
		
	}
}
