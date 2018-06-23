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

    public Image imagen;
    public int numboxes; //Variable para asignar numeros de instancia


    public GameObject[] boxes; //Vector para guardar los personajes

    public static int enemyNumber;
    public static int allyNumber;

    public int vida;

    public Canvas canvas_go;
    public Canvas canvas_winer;

    public float max_imagen, min_imagen;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        numboxes = Random.Range(10, 20);// aleatorio para el numero de instancias
        vida = 400;
        max_imagen = vida;

        ////Ciclo para crear las instancias
        for (int k = 0; k < numboxes; k++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); //se crea una primitiva en la variable Game Object
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


            boxes[k] = cube;//Se Guarda el Gameobject de la calse en el vector
        }
        //Contar_NPCs();//Se llama el procedimiento para contal los NPC  



        Enemy[] enemies = FindObjectsOfType<Enemy>();
        enemyNumber = enemies.Length;
        num_enemy.text = enemyNumber.ToString();

        Ally[] allies = FindObjectsOfType<Ally>();
        allyNumber = allies.Length;
        num_ally.text = allyNumber.ToString();

        // Canvas[] canvas_ = FindObjectOfType<Canvas>();
        //print(enemies[0].gameObject.transform.position);
    }

    private void Update()
    {
        
        if (enemyNumber <= 0 )
        {
            canvas_winer.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (allyNumber <= 0 || vida <= 0)
        {
            canvas_go.gameObject.SetActive(true);
            Camera.main.transform.SetParent(null);
            FindObjectOfType<Hero>().gameObject.SetActive(false);
        }
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

    public void Eliminar_Enemy()
    {
        enemyNumber--;
        //print(num_enemy);
        num_enemy.text = enemyNumber.ToString();
    }
    public void Crear_Enemy()
    {
        enemyNumber++;
        //print(num_enemy);
        num_enemy.text = enemyNumber.ToString();
    }

    public void Bajar_Vida()
    {    
        vida = vida - 80;
        imagen.fillAmount = (vida) / max_imagen;
    }

    public void Eliminar_Ally()
    {
       allyNumber --;
        num_ally.text = allyNumber.ToString();
    }



}
