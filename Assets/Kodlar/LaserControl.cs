using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    Rigidbody fizik;
    public float hiz;
    void Start()
    {
        fizik=GetComponent<Rigidbody>();
        fizik.velocity = transform.forward*hiz; //update içinde olmaması lazerin bir kere çıkıp gitmesini sağlayacaktır.
    }

  
}
