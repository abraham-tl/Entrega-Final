using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy {

	// Use this for initialization
	void Start () {
        Inicializar();

	}
	
	// Update is called once per frame
	void Update () {
        Movimiento();
    }
    public override void Inicializar()
    {
        base.Inicializar();
        gameObject.GetComponent<Renderer>().material.color = Color.red;
            //Color.HSVToRGB(235, 92, 00);
        speed = speed * 2f;

    }
}
