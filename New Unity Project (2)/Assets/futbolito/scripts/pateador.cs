using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pateador : MonoBehaviour {

    // Use this for initialization
     void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.velocity = transform.forward * 40;

           
    }
}
