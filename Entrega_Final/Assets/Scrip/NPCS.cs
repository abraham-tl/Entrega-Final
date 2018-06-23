using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Idle, Moving, Rotating, Reacting
};

public class NPCS : MonoBehaviour{
    bool active = false;
     int edad = 0;
    public float speed = 0f;
    States state;
    Vector3 rotating;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!active)
        {
            Inicializar();
            active = true;            
        }
        //Movimiento();
        StartCoroutine(DecideState());
    }

    public virtual void Inicializar()
    {
       
        Asignar_edad();
        speed = ((100f - edad) / 50f);
        StartCoroutine(DecideState());
    }



    public void Movimiento()
    {
        if(state == States.Moving)
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

    public void Asignar_edad()
    {
        edad = Random.Range(15, 101);
    }


    IEnumerator DecideState()
    {
        yield return new WaitForSeconds(2);
        state = (States)Random.Range(0, 3);
        StartCoroutine(DecideState());
        rotating.y = Random.Range(-1, 2);
    }

    public int Get_Edad()
    {
        return edad;
    }
}
