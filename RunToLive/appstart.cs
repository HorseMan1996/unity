using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class appstart : MonoBehaviour
{
    public GameObject gamee;
    public GameObject commpanel;
    public Text community;

    static int mission = 0;


    [SerializeField] TextMeshProUGUI informations;

    public GameObject information;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getData4());
        StartCoroutine(talking.write("I have to leave this room"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            information.SetActive(true);
            if (mission == 0)
            {
                informations.text = "Odadan çıkmak için anahtar bul";
            }
            if (mission == 1)
            {
                informations.text = "Odadan çık";
            }
            if (mission == 2)
            {
                informations.text = "Halüsinasyon görmeyi durdurmak için ilaç bul";
            }
            if (mission == 3)
            {
                informations.text = "Bu lanet yerden çıkmanın bir yolunu bul";
            }

        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            information.SetActive(false);
        }

            if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(getData5());
            commpanel.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            commpanel.SetActive(false);
        }
    }

    IEnumerator getData4()
    {
            string url = "bnesoftware.xyz/unitygame/runtolive/runtoliveapp.php";//bağlanacağımız linki yazıyoruz
            WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
            WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
            yield return sendData;//karşı taraftan bize bir sonuç geri dönüyordeğişkenleri
            Debug.Log(System.Convert.ToString(sendData.text));
            if(sendData.text != "1")
            {
                gamee.SetActive(false);
            }
    }

    IEnumerator getData5()
    {
        string url = "bnesoftware.xyz/unitygame/runtolive/runtolivecommunity.php";//bağlanacağımız linki yazıyoruz
        WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
        WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
        yield return sendData;//karşı taraftan bize bir sonuç geri dönüyordeğişkenleri
        Debug.Log(System.Convert.ToString(sendData.text));
        community.text = sendData.text;
    }

    public static void whichmission(int a)
    {
        mission = a;
    }
}
