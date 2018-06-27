using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using NPC.Enemy;
//using NPC.Ally;
public class Hero : Ally
{
   public  float life = 100f; 
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.gray;// se asigna al heroe el color gris
         this.gameObject.tag = "Player";       //Se tagea el ciudadano     
    }

    //procedimiento para cuando el heroe choque con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            FindObjectOfType<Manager>().Bajar_Vida();
            //si choca con un objeto tageado como Zombie imprime mensaje + gusto que desea comer
            //Debug.Log("Waaaarrrr Quiero comer " + collision.gameObject.GetComponent<Zombie>().datos_zombie.gusto);
        }
        else if (collision.gameObject.tag == "Ciudadano")
        {
            //si choca con un objeto tageado como Ciudadano imprime mensaje + nombre + edad
            int a = collision.gameObject.GetComponent<Ally>().Get_Edad();
            Debug.Log("Hola soy  " + collision.gameObject.GetComponent<Ally>().name + " y tengo " + a);
           //  + " años"
        }

        if (collision.gameObject.tag == "Ammo")
        {
            print("HOLA");
            FindObjectOfType<Arma>().Crear_Ammo();
            Destroy(collision.gameObject);
        }
    }
}
