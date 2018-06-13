using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    public otro Abajobot;
    public otro Arribabot;
    public otro Izquierdabot;
    public otro Derechabot;

  
	
	public void Arriba()
    {
        transform.Translate(0f, 0.1f, 0f);
    }
    public void Abajo()
    {
        transform.Translate(0f, -0.1f, 0f);
    }
    public void Izquierda()
    {
        transform.Translate(0.1f, 0.1f, 0f);
    }
    public void Derecha()
    {
        transform.Translate(0f, 0.1f, 0.1f);
    }



}

