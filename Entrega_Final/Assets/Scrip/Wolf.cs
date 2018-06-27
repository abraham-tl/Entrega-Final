﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy{
    Transform target;
    // Use this for initialization
    void Start () {
        Inicializar();

	}
	
	// Update is called once per frame
	void Update () {
        Movimiento();
        target = Identificar_enemigo(typeof(Ally));
        if (target)
        {
            state = States.Reacting;

            Reaccion();
        }
    }
    public override void Inicializar()
    {
        base.Inicializar();
        gameObject.GetComponent<Renderer>().material.color = Color.red;
            //Color.HSVToRGB(235, 92, 00);
        speed = speed * 1.5f;

    }
    public override void Reaccion()
    {
        base.Reaccion();
        transform.LookAt(target.transform.position);
        transform.position += Vector3.Normalize(target.transform.position - transform.position) * speed * Time.deltaTime;
    }
}
