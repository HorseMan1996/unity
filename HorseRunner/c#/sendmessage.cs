using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sendmessage : MonoBehaviour
{
    [SerializeField] private InputField message;
    [SerializeField] private Text name;
    [SerializeField] private GameObject yazi;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    //mesaj gönderme butonu.
    public void sendmesajbtn()
    {
        StartCoroutine(usermessage());
    }

    //veri tabanına gönder.
    IEnumerator usermessage()
    {
        string url2 = "http://www.bnesoftware.xyz/horserunning/sendmessage.php";//bağlanacağımız linki yazıyoruz
        WWWForm sendForm2 = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
        sendForm2.AddField("name", name.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm2.AddField("message", message.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        WWW sendData2 = new WWW(url2, sendForm2);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
        yield return sendData2;//karşı taraftan bize bir sonuç geri dönüyor

        yazi.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        yazi.SetActive(false);
    }
}
