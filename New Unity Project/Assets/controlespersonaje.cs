using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlespersonaje : MonoBehaviour {
    public accion arriba;
    public accion abajo;
    public accion izquierda;
    public accion derecha;
    public GameObject samurai;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (arriba.ispressed)

        {
            arriba1();
        }
        if (abajo.ispressed)
        {
            abajo1();
        }
        if (izquierda.ispressed)
        {
            izquierda1();
        }
        if (derecha.ispressed)
        {
            derecha1();
        }
         


       }
    public void arriba1()
    {
        transform.Translate(0f, 0f, 1f);
        samurai.transform.rotation = Quaternion.Euler(0, 180f, 0);
        
        
    }
    public void abajo1()
    {
        transform.Translate(0f, 0f, -1f);
        samurai.transform.rotation = Quaternion.Euler(0, 0, 0);
        
    }
    public void izquierda1()
    {
        transform.Translate(-1f, 0f, 0f);
        samurai.transform.rotation = Quaternion.Euler(0, 90f, 0);
        
    }
    public void derecha1()
    {
        transform.Translate(1f, 0f, 0f);
        samurai.transform.rotation = Quaternion.Euler(0, -90f, 0);
        
    }
}
