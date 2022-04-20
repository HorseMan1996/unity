using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progstars : MonoBehaviour
{
    public GameObject registerpanel;
    public GameObject startsrpanel;
    public GameObject connectedfailed;
    public GameObject connectedtrybtn;
    public Image startsobject;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getversioncontrol());
    }

    /*// Update is called once per frame
    void FixedUpdate()
    {

    }*/

    public void retrytry()
    {
        StartCoroutine(getversioncontrol());
    }

    IEnumerator getversioncontrol()
    {
        string url = "bnesoftware.xyz/horseofmessage/versioncontrol.php";//bağlanacağımız linki yazıyoruz
        WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
        sendForm.AddField("name", "1");//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
        yield return sendData;//karşı taraftan bize bir sonuç geri dönüyor
        if (System.Convert.ToString(sendData.text) == "1")
        {
            registerpanel.SetActive(true);
            startsrpanel.SetActive(false);
        }
        else
        {
            connectedfailed.SetActive(true);
            connectedtrybtn.SetActive(true);
        }
    }

}
