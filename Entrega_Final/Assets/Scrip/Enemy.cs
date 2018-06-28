using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum para el gusto de los enemy
public enum Gusto
{
Cerebro, Pierna, Brazo,Ojos,Cuello
};


public class Enemy : NPCS
{
    Gusto gusto;
    public Color color;
    // Use this for initialization
    void Start ()
    {
       Inicializar();//lllama el metodo inicializar
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movimiento();//le da movimiento al ENEMY
        Identificar_enemigo(typeof(Ally));//envia el tipo de enemigo y busca si hay uno cercano
    }

    public override void Inicializar()
    {
        base.Inicializar();
        Asignar_Color();//Asigna un color a la primitiva del ENEMY
        gusto = (Gusto)UnityEngine.Random.Range(0,5);//Asigna un gusto aleatorio Al NPC
      
    }

//metodo para asignar un color aleatorio al ENEMY
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
    //Si el enemy choca con un ciudadado  lo convierte en zombie
        if (collision.gameObject.tag == "Ciudadano")
        {
            Ally a = collision.gameObject.GetComponent<Ally>();    
            Enemy e = a;
            e.tag = "Zombie";            
            FindObjectOfType<Manager>().Crear_Enemy();
            FindObjectOfType<Manager>().Eliminar_Ally();
        }

    }
//metodo para destruir el enemy
    public void Destruir_enemy()
    {
        FindObjectOfType<Manager>().Eliminar_Enemy();
    }
    metodo para buscar el enemigo del Enemy
    public override Transform Identificar_enemigo(Type tipo_enemigo)
    {
        return base.Identificar_enemigo(tipo_enemigo);
    }
}
