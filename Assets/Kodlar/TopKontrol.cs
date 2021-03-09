using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    Rigidbody fizik;
    public int hiz;
    int sayac = 0;
    public int toplanilacakObjeSayisi;

    public Text sayacText; // UI Text icin "using UnityEngine.UI; " kutuphanesi kullanir
    public Text oyunBittiText;

    void Start()
    {
        fizik = GetComponent<Rigidbody>(); // Rigidbody componentine erisim

    }

    void FixedUpdate()
    {
        float yatay = Input.GetAxisRaw("Horizontal"); // yatay eksende hareket
        float dikey = Input.GetAxisRaw("Vertical");   // dikey eksende hareket

        Vector3 vec = new Vector3(yatay,0,dikey); // hareket vektoru

        fizik.AddForce(vec*hiz); // kuvvet uygulama, hiz ile carpiyor
    }
    void OnTriggerEnter(Collider other) // obje temas ettiðinde devreye girecek metot
    // void OnTriggerStay               // obje temasta olduðu sürece
    // void OnTriggerExit               // obje temas edip temas kesilince

    {
        if (other.gameObject.tag=="engel") // engel tag'ine sahip olan objelere carptiginda
        {
            other.gameObject.SetActive(false); // objeleri pasiflestir, objeler gorunmez olur
            sayac++;

            sayacText.text = "Sayac = " + sayac; // UI texte yazilacak kisim Sayac = 3 gibi

            if (sayac == toplanilacakObjeSayisi) // sayac, toplanilacak obje sayisina (public) esitlendiginde
            {
                oyunBittiText.text = "Oyun Bitti"; // UI textte oyun bitti yaz
            }
        }
    }
}
