using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Idle, Moving, Rotating, Reacting
};

public class NPCS : MonoBehaviour {
    bool active = false;
    int edad = 0;
    float speed = 0f;
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
        Asignar_Color();
        //Asignar_edad();
        speed = ((100f - edad) / 50f);
        StartCoroutine(DecideState());
    }


    public Color Asignar_Color()
    {
        Color color = Color.white;

        int a = Random.Range(0,4);
        switch (a)
        {
            case  1: color = Color.black;break;
            case 2:  color = Color.blue; break;
            case 3: color = Color.cyan; break;    
        }
        gameObject.GetComponent<Renderer>().material.color = color;
        return color;
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
}
