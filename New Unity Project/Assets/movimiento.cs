using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour 
{
    public Rigidbody2D megaman;
    public bool posi = false;
    public SpriteRenderer Rotamela;
	void Start () 
	{
        
    }
	
	void Update () 
	{
        
        if (posi == true) { 
		    if (Input.GetButton("Jump"))
            {
                megaman.AddForce(transform.up * 200);
                posi = false;
            }
        }

        float Hori = Input.GetAxis("Horizontal");
        megaman.AddForce(transform.right * Hori * 7);

        if (Hori < 0)
        {
            Rotamela.flipX = true;
        }
        if (Hori > 0)
        {
            Rotamela.flipX = false;
        }
	}

    void OnCollisionEnter2D()
    {
        posi = true;
    }
}
