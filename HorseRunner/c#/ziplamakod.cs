using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ziplamakod : MonoBehaviour
{
    public Text kalkanvarr;
    public Text ilerisarvarr;
    public Text paramiz;
    public Text oyunhak;
    public Text bulundugumyer;
    public Text isim;
    public Text isimolummenu;
    string isim2;
    public AudioSource vurulmasesi;
    public AudioSource yurumesesi;
    bool m_Play = true;
    public Text rekorpuan;
    public GameObject kalkan;
    public GameObject kalkanyara1;
    public GameObject kalkanyara2;
    public GameObject yara1;
    public GameObject yara2;
    public GameObject bilgipanel;
    public GameObject ayarlarpanel;
    public GameObject rekorpanel;
    public GameObject olummenusu;
    public GameObject oyunsahnesi;
    public GameObject menu;
    public GameObject kask;
    public GameObject tekerkonumu;
    public GameObject teker;
    public GameObject tekeron;
    public GameObject tekeronkonumu;
    public GameObject aracgovde;
    public Text puantext;
    float movespeed = 0.1f;
    float okx, oky, zeminx, zeminy, c = 0;
    public GameObject zemin;
    public GameObject ok;
    public int ziplama = 2;
    public int ziplamazamani = 0;
    public int oturma = 0;
    private Animator animator;
    public GameObject karakter;
    float karaktery, karakterx;
    float ziplamahizlanmasi = 1;
    int puanbaslat = 1, puan = 0, rekor = 0;
    public int vurulma = 0;
    int rekorkayit = 0;
    int basla = 1;
    static int kalkanvuruldu = 0, oktemasi = 0, sagliktemasi = 0;

    //şaplakar----------------------------------------

    public GameObject sapka1tak;
    public GameObject sapka2tak;
    public GameObject sapka3tak;
    public GameObject sapka4tak;
    public GameObject sapka5tak;
    public GameObject sapka6tak;
    public Text hangisapkatakilsin;

    //------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        isimolummenu.text = isimyukle();
        vurulmasesi = GetComponent<AudioSource>();
        yurumesesi.Play();
        yurumesesi = GetComponent<AudioSource>();
        karaktery = karakter.transform.position.y;
        karakterx = karakter.transform.position.x;
        animator = GetComponent<Animator>();
        zeminx = zemin.transform.position.x;
        zeminy = zemin.transform.position.y;
        okx = ok.transform.position.x;
        oky = ok.transform.position.y;
        rekorkayit = yukle();
        rekoruyaz();

    }

    // Update is called once per frame
    void Update()
    {
        if (karakter.transform.position.x < karakterx)
        {
            karakter.transform.position = new Vector3(karakterx, karaktery);
        }
        if (karakter.transform.position.y < karaktery)
        {
            karakter.transform.position = new Vector3(karakterx, karaktery);
        }

        teker.transform.Rotate(0.0f, 0f, -3f, Space.Self);
        teker.transform.position = tekerkonumu.transform.position;
        tekeron.transform.Rotate(0.0f, 0f, -3f, Space.Self);
        tekeron.transform.position = tekeronkonumu.transform.position;
        if (m_Play == false)
        {
            yurumesesi.Pause();
        }
        if (ziplama == 1)
        {
            yurumesesi.Pause();
            ziplamahizlanmasi = ziplamahizlanmasi - 0.03f;
            ziplamazamani++;
            if (vurulma >= 0)
            {
                animator.SetBool("oturma", true);
                animator.SetBool("kalkanlaziplama", true);
            }
            karakter.transform.position = karakter.transform.position + new Vector3(0f, 0.3f * ziplamahizlanmasi, 0f);
            if (ziplamazamani == 35)
            {
                ziplama = 0;
            }
            if (vurulma < 0)
            {
                animator.SetBool("oturma", true);
                animator.SetBool("kalkanlaziplama", true);
            }
        }
        if (ziplama == 0)
        {
            ziplamahizlanmasi = ziplamahizlanmasi + 0.03f;
            ziplamazamani--;
            karakter.transform.position = karakter.transform.position - new Vector3(0f, 0.3f * ziplamahizlanmasi, 0f);
            if (ziplamazamani == 0)
            {
                yurumesesi.Play();
                ziplamazamani = 0;
                karakter.transform.position = new Vector3(karakterx, karaktery, 0f);
                if (vurulma >= 0)
                {
                    animator.SetBool("oturma", false);
                }
                ziplama = 2;
                ziplamahizlanmasi = 1;
                if (vurulma < 0)
                {
                    animator.SetBool("kalkanlaziplama", false);
                }
            }
        }

        if (oturma == 1)
        {
            animator.SetBool("kalkanac", true);
            oturma = 2;
        }
        if (oturma == 3)
        {
            animator.SetBool("kalkanac", false);
            oturma = 0;
        }
        if (oturma == 20)
        {
            m_Play = true;
            yurumesesi.Play();
            animator.SetBool("oturma", false);
            oturma = 0;
        }
        c++;
        zemin.transform.position = zemin.transform.position - new Vector3(movespeed, 0f);
        if (c == 660)
        {
            zemin.transform.position = new Vector3(zeminx, zeminy);
            c = 0;
        }
        if ((kalkanvarr.text == "kalkanvar") && (basla == 1))
        {
            kalkan.SetActive(true);
            animator.SetBool("kalkanac", true);
            vurulma = -3;
            basla = 0;
        }
        if (puanbaslat == 1)
        {
            puan++;
            puantext.text = System.Convert.ToString(puan);
            if (ilerisarvarr.text == "ilerisarvar")
            {
                ilerisarvarr.text = "ilerisaryok";
                ilerisarkayit(0);
                puan = 2000;
            }
        }

        if (vurulma == -2)
        {
            kalkanyara1.SetActive(true);
        }
        if (vurulma == -1)
        {
            kalkanyara2.SetActive(true);
        }

        if (vurulma == 0)
        {
            animator.SetBool("kalkanac", false);
            animator.SetBool("ilkyara", false);
            kalkan.SetActive(false);
            kalkanyara1.SetActive(false);
            kalkanyara2.SetActive(false);
            kalkanvarr.text = "kalkanyok";
            ziplamakod.malzemekayit(0);
        }
        if (vurulma == 1)
        {
            animator.SetBool("ilkyara", true);
            animator.SetBool("ikinciyara", false);
        }
        if (vurulma == 2)
        {
            animator.SetBool("ikinciyara", true);
        }
        if (oktemasi == 1)
        {
            oktemasi = 0;
            vurulma = vurulma + 1;
            ok.transform.position = new Vector3(okx, oky);
            Debug.Log("vuruldum");
            vurulmases.vuruldum();
        }

        if (vurulma >= 3)
        {
            vurulma = 0;
            parakodu.kazanilanpara((System.Convert.ToInt32(puantext.text)));
            oklar.oksifirla();
            bulundugumyer.text = "2";
            isimolummenu.text = isimyukle();
            enyuksek();
            yara1.SetActive(false);
            yara2.SetActive(false);
            puan = 0;
            ok.transform.position = new Vector3(okx, oky);
            oyunsahnesi.SetActive(false);
            menu.SetActive(false);
            olummenusu.SetActive(true);
            puanbaslat = 0;
        }
        if ((sagliktemasi == 1) && (vurulma > 0))
        {
            vurulma--;
            sagliktemasi = 0;
        }
    }

    public void ziplamabtn()
    {
        if (ziplama == 2)
        {
            ziplama = 1;
        }
    }
    public void ziplamabtnkaldir()
    {
        if (ziplama != 2)
        {
            ziplama = 0;
        }
    }
    public void oturmabtnbas()
    {
        if (oturma == 0)
        {
            oturma = 1;
        }
        if (oturma == 2)
        {
            oturma = 3;
        }
    }
    public void geribtn()
    {
        bulundugumyer.text = "0";
        bilgipanel.SetActive(false);
        ayarlarpanel.SetActive(false);
        rekorpanel.SetActive(false);
        oyunsahnesi.SetActive(false);
        menu.SetActive(true);
        olummenusu.SetActive(false);
    }
    public void yenidenbasla()
    {
        oyunhak.text = System.Convert.ToString(System.Convert.ToInt32(oyunhak.text) - 1);
        bulundugumyer.text = "1";
        animator.SetBool("olum", false);
        oyunsahnesi.SetActive(true);
        menu.SetActive(false);
        olummenusu.SetActive(false);
        puanbaslat = 1;
        yurumesesi.Play();
        oyunhakkikayit(System.Convert.ToInt32(oyunhak.text));
        basla = 1;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "oklarrrgift")
        {
            vurulma = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "okustu")
        {
            puan = puan + 100;
        }

        if (collider.name == "ok(kd)")
        {
            oktemas();
        }
    }
    public static void oktemas()
    {
        oktemasi = 1;
    }

    public static void sagliktemas()
    {
        sagliktemasi = 1;
    }

    public void puanibaslat()
    {
        //şapka kontrolü------------
        if (hangisapkatakilsin.text == "1")
        {
            sapka1tak.SetActive(true);
            sapka2tak.SetActive(false);
            sapka3tak.SetActive(false);
            sapka4tak.SetActive(false);
            sapka5tak.SetActive(false);
            sapka6tak.SetActive(false);
        }
        if (hangisapkatakilsin.text == "2")
        {
            sapka1tak.SetActive(false);
            sapka2tak.SetActive(true);
            sapka3tak.SetActive(false);
            sapka4tak.SetActive(false);
            sapka5tak.SetActive(false);
            sapka6tak.SetActive(false);
        }
        if (hangisapkatakilsin.text == "3")
        {
            sapka1tak.SetActive(false);
            sapka2tak.SetActive(false);
            sapka3tak.SetActive(true);
            sapka4tak.SetActive(false);
            sapka5tak.SetActive(false);
            sapka6tak.SetActive(false);
        }
        if (hangisapkatakilsin.text == "4")
        {
            sapka1tak.SetActive(false);
            sapka2tak.SetActive(false);
            sapka3tak.SetActive(false);
            sapka4tak.SetActive(true);
            sapka5tak.SetActive(false);
            sapka6tak.SetActive(false);
        }
        if (hangisapkatakilsin.text == "5")
        {
            sapka1tak.SetActive(false);
            sapka2tak.SetActive(false);
            sapka3tak.SetActive(false);
            sapka4tak.SetActive(false);
            sapka5tak.SetActive(true);
            sapka6tak.SetActive(false);
        }
        if (hangisapkatakilsin.text == "6")
        {
            sapka1tak.SetActive(false);
            sapka2tak.SetActive(false);
            sapka3tak.SetActive(false);
            sapka4tak.SetActive(false);
            sapka5tak.SetActive(false);
            sapka6tak.SetActive(true);
        }
        //-------------------------
        basla = 1;
        oyunhakkikayit(System.Convert.ToInt32(oyunhak.text));
        puanbaslat = 1;
        if (isim.text != "")
        {
            isimkayit(isim.text);
        }
    }
    void enyuksek()
    {
        if (System.Convert.ToInt32(rekorpuan.text) < System.Convert.ToInt32(puantext.text))
        {
            rekor = System.Convert.ToInt32(puantext.text);
            rekorpuan.text = System.Convert.ToString(rekor);
            rekorkayit = System.Convert.ToInt32(puantext.text);
            kayit(rekorkayit);
        }
    }
    public static void kayit(int rekor)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseRun.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, rekor);
        stream.Close();
    }

    public static int yukle()
    {
        int data = 0;
        string path = Application.persistentDataPath + "/HorseRun.hrs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data = System.Convert.ToInt32(formatter.Deserialize(stream));
            stream.Close();
            return data;
        }
        return data;
    }
    public void rekoruyaz()
    {
        rekorpuan.text = System.Convert.ToString(rekorkayit);
    }

    public static void isimkayit(string isim)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseRunisim.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, isim);
        stream.Close();
    }
    public static string isimyukle()
    {
        string data2 = " ";
        string path = Application.persistentDataPath + "/HorseRunisim.hrs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data2 = System.Convert.ToString(formatter.Deserialize(stream));
            stream.Close();
            return data2;
        }
        else
        {
            return data2;
        }
    }
    public static void oyunhakkikayit(int oyun)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseRunoyunhakki.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, oyun);
        stream.Close();
    }
    public static int oyunhakkiyukle()
    {
        int data3 = 0;
        string path = Application.persistentDataPath + "/HorseRunoyunhakki.hrs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data3 = System.Convert.ToInt32(formatter.Deserialize(stream));
            stream.Close();
            return data3;
        }
        else
        {
            return data3;
        }
    }
    public static void parakayit(int para)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseRunpara.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, para);
        stream.Close();
    }
    public static int parayukle()
    {
        int data4 = 0;
        string path = Application.persistentDataPath + "/HorseRunpara.hrs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data4 = System.Convert.ToInt32(formatter.Deserialize(stream));
            stream.Close();
            return data4;
        }
        else
        {
            return data4;
        }
    }
    public static void malzemekayit(int malzeme)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseRunmalzemeler.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, malzeme);
        stream.Close();
    }
    public static int malzemeyukle()
    {
        int data5 = 0;
        string path = Application.persistentDataPath + "/HorseRunmalzemeler.hrs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data5 = System.Convert.ToInt32(formatter.Deserialize(stream));
            stream.Close();
            return data5;
        }
        else
        {
            return data5;
        }
    }

    public static void ilerisarkayit(int ilerisar)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseRunilerisar.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, ilerisar);
        stream.Close();
    }
    public static int ilerisaryukle()
    {
        int data6 = 0;
        string path = Application.persistentDataPath + "/HorseRunilerisar.hrs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data6 = System.Convert.ToInt32(formatter.Deserialize(stream));
            stream.Close();
            return data6;
        }
        else
        {
            return data6;
        }
    }
    public static void sapkakayit(int sapka)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseRunsapka.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, sapka);
        stream.Close();
    }
    public static int sapkayukle()
    {
        int data7 = 1;
        string path = Application.persistentDataPath + "/HorseRunsapka.hrs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data7 = System.Convert.ToInt32(formatter.Deserialize(stream));
            stream.Close();
            return data7;
        }
        else
        {
            return data7;
        }
    }
}
