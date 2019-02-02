using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaKaybol : MonoBehaviour
{
    public GameObject patlama;
    public GameObject playerpatlama;

    GameObject ObjeKontrol;
    ObjeKontrol kontrol;


    void Start()
    {
        ObjeKontrol = GameObject.FindGameObjectWithTag("objekontrol");
        kontrol = ObjeKontrol.GetComponent<ObjeKontrol>();
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "yokedici") 
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(patlama, transform.position, transform.rotation);
            kontrol.scorearttir(10);
        }       

        if(other.tag=="Player")
        {
            Instantiate(playerpatlama, other.transform.position, other.transform.rotation);
            kontrol.scorearttir(-10); //karakter objeyle çarpıştığında score artmaması için 10 azalttık
            kontrol.gameover();
        }
    }
}
