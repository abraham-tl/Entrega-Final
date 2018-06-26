using System;
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
    GameObject[] objectos;
    public Color color;
    // Use this for initialization
    void Start ()
    {
       Inicializar();
       objectos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movimiento();
        Identificar_enemigo(typeof(Ally));
        //if (target)
        //{
        //    state = States.Reacting;

        //    Reaccion();
        //}
        //buscar();
    }

    public override void Inicializar()
    {
        base.Inicializar();
        Asignar_Color();
        gusto = (Gusto)UnityEngine.Random.Range(0,5);
      
    }

    public Color Asignar_Color()
    {
         color = Color.white;

        int a = UnityEngine.Random.Range(0, 4);
        switch (a)
        {
            case 0: color = Color.green; break;
            case 1: color = Color.black; break;
            case 2: color = Color.blue; break;
            case 3: color = Color.cyan; break;
        }
        gameObject.GetComponent<Renderer>().material.color = color;
        return color;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bala")
        {
            FindObjectOfType<Manager>().Eliminar_Enemy();
            Destroy(collision.gameObject);
            Destroy(gameObject);
          
        }

        if (collision.gameObject.tag == "Ciudadano")
        {
            Ally a = collision.gameObject.GetComponent<Ally>();    
            Enemy e = a;
            e.tag = "Zombie";            
            FindObjectOfType<Manager>().Crear_Enemy();
            FindObjectOfType<Manager>().Eliminar_Ally();
        }

    }

    public override Transform Identificar_enemigo(Type tipo_enemigo)
    {
        return base.Identificar_enemigo(tipo_enemigo);
    }
}
