using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class jenerikkod : MonoBehaviour
{
    public GameObject oyunhak;
    public GameObject anamenu;
    public GameObject anamenuoncesi;
    public GameObject jenerik;
    public GameObject puan;
    public GameObject rekorpuan;
    public GameObject uyariyazisi;
    public GameObject uyariyazisisimbos;
    public GameObject zatenuyebtn;
    public GameObject zatenuyepanel;
    public GameObject bazihatalar;
    public GameObject zatenolansayfa;

    public Text zatenolanisim;
    public Text zatenolansifre;

    public Text isimkontroltext;
    public Text isimyaztext;
    public Text oyunhakki;
    public Text oyunpara;
    public Text rekorumuz;
    public Text usernamehold;
    public Text password;
    int a=0;
    int girisolmusmu = 0;

    string[] rekorlar = new string[6];
    string yazi;

    int b = 0;
    // Start is called before the first frame update
    void Start()
    {
        yukle();
    }

    // Update is called once per frame
    void Update()
    {
        a++;
        if (a == 200 && girisolmusmu == 0)
        {
            anamenuoncesi.SetActive(false);
            anamenu.SetActive(true);
            puan.SetActive(true);
            rekorpuan.SetActive(true);
            jenerik.SetActive(false);
        }
        if (a == 200 && girisolmusmu == 1)
        {
            anamenuoncesi.SetActive(true);
            anamenu.SetActive(false);
            puan.SetActive(true);
            rekorpuan.SetActive(true);
            jenerik.SetActive(true);
        }
    }
    public void yukle()
    {
        string path = Application.persistentDataPath + "/HorseRunisim.hrs";
        if (File.Exists(path))
        {
            isimyaztext.text = System.Convert.ToString(isimyuklet());
            usernamehold.text = isimyaztext.text;
            girisolmusmu = 0;
        }
        else
        {
            girisolmusmu = 1;
        }
    }

    public void isimkontrol()
    {
        if(isimkontroltext.text != "" || password.text != "")
        {
            StartCoroutine(isimgonderkontrol());
        }
        if(isimkontroltext.text == "" || password.text == "")
        {
            uyariyazisisimbos.SetActive(true);
        }
    }

    public void zatenolanisimkontrol()
    {
        if (zatenolanisim.text != "" || zatenolansifre.text != "")
        {
            StartCoroutine(isimgonderkontrol());
        }
        if (zatenolanisim.text == "" || zatenolansifre.text == "")
        {
            uyariyazisisimbos.SetActive(true);
        }
    }

    IEnumerator isimgonderkontrol()
    {
        if(b == 0)
        {
            string url2 = "http://www.bnesoftware.xyz/horserunning/isimkontrol.php";//bağlanacağımız linki yazıyoruz
            WWWForm sendForm2 = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
            sendForm2.AddField("isim", isimkontroltext.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            sendForm2.AddField("sifre", password.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            WWW sendData2 = new WWW(url2, sendForm2);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
            yield return sendData2;//karşı taraftan bize bir sonuç geri dönüyor
            Debug.Log(sendData2.text);
            if (sendData2.text == "isimvar")
            {
                uyariyazisi.SetActive(true);
            }
            if (sendData2.text == "isimyok")
            {
                isimkayitet(isimkontroltext.text);
                oyunhakki.text = "2";
                anamenuoncesi.SetActive(false);
                anamenu.SetActive(true);
                puan.SetActive(true);
                rekorpuan.SetActive(true);
                isimyaztext.text = System.Convert.ToString(isimyuklet());
                usernamehold.text = isimyaztext.text;
                jenerik.SetActive(false);
            }
        }

        if(b == 1)
        {
            string url2 = "http://www.bnesoftware.xyz/horserunning/zatenkayitli.php";//bağlanacağımız linki yazıyoruz
            WWWForm sendForm2 = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
            sendForm2.AddField("isim", zatenolanisim.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            sendForm2.AddField("sifre", zatenolansifre.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            WWW sendData2 = new WWW(url2, sendForm2);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
            yield return sendData2;//karşı taraftan bize bir sonuç geri dönüyor
            if(sendData2.text == "0")
            {
                bazihatalar.SetActive(true);
            }
            else
            {
                yazi = sendData2.text;
                rekorlar = yazi.Split('|');
                isimkayitet(zatenolanisim.text);
                oyunhakki.text = "2";
                anamenuoncesi.SetActive(false);
                anamenu.SetActive(true);
                puan.SetActive(true);
                rekorpuan.SetActive(true);
                isimyaztext.text = System.Convert.ToString(isimyuklet());
                usernamehold.text = zatenolanisim.text;
                oyunpara.text = rekorlar[1];
                parakayit2(System.Convert.ToInt32(oyunpara.text));
                rekorumuz.text = rekorlar[0];
                kayit2(System.Convert.ToInt32(rekorumuz.text));
                zatenolansayfa.SetActive(false);
                jenerik.SetActive(false);
            }
        }
    }

    public static void isimkayitet(string isim)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseRunisim.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, isim);
        stream.Close();
    }

    public static string isimyuklet()
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

    public static void parakayit2(int para)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseRunpara.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, para);
        stream.Close();
    }

    public static void kayit2(int rekor)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseRun.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, rekor);
        stream.Close();
    }


    public void zatenkayitli()
    {
        b = 1;
    }
    public void zatenkayitlidegil()
    {
        b = 0;
    }
}
