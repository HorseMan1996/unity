using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using TMPro;
using System;

public class room : MonoBehaviour
{
    public string[] ad5;
    [SerializeField] Text personname;
    [SerializeField] TextMeshProUGUI talking;
    [SerializeField] TextMeshProUGUI writing;
    public static string roomsname;
    static int i = 0;
    int sec = 1;
    public int g = 0, h = 1;
    public int keep = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getData4());
    }

    // Update is called once per frame
    /*void Update()
    {
        keep++;
        if(keep == 500)
        {
            i = 1;
            if (i == 1)
            {
                i = 0;
                keep = 0;
                sec = 1;
                StartCoroutine(getData4());
            }
        }
        
    }*/

    IEnumerator getData4()
    {
        if (sec == 1)
        {
            string url = "bnesoftware.xyz/horseofmessage/talking.php";//bağlanacağımız linki yazıyoruz
            WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
            sendForm.AddField("roomname", roomsname);//karşı tarafada yazdığımız  isimleri aynı olacak şekilde eşleştiriyoruz
            WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
            yield return sendData;//karşı taraftan bize bir sonuç geri dönüyordeğişkenleri
            Debug.Log(System.Convert.ToString(sendData.text));
            ad5 = sendData.text.Split('|');
            talking.text = "";
            for (int i = 1; i < ad5.Length; i = i + 2)
            {
                talking.text += ad5[g] + " : " + ad5[h] + '\n';
                g = g + 2;
                h = h + 2;
            }
            g = 0;
            h = 1;
            Array.Clear(ad5, 0, ad5.Length);
            yield return new WaitForSecondsRealtime(10);
            sec = 1;
            StartCoroutine(getData4());
        }
        if(sec == 2)
        {
            string url = "bnesoftware.xyz/horseofmessage/write.php";//bağlanacağımız linki yazıyoruz
            WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
            sendForm.AddField("roomname", roomsname);//karşı tarafada yazdığımız  isimleri aynı olacak şekilde eşleştiriyoruz
            sendForm.AddField("personname", personname.text);//karşı tarafada yazdığımız  isimleri aynı olacak şekilde eşleştiriyoruz
            sendForm.AddField("write", writing.text);//karşı tarafada yazdığımız  isimleri aynı olacak şekilde eşleştiriyoruz
            WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
            yield return sendData;//karşı taraftan bize bir sonuç geri dönüyordeğişkenleri
            Debug.Log(System.Convert.ToString(sendData.text));
            writing.text = "";
            yield return new WaitForSecondsRealtime(10);
            sec = 1;
            StartCoroutine(getData4());
        }

    }

    public void sendbtn()
    {
        sec = 2;
        StartCoroutine(getData4());
    }

    public static void roomssname(string a)
    {
        i = 1;
        roomsname = a;
    }
}