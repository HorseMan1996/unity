using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rekorgoster : MonoBehaviour
{
    public Text bulundugumyer;
    public Text birinciad;
    public Text ikinciad;
    public Text ucuncuad;
    public Text dorduncuad;
    public Text besinciad;
    public Text altinciad;
    public Text yedinciad;
    public Text sekizinciad;
    public Text dokuzuncuad;
    public Text onuncuad;
    public Text birincirekor;
    public Text ikincirekor;
    public Text ucuncurekor;
    public Text dorduncurekor;
    public Text besincirekor;
    public Text altincirekor;
    public Text yedincirekor;
    public Text sekizincirekor;
    public Text dokuzuncurekor;
    public Text onuncurekor;
    public int goster=990;
    string[] rekorlar = new string[6];
    string yazi;
    // Start is called before the first frame update
   /* void Start()
    {
        
    }
   */
    // Update is called once per frame
    void Update()
    {
        goster++;
        if ((goster == 1000))
        {
            StartCoroutine(rekorkontrolgonder());
            goster = 0;
        }
        birinciad.text = rekorlar[0];
        birincirekor.text = rekorlar[1];
        ikinciad.text = rekorlar[2];
        ikincirekor.text = rekorlar[3];
        ucuncuad.text = rekorlar[4];
        ucuncurekor.text = rekorlar[5];
        dorduncuad.text = rekorlar[6];
        dorduncurekor.text = rekorlar[7];
        besinciad.text = rekorlar[8];
        besincirekor.text = rekorlar[9];
        altinciad.text = rekorlar[10];
        altincirekor.text = rekorlar[11];
        yedinciad.text = rekorlar[12];
        yedincirekor.text = rekorlar[13];
        sekizinciad.text = rekorlar[14];
        sekizincirekor.text = rekorlar[15];
        dokuzuncuad.text = rekorlar[16];
        dokuzuncurekor.text = rekorlar[17];
        onuncuad.text = rekorlar[18];
        onuncurekor.text = rekorlar[19];
    }
    IEnumerator rekorkontrolgonder()
    {
        string url2 = "http://www.bnesoftware.xyz/horserunning/hrsrngrekorgoster.php";//bağlanacağımız linki yazıyoruz
        WWWForm sendForm2 = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
        WWW sendData2 = new WWW(url2, sendForm2);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
        yield return sendData2;//karşı taraftan bize bir sonuç geri dönüyor
        Debug.Log(sendData2.text);
        yazi = sendData2.text;
        rekorlar = yazi.Split('|');
        Debug.Log(rekorlar[0]);
    }
}
