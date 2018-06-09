using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {
    public float rotationSpeed = 150.0F;
    public GameObject proyectil;
    public Transform inicio;
    public float force = 10f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float rotacion = Input.GetAxis("Mouse ScrollWheel") * rotationSpeed;
        rotacion *= Time.deltaTime;
        gameObject.transform.Rotate(rotacion, 0, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            Dispara();
        }
    }

    void Dispara()
    {
        GameObject bala = Instantiate(proyectil, inicio.position, inicio.rotation);
        bala.GetComponent<Rigidbody>().AddForce(bala.transform.forward * force, ForceMode.Impulse);
        //ruido.PlayOneShot(sonidodisparo);
        Destroy(bala,2.5f);
       
    }

}
