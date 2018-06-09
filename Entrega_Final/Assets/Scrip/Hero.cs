using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using NPC.Enemy;
//using NPC.Ally;
public class Hero : MonoBehaviour
{
   
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.gray;// se asigna al heroe el color gris
        //gameObject.AddComponent(typeof(FPSMove));//Se le asigna la clase FPSMove al GameObject para el movimiento
        gameObject.tag = "Hero";       //Se tagea el ciudadano
        Camera.main.transform.localPosition = transform.position;//se le asigna a la camara la misposicion del heroe
        Camera.main.transform.SetParent(gameObject.transform);//se hace la camara hija del heroe
        Camera.main.gameObject.AddComponent<FPSAim>();//se le agrega la la clase FPSAim a la camara para la rotacion    
    }

    //procedimiento para cuando el heroe choque con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Zombie") 
        //{           
        //    //si choca con un objeto tageado como Zombie imprime mensaje + gusto que desea comer
        //    Debug.Log("Waaaarrrr Quiero comer "+ collision.gameObject.GetComponent<Zombie>().datos_zombie.gusto ); 
        //}
        //else if(collision.gameObject.tag == "Ciudadano")
        //{
        //    //si choca con un objeto tageado como Ciudadano imprime mensaje + nombre + edad
        //    Debug.Log("Hola soy  " + collision.gameObject.GetComponent<Ciudadano>().datos_ciudadano.nombre + " y tengo " + collision.gameObject.GetComponent<Ciudadano>().datos_ciudadano.edad + " años");
        //}
    }
}
