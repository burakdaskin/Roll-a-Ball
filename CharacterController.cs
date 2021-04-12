using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    Rigidbody rigidbody;
    public FixedJoystick fixedJoystick;
    public float speed;
    public float doorSpeed;

    int key = 0;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); // Bulundugu objenin rigidbody companentina erisir.
    }
    void Update()
    {
        rigidbody.velocity = new Vector3(fixedJoystick.Horizontal * speed, 0, fixedJoystick.Vertical * speed); // Karakterin rigidbodye erisip hiz vektoru tanýmlar.
        if(key == 3 && GameObject.Find("Door")) // keyimiz 3 esit ve sahnemizde Door adlý bir objemiz varsa kosula girer.
        {
            GameObject.Find("Door").transform.position += Vector3.down * doorSpeed * Time.deltaTime; // Door adli objemizi sahnedeki pozisyonun vector3'unun Y sini sürekli azaltir.
            Destroy(GameObject.Find("Door"), 3f); // Door adlý objeyi 3 saniye sonra sahnemizde siler.
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Key2"))
        {
            key++;
            Destroy(collision.gameObject); // Çarpýstýgý objeyi sahnemizden siler.
        }
        else if(collision.gameObject.name == "Bitis")
        {
            
            //SceneManager kullanmak için UnityEngine.SceneManagement kutuphanesi kullanmak gerekir.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Bir sonraki seviyeye gecmek icin suanki sahenin indexi (deðer) alip 1 deger ekleyip sonraki levele geçmesini saglar.
        }
    }
}
