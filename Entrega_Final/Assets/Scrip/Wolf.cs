using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy{
 
    void Start () {
        Inicializar();
	}
	//Instancia un Wolf
    public override void Inicializar()
    {
        base.Inicializar();
        gameObject.GetComponent<Renderer>().material.color = Color.red;//Asigna color rojo al Wolf
        speed = speed * 1.5f; //aumenta la velocidad del Wolf
    }

}
