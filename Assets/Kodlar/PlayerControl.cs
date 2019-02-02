using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody fizik;
    AudioSource audio; 

    float horizontal=0;
    float vertical = 0;
    Vector3 vec;
    public float playerspeed;

    float shootingtime=0;
    public float lasertime;
    public GameObject laser;
    public Transform laseroutlet;

    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {                                     //(oyun başladığı anda zamanda anında başlayacağından dolayı 0>0 durumunu tutturmak çok zordur)
        if (Input.GetButton("Fire1") && Time.time>shootingtime ) //Mouse'a sol tıklandığında ve atış zamanı geçen zamandan küçük olduğu sürece if'e girsin
        {
            shootingtime = Time.time + lasertime; //Atış zamanınına o andaki zamanın ve atış yaptıktan sonraki belirlenen geçen zamanın toplamı atandı.Bu sayede atış belirli aralıklarla yapılabilecek.
            Instantiate(laser, laseroutlet.position, Quaternion.identity);
            audio.Play(); //Tıklandığında koyulan müziği çalar(lazer sesi)
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); 
        vertical = Input.GetAxisRaw("Vertical"); 
        vec = new Vector3(horizontal,0,vertical); //x,y,z
        
        fizik.velocity = vec*playerspeed; //PlayerSpeed değiştirildiğinde karakter ona bağımlı şekilde hızlanır
            
        fizik.position = new Vector3 
            (
            Mathf.Clamp(fizik.position.x,-6.05f,6.05f), //x eksenindeki sınır değerler
            0.0f,
            Mathf.Clamp(fizik.position.z,-3.93f,14f) //z eksenindeki sınır değerler
            ); //değerleri float değişkeni ile globalde public olarakta tanımlayabilirdik

        float x = 6f; //public olarakta yazılabilir
        fizik.rotation = Quaternion.Euler(0,0,fizik.velocity.x*-x); //- ile çarpmamızın nedeni karakterin sağa ve sola hareketinde eğimin o yöne doğru olmasını sağlamaktır
                                            
    }
}
