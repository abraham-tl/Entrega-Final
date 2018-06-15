using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using NPC.Enemy;
//using NPC.Ally;

public class Manager : MonoBehaviour
{
    public Text num_ally;//Variable de texto para la cantidad de ciudadanos
    public Text num_enemy;//Variable de texto para la cantidad de Zombies
    public int numboxes; //Variable para asignar numeros de instancia
    public GameObject[] boxes; //Vector para guardar los personajes
   
    void Start ()
    {      
        numboxes = Random.Range(10,20);// aleatorio para el numero de instancias

        ////Ciclo para crear las instancias
        for (int k = 0; k < numboxes; k++)
        {          
            GameObject cube =  GameObject.CreatePrimitive(PrimitiveType.Cube); //se crea una primitiva en la variable Game Object
            cube.transform.position = Asignar_Posicion();//Se asigna una posisicion en el plano
            cube.AddComponent<Rigidbody>();// se asigna un rigidbodi al objeto
            //    // Si es el primer cilo agrega el componente hero
         
                int tipo = Random.Range(1, 3); //Aleatorio entre 1 y 2 agregar el componente zombie o ciudadano             
                if (tipo == 2)
                {
                    // si es dos se agrega el componente Zombie
                    cube.AddComponent(typeof(Enemy));
                    cube.tag = "Zombie"; //Se le agraga un tag al objeto  ("Zombie")
                }
                else
                {
                    //si no es dos agrega el componente Ciudadano
                    cube.AddComponent(typeof(Ally));
                    cube.tag = "Ciudadano";//Se le agraga un tag al objeto  (Ciudadano")
                }
            

         // boxes[k] = cube;//Se Guarda el Gameobject de la calse en el vector
        }
        //Contar_NPCs();//Se llama el procedimiento para contal los NPC  
        


        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Statics.enemy = enemies.Length;
        num_enemy.text = Statics.enemy.ToString();

        Ally[] allies = FindObjectsOfType<Ally>();
        Statics.ally = allies.Length;
        num_ally.text = Statics.ally.ToString();

        print(Statics.enemy);
        //print(enemies[0].gameObject.transform.position);
    }

        //Funcion que retorna un Vector3 para la posicion

  
        
        Vector3 Asignar_Posicion()
        {
            Vector3 pos = new Vector3();
            pos.x = Random.Range(-20, 20);
            pos.y = -0.5f;
            pos.z = Random.Range(-20, 20);
            return pos;
        }

    //void Contar_NPCs()
    //{
    //    foreach (GameObject o in boxes)//recorre el vector para contar los NPC
    //    {
    //        if (o.tag == "Zombie")
    //        {
    //            Statics.enemy += 1;
    //        }
    //        if (o.tag == "Ciudadano")
    //        {
    //            Statics.ally += 1;
    //        }
    //    }
        
        //num_ally.text = ally.ToString();//convierte el acomolador a dtrin y lo asigna al texto
      //convierte el acomolador a dtrin y lo asigna al texto
    //}
    public void Eliminar_Enemy()
    {
        int a = Statics.enemy;
            a = a - 1;
        Statics.enemy = a;
        print(Statics.enemy);
        num_enemy.text = a.ToString();
    }
    
    public void Eliminar_Ally()
    {
        Statics.ally -= Statics.ally;
        num_ally.text = Statics.ally.ToString();
    }
}
