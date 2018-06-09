using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSAim : MonoBehaviour {
   public  FPSMove  _rotations;
    float mousex;
    float mousey;
    public bool invertedmouse;
  

    void Start () {
        //SE ASIGNA ROTACION A UN OBJETO
        transform.eulerAngles = new Vector3(30,0,0);
        //SE RELACIONA LA CLASE FPSMove CON FPSaim
        _rotations = FindObjectOfType<FPSMove>();
	}

	void Update () {
        //mousex = mousex + Input.GetAxis("Mouse X");
        //ESTE IF CONTROL O INVIERTE LA ROTACION VERTICAL CON EL MUSE
        if (invertedmouse)
        {
            mousey = mousey + Input.GetAxis("Mouse Y");
        }
        else
        {
            mousey = mousey - Input.GetAxis("Mouse Y");
        }
       
       //ROTA EL OBJETO DEPENDIENDO DEL MOVIMIENTO DEL MOUSE VERTICAL 
        mousex = mousex + Input.GetAxis("Mouse X");
      
        transform.eulerAngles = new Vector3(mousey, mousex, 0);
        //ENVIA LA ROTACION DEL MOUSE A LA CALSE FPSmove AL SUBPROCESO  (Rotations_)
        _rotations.Rotations_(mousex);
    }

   
}
