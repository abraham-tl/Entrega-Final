﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : NPCS {

	// Use this for initialization
	void Start () {
        Inicializar();
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
        Movimiento();	
	}

}
