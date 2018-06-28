using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Arma : MonoBehaviour {
    public Text num_amon;

    public float rotationSpeed = 150.0F;
    public GameObject proyectil;
    public GameObject box_ammo;
    public Transform inicio;
    public float force = 10f;

    int amon;
    // Use this for initialization
    void Start () {
        Crear_Ammo();
    }

    // Update is called once per frame
    void Update() {
        float rotacion = Input.GetAxis("Mouse ScrollWheel") * rotationSpeed;
        rotacion *= Time.deltaTime;
        gameObject.transform.Rotate(rotacion, 0, 0);

        if (Input.GetButtonDown("Fire1") && amon > 0)
        {
            RaycastHit disparo;
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.TransformDirection(Vector3.forward),out disparo, Mathf.Infinity))
            {
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * disparo.distance, Color.yellow);
                if (disparo.collider.GetComponent<Enemy>() != null)
                {
                    disparo.collider.gameObject.GetComponent<Enemy>().Destruir_enemy();
                    Destroy(disparo.collider.gameObject);                 
                }
            }
            amon--;
            num_amon.text = amon.ToString();
        }
    }

    public void Recargar(int a)
    {
        amon += a;
        num_amon.text = amon.ToString();
    }

    public void Crear_Ammo()
    {
        Recargar(15);
        GameObject ammo = Instantiate(box_ammo);
        ammo.transform.position = new Vector3(Random.Range(-20, 20), 1f, Random.Range(-20, 20));
        ammo.gameObject.tag = "Ammo";
    }
}
