using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using NPC.Enemy;
//using NPC.Ally;

public class Manager : MonoBehaviour
{

    //public Text num_ally;//Variable de texto para la cantidad de ciudadanos
    public Text num_enemy;//Variable de texto para la cantidad de Zombies
    int ally = 0; //Entero para el contador de Ciudadanos
    int enemy = 0;//Entero para el contador de Zombies
    //const int max_NPC = 25; //Constante para el maximo de instancias
    //Struc_Manager datos_manager;// variable de tipo estructura manager
    //Variable para asignar numeros de instancia

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
        Contar_NPCs();//Se llama el procedimiento para contal los NPC   
        print(enemy);
    }

        //Funcion que retorna un Vector3 para la posicion

  
        
        Vector3 Asignar_Posicion()
        {
            Vector3 pos = new Vector3();
            pos.x = Random.Range(-10, 10);
            pos.y = -0.5f;
            pos.z = Random.Range(-10, 10);
            return pos;
        }

    void Contar_NPCs()
    {
        foreach (GameObject o in boxes)//recorre el vector para contar los NPC
        {
            if (o.tag == "Zombie")
            {
                enemy += 1;
            }
            if (o.tag == "Ciudadano")
            {
                ally += 1;
            }
        }
        num_ally.text = ally.ToString();//convierte el acomolador a dtrin y lo asigna al texto
        num_enemy.text = enemy.ToString();//convierte el acomolador a dtrin y lo asigna al texto
    }
}
