using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menukodsayfasi : MonoBehaviour
{
    public Text oyunhak;
    public Text isim;
    public Text isim2;
    public Text surumsayisi;
    public Text olmasigereken;
    public Text dil;
    public GameObject baslabutonu;
    public GameObject oyun;
    public GameObject menu;
    public GameObject buton1;
    public GameObject buton2;
    public GameObject puan;
    [SerializeField] GameObject wrongversion;
    [SerializeField] GameObject wrongversiontrybtn;
    int surumkontrol = 0, i = 0;
    string surumm;


    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        StartCoroutine(surumkontrolgonder());
        //isim.text = System.Convert.ToString(ziplamakod.isimyukle());
        // oyunhak.text = System.Convert.ToString(ziplamakod.oyunhakkiyukle());
    }

    // Update is called once per frame
    void Update()
    {
        /*surumkontrol++;
        /* if (System.Convert.ToInt32(oyunhak.text) > 0)
         {
             baslabutonu.SetActive(true);
         }
         if (System.Convert.ToInt32(oyunhak.text) == 0)
         {
             baslabutonu.SetActive(false);
         }
        if(surumkontrol == 10000)
        {
            StartCoroutine(surumkontrolgonder());
            surumkontrol = 0;
           
        }*/

    }
    public void baslabtn()
    {
        puan.SetActive(true);
        oyun.SetActive(true);
        
        buton1.SetActive(true);
        buton2.SetActive(true);
        oyunhak.text = System.Convert.ToString(System.Convert.ToInt32(oyunhak.text) - 1);
        i = 1;
        StartCoroutine(surumkontrolgonder());
        menu.SetActive(false);
    }
    public void yenidenbasladi()
    {
        menu.SetActive(true);
        i = 1;
        StartCoroutine(surumkontrolgonder());
        menu.SetActive(false);
    }
    public void versiontryagain()
    {
        i = 0;
        wrongversiontrybtn.SetActive(false);
        StartCoroutine(surumkontrolgonder());
        wrongversiontrybtn.SetActive(true);
    }

    IEnumerator surumkontrolgonder()
    {
        if (i == 0) 
        {
                string url2 = "http://www.bnesoftware.xyz/horserunning/surumkontrol.php";//bağlanacağımız linki yazıyoruz
                WWWForm sendForm2 = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
                WWW sendData2 = new WWW(url2, sendForm2);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
                yield return sendData2;//karşı taraftan bize bir sonuç geri dönüyor
                Debug.Log(sendData2.text);
                if (dil.text == "en")
                {
                    if (sendData2.text == surumsayisi.text)
                    {
                        wrongversion.SetActive(false);
                        olmasigereken.text = "Your version is correct.";
                        dilsec.surumdogru();
                    }
                    else
                    {
                        wrongversion.SetActive(true);
                        olmasigereken.text = "You are not on the latest version.";
                        yield return new WaitForSeconds(5);
                    }
                }
            }
        if (i == 1)
        {
            string url2 = "http://www.bnesoftware.xyz/horserunning/oyunabasladi.php";//bağlanacağımız linki yazıyoruz
            WWWForm sendForm2 = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
            sendForm2.AddField("isim", isim2.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            WWW sendData2 = new WWW(url2, sendForm2);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
            yield return sendData2;//karşı taraftan bize bir sonuç geri dönüyor
            Debug.Log(sendData2.text);
        }
        // yazi = sendData2.text;
    }
}
