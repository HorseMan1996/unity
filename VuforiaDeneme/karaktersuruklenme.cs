using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class karaktersuruklenme : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion rot;
    int bulundu = 0;

    public GameObject menu, kalibreetme;
    public GameObject karakter;

    //1.bölüm cisimleri
    public GameObject bolum1text;
    public GameObject duvarlar;
    //-----------------

    public GameObject kapisesi;

    public GameObject joys;

    public AudioSource m_MyAudioSource;
    public GameObject butonsesleri;
    public GameObject kamera;
    public GameObject carpmases, yuvarlanmasesi;
    public GameObject kapi;
    public GameObject imagetarget;
    public GameObject ayarlarpanel;
    public Rigidbody fizik;
    float nesnehizi = 2;
    float karakterz;
    float karaktergyrosifirlamax = 0;
    float karaktergyrosifirlamay = 0;

    float karakterx;
    float karaktery;
    
    //ayarlar kısmı objeleri
    public Slider menusesi;
    public Slider karaktersesi;
    public Slider hareketsecenegi;
    public GameObject gyroyazisi, joysticyazisi;
    //-----------------------

    public Text gyro1;
    public Text gyro2;
    public Text gyro3;
    public Text gyro4;

    public float speed;

    public Text gyroyazisisi;
    public Text jostickyazisisi;

    int cisimtemas = -1;
    public int bolum;
    string ayarlars;

    public Joystick joystik;

    public GameObject birincibolumgecisyazisi;

    //2.bolum cisimleri
    public GameObject mavikapi;
    public GameObject bolum2;
    //-----------------


    //3.bolum cisimleri
    public GameObject kirmizikapi;
    public GameObject bolum3;
    public GameObject ucuncubolumyazisi;
    //-----------------

    //4.bölüm cisimleri
    public GameObject dorduncubolumyazisi, bolum4, sarikapi4;
    //-----------------

    //5. bölüm cisimleri
    public GameObject besincibolumyazisi, bolum5, sarikapi5, morkapi5, mavikapi5;

    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource.Play();
        karakterz = karakter.transform.position.z;
        fizik = GetComponent<Rigidbody>();
        joystik = FindObjectOfType<Joystick>();
        gyroEnabled = EnableGyro();
        rot = new Quaternion(0, 0, 1, 0);
    }

    //gyro yu aktif et
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        //gyro var ise 
        if (gyroEnabled)
        {
            gyro1.text = System.Convert.ToString(Input.acceleration.x);
            gyro2.text = System.Convert.ToString(Input.acceleration.y);
            //gyro3.text = System.Convert.ToString(karaktergyrosifirlamax);
            //gyro4.text = System.Convert.ToString(Input.gyro.attitude.w);
            gyro4.text = System.Convert.ToString(speed);


          /*gyro2.text = System.Convert.ToString(karaktergyrosifirlamax);
            gyro3.text = System.Convert.ToString(Input.gyro.attitude.x - karaktergyrosifirlamax);
            gyro4.text = System.Convert.ToString(karaktergyrosifirlamax);*/

        }

        //karakterimizin hızını speed e atıyor.
        speed = fizik.velocity.magnitude;

        //kullanıcının ayarladığı ses ile karakter hızımızın sesini çarparak yuvarlanma sesini gerçekliyor.
        m_MyAudioSource.volume = (speed/10) * karaktersesi.value;

        //kontrol gyro da ise
        if (System.Convert.ToInt32(hareketsecenegi.value) == 0)
        {

            karakterx = Input.acceleration.x - karaktergyrosifirlamax;
            karaktery = Input.acceleration.y - karaktergyrosifirlamay;

            //karakteri hareketlendir
            Vector3 Nesneninyenipozisyonu = new Vector3(karakterx, 0f, karaktery);

            //karaktere eklenecek güç
            fizik.AddForce(Nesneninyenipozisyonu);
        }

        //kontrol joystikte ise
        if (System.Convert.ToInt32(hareketsecenegi.value) != 0)
        {
            //karakteri hareketlendir
            karaktery = joystik.Vertical;
            karakterx = joystik.Horizontal;
            Vector3 Nesneninyenipozisyonu = new Vector3(karakterx, 0f, karaktery);

            //karaktere eklenecek güç
            fizik.AddForce(Nesneninyenipozisyonu * nesnehizi);
        }
    }  

    void OnCollisionEnter(Collision collision)
    {
        //cisim duvarlara çarptığında 
        if (collision.collider.name == "Cube")
        {
            carpmases.SetActive(true);
        }

        //ilk bölüm sonu
        if (collision.collider.name == "kapi1")
        {
            kapisesi.SetActive(false);
            duvarlar.SetActive(false);
            karakter.SetActive(false);
            birincibolumgecisyazisi.SetActive(true);
            bolum = 2;
            bolumkayit(2);
        }
        //--------------------

        //ikinci bölüm sonu
        if (collision.collider.name == "kapi2")
        {
            kapisesi.SetActive(false);
            bolum2.SetActive(false);
            karakter.SetActive(false);
            ucuncubolumyazisi.SetActive(true);
            bolum = 3;
            bolumkayit(3);
        }
        if (collision.collider.name == "tus1mavi")
        {
            mavikapi.SetActive(false);
            kapisesi.SetActive(true);
        }
        //---------------------------

        //üçüncü bölüm koşulları
        if(collision.collider.name == "kapi3")
        {
            kapisesi.SetActive(false);
            bolum3.SetActive(false);
            karakter.SetActive(false);
            dorduncubolumyazisi.SetActive(true);
            bolum = 4;
            bolumkayit(4);
        }
        //----------------------------

        //dördüncü bölüm koşulları
        if (collision.collider.name == "kapi4")
        {
            kapisesi.SetActive(false);
            bolum4.SetActive(false);
            karakter.SetActive(false);
            besincibolumyazisi.SetActive(true);
            bolum = 5;
            bolumkayit(5);
        }
        if (collision.collider.name == "tus1sari")
        {
            sarikapi4.SetActive(false);
            kapisesi.SetActive(true);
        }
        //----------------------------

        //beşinci bölüm koşulları
        if (collision.collider.name == "tus1sari5")
        {
            sarikapi5.SetActive(false);
        }
        if (collision.collider.name == "tus1mor2")
        {
            morkapi5.SetActive(false);
        }
        if (collision.collider.name == "tus1mavi2")
        {
            mavikapi5.SetActive(false);
        }
        if (collision.collider.name == "kapi5")
        {
            kapisesi.SetActive(false);
            bolum5.SetActive(false);
            karakter.SetActive(false);
            birincibolumgecisyazisi.SetActive(true);
            bolum = 2;
            bolumkayit(2);
        }
        //------------------------
    }

    void OnCollisionExit(Collision collision)
    {
        //cisim duvardan çekildiğinde
        if (collision.collider.name == "Cube")
        {
            carpmases.SetActive(false);
        }
    }

    public void oyunudurdur()
    {
        menu.SetActive(true);
        duvarlar.SetActive(false);
        bolum2.SetActive(false);
        bolum3.SetActive(false);
        bolum4.SetActive(false);
        bolum5.SetActive(false);
        karakter.SetActive(false);
        ayarlarpanel.SetActive(false);
    }

    public void devamet()
    {
        menu.SetActive(false);
        if(bulundu == 1)
        {
            duvarlar.SetActive(true);
            karakter.SetActive(true);
        }
        if (bulundu == 2)
        {
            bolum2.SetActive(true);
            karakter.SetActive(true);
        }
        if (bulundu == 3)
        {
            bolum3.SetActive(true);
            karakter.SetActive(true);
        }
        if (bulundu == 4)
        {
            bolum4.SetActive(true);
            karakter.SetActive(true);
        }
        if (bulundu == 5)
        {
            bolum5.SetActive(true);
            karakter.SetActive(true);
        }
        if (System.Convert.ToInt32(hareketsecenegi.value) != 0) 
        {
            joystik = FindObjectOfType<Joystick>();
        }
        ayarlarpanel.SetActive(false);
    }

    public void ayarlar()
    {
        ayarlarpanel.SetActive(true);
    }

    public void menuyedon()
    {
        ayarlarpanel.SetActive(false);
    }

    //telefonun o anki yatıklık durumunu 0 olarak alır.
    public void kalibret()
    {
        karaktergyrosifirlamax = Input.acceleration.x;
        karaktergyrosifirlamay = Input.acceleration.y;
    }
    //--------------------------------------------------

    //ayarlardaki hareketseçeneğine göre olacak işler.
    public void hareketsecenegioynatildi()
    {
        if(hareketsecenegi.value == 0)
        {
            kalibreetme.SetActive(true);
            joys.SetActive(false);
            gyroyazisisi.color = Color.red;
            jostickyazisisi.color = Color.black;
            gyro.enabled = true;
        }
        if (hareketsecenegi.value == 1)
        {
            kalibreetme.SetActive(false);
            joys.SetActive(true);
            gyroyazisisi.color = Color.black;
            jostickyazisisi.color = Color.red;
            gyro.enabled = false;
        }
    }
    //--------------------------------------------------

    //-----------------------------------------------------------ayarlar kısmını kayıt et----------------------------------------------------------------
    public void ayarlarkaydet()
    {
        gyrosecenegikayit(hareketsecenegi.value);
        menusesyuksekligikayit(menusesi.value);
        karaktersesyuksekligikayit(karaktersesi.value);
    }
    public static void gyrosecenegikayit(float secenek)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/bitirmegyrosec.btr";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, secenek);
        stream.Close();
    }
    public static void menusesyuksekligikayit(float menuses)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/bitirmemenuses.btr";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, menuses);
        stream.Close();
    }
    public static void karaktersesyuksekligikayit(float karakterses)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/bitirmekarakterses.btr";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, karakterses);
        stream.Close();
    }
    //--------------------------------------------------------------------------------------------------------------------------------------------------

    //oyuncunun kaldığı bölümün kayıt ve yüklemesi
    public static void bolumkayit(int bolum)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/bolum.btr";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, bolum);
        stream.Close();
    }
    public static int bolumyukle()
    {
        int data3 = 0;
        string path = Application.persistentDataPath + "/bolum.btr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data3 = System.Convert.ToInt32(formatter.Deserialize(stream));
            stream.Close();
            return data3;
        }
        return data3;
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------

    public void kodgorundu()
    {
        bolum = bolumyukle();
        if (bolum == 0)
        {
            bolum1text.SetActive(false);
            karakter.SetActive(true);
            duvarlar.SetActive(true);
            bulundu = 1;
        }
        if (bolum == 2)
        {
            birincibolumgecisyazisi.SetActive(false);
            karakter.SetActive(true);
            bolum2.SetActive(true);
            bulundu = 2;
        }
        if (bolum == 3)
        {
            ucuncubolumyazisi.SetActive(false);
            karakter.SetActive(true);
            bolum3.SetActive(true);
            bulundu = 3;
        }
        if (bolum == 4)
        {
            dorduncubolumyazisi.SetActive(false); ;
            karakter.SetActive(true);
            bolum4.SetActive(true);
            bulundu = 4;
        }
        if (bolum == 5)
        {
            besincibolumyazisi.SetActive(false); ;
            karakter.SetActive(true);
            bolum5.SetActive(true);
            bulundu = 5;
        }
    }
}
