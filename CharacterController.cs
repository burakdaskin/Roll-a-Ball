using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))] //Scripti ekledigimiz objeye otomatik olarak Rigidbody komponentini de ekliyor.
public class CharacterController : MonoBehaviour
{
    /* Sorunsuz bir sekilde çalismasi için sahnenizde "Door" isimli bir obje, "Finish" isimli bir obje, "Key" Tag'li 3 obje bulunmasi gerekiyor.
     * Kodu, karakter için kullanilacak objenin içine atiyorsunuz.
     * Asset store'dan Joystick paketini indirip import etmeniz gerekiyor.
     * Sonrasinda FixedJoystick isimli objeyi sahneye sürükleyip birakiyorsunuz.
     * Eger sahne eklemediyseniz bölüm geçmek için finish objesine temas ettiginizde hata verecektir !
     * Sahne eklemek için Unity > File > Build settings > Add Open Scenes böylece açik olan sahneyi siraya ekliyorsunuz.
     * Yeni sahne eklemek için o sahneyi açip islemi tekrar ediyorsunuz.
     */

    new Rigidbody rigidbody; //Karekteri hareket ettirmemizi saglayan oyun fizigi
    public float speed = 5; //Karekterin hizi
    public float doorSpeed = 3; //Kapinin açilma hizi
    public FixedJoystick fixedJoystick; //Karekter hareketi için kullanilan joystick

    int collectedKeys = 0; //Toplanacak anahtar degerini tuttugumuz degisken
    void Start() //Oyun ilk basladigi anda çalisan kodlar
    {
        rigidbody = GetComponent<Rigidbody>();//Fizige referans veriyoruz
    }
    void Update() //Oyun baslangicindan sonuna kadar sürekli çalisacak olan kodlar
    {
        rigidbody.velocity = new Vector3(fixedJoystick.Horizontal * speed, 0, fixedJoystick.Vertical * speed); //Joystick sayesinde karekterdeki fizigi kullanarak hareket veriyoruz
        if(collectedKeys == 3 && GameObject.Find("Door")) //3 Anahtar toplarsak ve sahnemizde "Door" isimli obje varsa çalisacak
        {
            OpenDoor(); //If'in içi true ise çalisacak method           
        }
    }
    void OpenDoor()
    {
        GameObject.Find("Door").transform.position += Vector3.down * Time.deltaTime * doorSpeed; //Method çalisinca sahnedeki "Door" isimli objeyi asagiya dogru hareket ettiriyoruz.
        Destroy(GameObject.Find("Door"), 3f); //Method çalistiktan 3 saniye sonra objeyi sahneden siliyoruz.
    }
    private void OnCollisionEnter(Collision collision) //Karekterin herhangi bir nesneye temas edip etmedigini algiliyoruz.
    {
        if (collision.gameObject.CompareTag("Key")) //Eger temas ettigi objenin Tag'i "Key" ise if'in altindaki kodlari çalistiriyoruz.
        {
            Destroy(collision.gameObject); //Key Tagli objeyi sahneden siliyoruz
            collectedKeys++; //Her anahtar toplamamizda anahtar degerini tutan degiskeni 1 arttiriyoruz.
        }
        else if(collision.gameObject.name == "Finish") //Eger temas ettigi objenin ismi "Finish" ise else if'in altindaki kodu çalistiriyoruz.
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Finish objesi ile temas edince bir sonraki bölüme geçiyoruz.
        }
    }
}
