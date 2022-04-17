using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class communuty : MonoBehaviour
{
    public Text comm;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getData4());
    }

    // Update is called once per frame
   /* void Update()
    {
        
    }*/

    IEnumerator getData4()
    {
        string url = "bnesoftware.xyz/unitygame/horseoffarm/communuty.php";//bağlanacağımız linki yazıyoruz
        WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
        WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
        yield return sendData;//karşı taraftan bize bir sonuç geri dönüyordeğişkenleri
        Debug.Log(System.Convert.ToString(sendData.text));
        comm.text = sendData.text;
        yield return new WaitForSeconds(20f);
        StartCoroutine(getData4());
    }
}
