using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    Rigidbody fizik;
    [SerializeField] private float hiz = 100f;
    [SerializeField] private float jumpSpeed = 1.6f;
    int sayac = 0;
    public int toplanilacakObjeSayisi;

    public Text sayacText; // UI Text icin "using UnityEngine.UI; " kutuphanesi kullanir
    public Text oyunBittiText;

    private bool yereCarptimi=true;
    [SerializeField] private float yerCekimi = 0f; 

 
    private void Awake()
    {
        fizik = GetComponent<Rigidbody>(); // Rigidbody componentine erisim
    }

    void Start()
    {
        GetComponent<Rigidbody>().position = Vector3.zero;
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"); // x eksende hareket
        float z = Input.GetAxisRaw("Vertical");   // z eksende hareket
        float y = Input.GetAxisRaw("Jump");       // y eksende hareket, ziplama, space tusu 

        Vector3 vec = new Vector3(x, 0, z); // hareket vektoru x ve z
        Vector3 jmp = new Vector3(0, y, 0); // ziplama vektoru y
        
        if (gameObject.transform.position.y <= 0.5f) // eger top yerdeyse
        {
            fizik.AddForce(vec * hiz*Time.deltaTime); // hareket yonlerinde kuvvet uygulama, hiz ile carpiyor
        }

        else // top yerde degilse yuksekligi 0.5 uzerindeyse
        {
            fizik.AddForce((vec/3) * hiz*Time.deltaTime); // top hareketlerini yavaslat
            gameObject.transform.position -= new Vector3(0, yerCekimi, 0) * Time.deltaTime;
        }

             if (Input.GetButton("Jump") && yereCarptimi) // space basinca ve top yerdeyse
             {
                fizik.AddForce(jmp * jumpSpeed);  // karaktere y ekseninde guc uyguluyor, ziplama             
                yereCarptimi = false;
                
             }
    }
    void OnTriggerEnter(Collider other) // obje temas ettiðinde devreye girecek metot
    // void OnTriggerStay               // obje temasta olduðu sürece
    // void OnTriggerExit               // obje temas edip temas kesilince

    {
        if (other.gameObject.tag=="engel") // engel tag'ine sahip olan objelere carptiginda
        {
            other.gameObject.SetActive(false); // objeleri pasiflestir, objeler gorunmez olur
            sayac++;

            sayacText.text = "Score = " + sayac; // UI texte yazilacak kisim Score = 3 gibi

            if (sayac == toplanilacakObjeSayisi) // sayac, toplanilacak obje sayisina esitlendiginde
            {
                oyunBittiText.text = "Game Over"; // UI textte Game Over yaz
            }
        }

       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "yer") // yer tagine sahip olan objelere temas etti mi
        {
            yereCarptimi = true;
        }
    }
}
