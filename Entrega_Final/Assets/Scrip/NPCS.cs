using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Idle, Moving, Rotating, Reacting
};

public class NPCS : MonoBehaviour
{
    bool active = false;//controla la inicializacion de la clase
    public int edad = 0;
    public float speed = 0f;
    public States state;
    Vector3 rotating;
    protected Transform myTransform;
   
   //asigna el transform del NPC a una Variable
    void Awake()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            Inicializar();//LLama el metodo inicializar
            active = true;
        }
        StartCoroutine(DecideState());      
    }

    public virtual void Inicializar()
    {
        Asignar_edad();//asigna al NPC una edad aleatoria
        speed = ((100f - edad) / 50f); //asigna al NPC una velocidad con base en la edad
        StartCoroutine(DecideState()); //inicia una corrutina para los estados
    }

// Metodo que da movimiento al NPC segun el estado
    public void Movimiento()
    {
        if (state == States.Moving)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (state == States.Rotating)
        {
            transform.eulerAngles += rotating;
        }
        if (state == States.Reacting)
        {
          
        }
    }

//medoto mara renombrar desde cada uno de los NPC, reacciona segun el tipo de enemigo
     public virtual void Reaccion()
    {

    }

//Metodo que Aigna una edad aleatoria entre 15 y 100 al NPC
    public void Asignar_edad()
    {
        edad = Random.Range(15, 101);
    }

//Corrutina para cambiar el estado del NPC cada 3 segundos
    IEnumerator DecideState()
    {
        yield return new WaitForSeconds(3);
        state = (States)Random.Range(0, 3);
        StartCoroutine(DecideState());
        rotating.y = Random.Range(-1, 2);
    }
//Metodo para retornar la edad del NPC
    public int Get_Edad()
    {
        return edad;
    }

//Metodo al que se le envia el tipo de enemigo y retorna el transform enemigo si esta cerca (7 )
    public virtual Transform Identificar_enemigo(System.Type tipo_enemigo)
    {
        MonoBehaviour[] enemigos = (MonoBehaviour[])FindObjectsOfType(tipo_enemigo);
        Transform enemigo = null;
        float distancia_minima = float.MaxValue;
        for (int i = 0; i < enemigos.Length; i++)
        {
            Transform enemyTransform = enemigos[i].GetComponent<Transform>();
            Vector3 distanceVector = enemyTransform.position - myTransform.position;
            float distancia = distanceVector.magnitude;
            if(distancia <=7 && distancia < distancia_minima)
            {
                enemigo = enemyTransform;
                distancia_minima = distancia;
            }
        }
            return enemigo;
    }   
}
