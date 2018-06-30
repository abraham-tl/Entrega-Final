using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum nombre
{
    Alejo,Abrahan,Jaime,Jose,Wlliam,Alan,Juan,Fernando,Andres,Pedro,Pablo,Jasinto,Sergio,Luis,Felipe,Diana,Patricia,Stella,Lina,Marina
}

public class Ally : NPCS {
    //public nombre name;
    Transform target;
    // Use this for initialization
    void Start () {
        Inicializar();
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
        Movimiento();
        target = Identificar_enemigo(typeof(Enemy));
        if (target)
        {
            state = States.Reacting;      
            Reaccion();
        }
    }

    public static implicit operator Enemy(Ally ally)
    {
        Enemy e = ally.gameObject.AddComponent<Enemy>();
       
        Destroy(ally);
        return e;
    }

    public override void Reaccion()
    {
        base.Reaccion();
        transform.position += Vector3.Normalize(target.transform.position + transform.position) * speed * Time.deltaTime;
      
    }

    public override Transform Identificar_enemigo(Type tipo_enemigo)
    {
        return base.Identificar_enemigo(tipo_enemigo);
    }
}
