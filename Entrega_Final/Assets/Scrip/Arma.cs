using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour {
    public Text num_amon;

    public float rotationSpeed = 150.0F;
    public GameObject proyectil;
    public Transform inicio;
    public float force = 10f;

    int amon;
    // Use this for initialization
    void Start () {
        Recargar_arm();
	}

    // Update is called once per frame
    void Update() {
        float rotacion = Input.GetAxis("Mouse ScrollWheel") * rotationSpeed;
        rotacion *= Time.deltaTime;
        gameObject.transform.Rotate(rotacion, 0, 0);

        if (Input.GetButtonDown("Fire1") && amon > 0)
        {
            Dispara();
           

        }
    }

    void Dispara()
    {
        GameObject bala = Instantiate(proyectil, inicio.position, inicio.rotation);
        bala.GetComponent<Rigidbody>().AddForce(bala.transform.forward * force, ForceMode.Impulse);
        amon--;
        num_amon.text = amon.ToString();
        //ruido.PlayOneShot(sonidodisparo);
        Destroy(bala,2.5f);
       
    }

    public void Recargar_arm()
    {
        amon = amon + 15;
        num_amon.text = amon.ToString();
    }

}
