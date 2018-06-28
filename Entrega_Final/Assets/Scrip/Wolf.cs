using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy{
    Transform target;
    // Use this for initialization
    void Start () {
        Inicializar();

	}
	
	// en el Update llama la funsion buscar enemigo si esta serca retorna transform,
	void Update () {
        Movimiento();
        target = Identificar_enemigo(typeof(Ally));
        if (target)//si lo retorna reaciona segun el objeto
        {
            state = States.Reacting;

            Reaccion();
        }
    }
    public override void Inicializar()
    {
        base.Inicializar();
        gameObject.GetComponent<Renderer>().material.color = Color.red;
            //Color.HSVToRGB(235, 92, 00);
        speed = speed * 1.5f;

    }
    public override void Reaccion()
    {
        base.Reaccion();
        transform.LookAt(target.transform.position);
        transform.position += Vector3.Normalize(target.transform.position - transform.position) * speed * Time.deltaTime;//desplaza Game object
    }
}
