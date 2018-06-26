using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy {

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
    }
    
}
