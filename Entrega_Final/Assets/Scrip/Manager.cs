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

    public static int enemyNumber; //Variable intera para guardar la cantidad de enemigos
    public static int allyNumber;//Variable intera para guardar la cantidad de Ciudadanos

    public int vida; //Variable intera para guardar la cantidad de sangre del Player

    public Canvas canvas_go; //canvas para el game over
    public Canvas canvas_winer; //canvas para ganar

    public float max_imagen, min_imagen; //variables flotantes para el canvas sansangre

    void Start()
    {
        Reiniciar_juego();
    }

    private void Update()
    {   
        //si el numero de enemigos es inferior o igual a cero activa el canvas para ganar (WINNER)
        if (enemyNumber <= 0 )
        {
            canvas_winer.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
        //si el numero de Ciudadanos es inferior o igual a cero activa el canvas para game over
        if (allyNumber <= 0 || vida <= 0)
        {
            canvas_go.gameObject.SetActive(true);
            Camera.main.transform.SetParent(null);
           // FindObjectOfType<Hero>().gameObject.SetActive(false);
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

    //metodo  para descontar la cantidad de enemy y actualiza el canvas
    public void Eliminar_Enemy()
    {
        enemyNumber--;
        num_enemy.text = enemyNumber.ToString();
    }

    //metodo  para aumentar la cantidad de enemy y actualiza el canvas
    public void Crear_Enemy()
    {
        enemyNumber++;
        num_enemy.text = enemyNumber.ToString();
    }

    //metodo  para disminuir la cantidad de vida y actualiza el canvas
    public void Bajar_Vida()
    {    
        vida = vida - 80;
        imagen.fillAmount = (vida) / max_imagen;
    }
    //metodo  para descontar la cantidad de Ally y actualiza el canvas
    public void Eliminar_Ally()
    {
       allyNumber --;
       num_ally.text = allyNumber.ToString();
    }


    public void Reiniciar_juego()
    {
        canvas_go.gameObject.SetActive(false);
        canvas_winer.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;//detiene el cursor de la pantalla
        numboxes = Random.Range(10, 20);// aleatorio para el numero de instancias
        vida = 400; //inicia la sangre en 400
        max_imagen = vida; //el maximo de la vida para el canvas de la vida

        ////Ciclo para crear las instancias
        for (int k = 0; k < numboxes; k++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); //se crea una primitiva en la variable Game Object
            cube.transform.position = Asignar_Posicion();//Se asigna una posisicion en el plano
            cube.AddComponent<Rigidbody>();// se asigna un rigidbodi al objeto
            int tipo = Random.Range(0, 3); //Aleatorio entre 1 y 2 agregar el componente zombie o ciudadano             
            if (tipo == 0)
            {
                // si es dos se agrega el componente Zombie
                cube.AddComponent(typeof(Zombie));
                cube.tag = "Zombie"; //Se le agraga un tag al objeto  ("Zombie")
            }
            else if (tipo == 1)
            {
                // si es dos se agrega el componente Zombie
                cube.AddComponent(typeof(Wolf));
                cube.tag = "Zombie"; //Se le agraga un tag al objeto  ("Zombie")
            }
            else
            {
                //si no es dos agrega el componente Ciudadano
                cube.AddComponent(typeof(Ally));
                cube.tag = "Ciudadano";//Se le agraga un tag al objeto  (Ciudadano")
            }

        }
        //Este segmento cuenta los NPC, los asigna a un entero y los lleva a los respectivos canvas
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        enemyNumber = enemies.Length;
        num_enemy.text = enemyNumber.ToString();

        Ally[] allies = FindObjectsOfType<Ally>();
        allyNumber = allies.Length - 1;
        num_ally.text = allyNumber.ToString();
    }
}
