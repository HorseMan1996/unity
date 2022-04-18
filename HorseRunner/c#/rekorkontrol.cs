using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rekorkontrol : MonoBehaviour
{
    public GameObject yenidenbaslabtn;
    public Text oyunhak;
    public GameObject olumpanel;
    public GameObject rekorpanel;
    public Text bulundugumyer;
    public Text rekorpuangonder;
    public Text isimgonder;
    public Text paramiz;

    void Update()
    {
        if(bulundugumyer.text == "2")
        {
            StartCoroutine(rekorkontrolgonder());
            bulundugumyer.text = "3";
        }
         if (System.Convert.ToInt32(oyunhak.text) > 0)
        {
           yenidenbaslabtn.SetActive(true);
        }
           if (System.Convert.ToInt32(oyunhak.text) == 0)
        {
           yenidenbaslabtn.SetActive(false);
        }
    }

    //oyuncu oyunu tammaladığında rekoru veritabanına gönderme
    IEnumerator rekorkontrolgonder()
    {
        string url2 = "http://www.bnesoftware.xyz/horserunning/hrsrngrekor.php";//bağlanacağımız linki yazıyoruz
        WWWForm sendForm2 = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
        sendForm2.AddField("isim", isimgonder.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm2.AddField("rekorpuan", rekorpuangonder.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm2.AddField("paramiz", paramiz.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        WWW sendData2 = new WWW(url2, sendForm2);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
        yield return sendData2;//karşı taraftan bize bir sonuç geri dönüyor
        Debug.Log(sendData2.text);
    }

    //rekor gösterme paneli
    public void rekorpaneli()
    {
        olumpanel.SetActive(false);
        rekorpanel.SetActive(true);
    }
}
