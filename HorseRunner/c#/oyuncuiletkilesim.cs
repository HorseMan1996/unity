using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyuncuiletkilesim : MonoBehaviour
{
    public Text etkilesim;
    string yazi;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(iletisim());
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    //veritabanımda yazdığım mesajın oyuncularda gözükmesi için
    IEnumerator iletisim()
    {
        string url2 = "http://www.bnesoftware.xyz/horserunning/iletisim.php";//bağlanacağımız linki yazıyoruz
        WWWForm sendForm2 = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
        WWW sendData2 = new WWW(url2, sendForm2);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
        yield return sendData2;//karşı taraftan bize bir sonuç geri dönüyor
        Debug.Log(sendData2.text);
        yazi = sendData2.text;
        etkilesim.text = yazi;
    }
}
