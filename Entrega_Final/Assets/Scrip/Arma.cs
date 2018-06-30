using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Arma : MonoBehaviour {
    public Text num_amon;
    int amon;
    // Use this for initialization
    void Start () {
        Recargar(15);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") && amon > 0)
        {
            RaycastHit disparo;//vARIABLE  RaycastHit
            if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.TransformDirection(Vector3.forward),out disparo, Mathf.Infinity))
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

    public Vector3 Recargar(int a)
    {
        amon += a;
        num_amon.text = amon.ToString();
        return new Vector3(Random.Range(-20, 20), 1f, Random.Range(-20, 20));
    }
}