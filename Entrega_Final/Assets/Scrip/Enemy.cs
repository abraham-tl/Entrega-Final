using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gusto
{
Cerebro, Pierna, Brazo,Ojos,Cuello
};


public class Enemy : NPCS
{
    Gusto gusto;
	// Use this for initialization
	void Start ()
    {
       Inicializar();
      
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movimiento();
	}


    public override void Inicializar()
    {
        base.Inicializar();
        Asignar_Color();
        gusto = (Gusto)Random.Range(0,5);
        print(" GUSTO = " + gusto);
    }
}
