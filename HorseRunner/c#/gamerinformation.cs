using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class gamerinformation : MonoBehaviour
{
    public Text infusername, infrealfirstname, infreallastname, infmail, inftel;
    public Text infrealfirstname2, infreallastname2, infmail2, inftel2;
    public GameObject informationdone, nul, bilgipaneli, bilgipaneli2;
    string yazi, inf, dizioncesi;

    string[] dizi;

   /* // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    
    // oyuncu daha önce bilgiler kısmına bilgilerini göndermişmi
    public void userinformationcontrol()
    {
        string path = Application.persistentDataPath + "/HorseRunninginfo.hrs";
        if (File.Exists(path))
        {
            bilgipaneli2.SetActive(true);
            dizioncesi = informationload();
            dizi = dizioncesi.Split('|');
            infrealfirstname2.text = dizi[0];
            infreallastname2.text = dizi[1];
            infmail2.text = dizi[2];
            inftel2.text = dizi[3];
            bilgipaneli.SetActive(false);
        }
        else
        {
            bilgipaneli.SetActive(true);
            bilgipaneli2.SetActive(false);
        }
    }

    //bilgiler panelinden bilgileri gönderme işlemi.
    public void userinformationsend()
    {
        if(infrealfirstname.text != "" || infreallastname.text != "" || infmail.text != "" || inftel.text != "")
        {
            StartCoroutine(userinformation());
        }
        else
        {
            nul.SetActive(true);
        }
    }

    //php sayfasına bilgileri gönderme.
    IEnumerator userinformation()
    {
        string url2 = "http://www.bnesoftware.xyz/horserunning/gamerinformatinsaved.php";//bağlanacağımız linki yazıyoruz
        WWWForm sendForm2 = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
        sendForm2.AddField("username", infusername.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm2.AddField("firstname", infrealfirstname.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm2.AddField("lastname", infreallastname.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm2.AddField("mail", infmail.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm2.AddField("tel", inftel.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        WWW sendData2 = new WWW(url2, sendForm2);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
        yield return sendData2;//karşı taraftan bize bir sonuç geri dönüyor
        Debug.Log(sendData2.text);
        yazi = sendData2.text;

        if(yazi == "successful")
        {
            inf = infrealfirstname.text + "|" + infreallastname.text + "|" + infmail.text + "|" + inftel.text;
            informationsave(inf);
            userinformationcontrol();
        }
        if(yazi == "unsuccessful")
        {

        }
    }

    //gönderme işlemi başarılı ise bilgileri telefonada kaydetme işlemi.
    public static void informationsave(string info)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseRunninginfo.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, info);
        stream.Close();
    }

    //Daha önce bilgiler gönderildi ise telefondan bilgileri alma işlemi
    public static string informationload()
    {
        string data2 = " ";
        string path = Application.persistentDataPath + "/HorseRunninginfo.hrs";
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
}
