using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour 
{
    public Rigidbody2D megaman;
    public bool posi = false;
    public SpriteRenderer Rotamela;
    public float impulse = 10f;
    public float velocidadcorrer = 5f;
    public Animator CaminaMegaman;

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
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
        else if (Hori > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            
        }

        megaman.velocity = new Vector2(velocidadcorrer * Hori, megaman.velocity.y);

        if (Hori < 0.05 && Hori > -0.05)
        {
            CaminaMegaman.SetBool("Camina", false);
        }
        else
        {
            CaminaMegaman.SetBool("Camina", true);
        }

        if (Input.GetKey("z"))
        {
            CaminaMegaman.SetBool("Agacha", true);
        }
        else
        {
            CaminaMegaman.SetBool("Agacha", false);
        }
    }

    void OnCollisionEnter2D()
    {
        posi = true;
    }
}
