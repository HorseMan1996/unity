using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using TMPro;

public class alreadymemb : MonoBehaviour
{
    [SerializeField] Text secname4;
    [SerializeField] Text seclastname4;
    [SerializeField] Text secpassword4;
    [SerializeField] Text secemail4;
    [SerializeField] Text secnumber4;
    [SerializeField] Text secage4;
    [SerializeField] Text secmale4;
    [SerializeField] Text secusername4;

    public GameObject mainpanel;
    public GameObject alreadypanel;
    public GameObject registerypanel;

    public string[] ad2;
    [SerializeField] TextMeshProUGUI alreadyphone;

    [SerializeField] TextMeshProUGUI alreadypassword;

    public GameObject warning;

    string inf;
    // Start is called before the first frame update
   /* void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }*/

    public void alreadybtn()
    {
        StartCoroutine(getversioncontrol());
    }

    IEnumerator getversioncontrol()
    {
        string url = "bnesoftware.xyz/horseofmessage/alreadymemb.php";//bağlanacağımız linki yazıyoruz
        WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
        sendForm.AddField("phone", alreadyphone.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm.AddField("password", alreadypassword.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
        yield return sendData;//karşı taraftan bize bir sonuç geri dönüyor
        Debug.Log(System.Convert.ToString(sendData.text));
        ad2 = sendData.text.Split('|');
        if (ad2[0] == "success")
        {
            inf = ad2[1] + "|" + ad2[2] + "|" + ad2[3] + "|" + ad2[4] + "|" + ad2[5] + "|" + ad2[6] + "|" + ad2[7] + "|" + ad2[8];
            registercode.filerecord(inf);
            secname4.text = ad2[1];
            seclastname4.text = ad2[2];
            secpassword4.text = ad2[3];
            secemail4.text = ad2[4];
            secnumber4.text = ad2[5];
            secage4.text = ad2[6];
            secmale4.text = ad2[7];
            secusername4.text = ad2[8];
            mainpanel.SetActive(true);
            alreadypanel.SetActive(false);
            registerypanel.SetActive(false);
        }
        else
        {
            warning.SetActive(true);
        }
        
    }
}
