using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstereoidHareketi : MonoBehaviour
{
    Rigidbody fizik;
    public float speed;

    GameObject ObjeKontrol;
    ObjeKontrol kontrol;
    void Start()
    {
        
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward * speed;
        

    }
}
