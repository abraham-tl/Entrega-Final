using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum nombre
{
    Alejo,Abrahan,Jaime,Jose,Wlliam,Alan,Juan,Fernando,Andres,Pedro,Pablo,Jasinto,Sergio,Luis,Felipe,Diana,Patricia,Stella,Lina,Marina
}

public class Ally : NPCS {
    public nombre name;
	// Use this for initialization
	void Start () {
        Inicializar();
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        Asignar_Nombre();
	}
	
	// Update is called once per frame
	void Update () {
        Movimiento();	
	}

    void Asignar_Nombre()
    {
        name = (nombre)Random.Range(0, 20);
    }
}
