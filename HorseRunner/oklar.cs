using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class oklar : MonoBehaviour
{
    public Text oyuncuismi;
    public GameObject gift;
    int say = 0, vur = 0;

    public Text bilg;
    public int okbasla = 0;
    static int oksifirlama = 1;
    public AudioSource oksesi;
    public GameObject ok;
    public GameObject ok2;
    int okzamani = 0, oyunzamanı=0, okgeliszamanirastgele;
    float okx, oky, ok2y, ok2x;
    float rastgelesayi, okhizi, okyonu, rastgelesayi2, ok2yonu, ok2hizi, giftkonumx, giftkonumy;
    // Start is called before the first frame update
    void Start()
    {
        vur = 0;
        say = 0;

        ok2.SetActive(false);
        okyonu = Random.Range(-0.03f, 0.03f);
        ok2yonu = Random.Range(-0.03f, 0.03f);
        okhizi = Random.Range(0.0005f, 0.0020f);
        ok2hizi = Random.Range(0.0005f, 0.0020f);
        oksesi = GetComponent<AudioSource>();
        rastgelesayi = Random.Range(-1.24f, 1.2f);
        rastgelesayi2 = Random.Range(-1.24f, 1.2f);
        okgeliszamanirastgele = Random.Range(130, 200);
        okx = ok.transform.position.x;
        oky = ok.transform.position.y;
        ok2x = ok2.transform.position.x;
        ok2y = ok2.transform.position.y;

        gift.SetActive(true);
        giftkonumx = gift.transform.position.x;
        giftkonumy = gift.transform.position.y;
        gift.SetActive(false);
        StartCoroutine(hediye());
    }
    // Update is called once per frame
    void Update()
    {
        /*bilg.text = System.Convert.ToString(say);
        say++;
        if(say == 1000)
        {
            say = 0;
            StartCoroutine(hediye());
        }*/

        if(vur == 1)
        {
            gift.transform.position = gift.transform.position - new Vector3(0.04f, 0f, 0f);
        }

        okbasla++;
        if (okbasla > 250)
        {
            oyunzamanı++;
            if (okzamani == 2)
            {
                okgeliszamanirastgele = Random.Range(130, 200);
                oksesi.Play();
            }
            if (okzamani == 50)
            {
                oksesi.Stop();
            }
            if ((okzamani >= 0) && (okzamani <= okgeliszamanirastgele))
            {
                okhizi = okhizi + 0.007f;
                ok2hizi = ok2hizi + 0.007f;
                okzamani++;
                ok.transform.position = ok.transform.position - new Vector3(okhizi, 0f, 0f);
                ok.transform.position = ok.transform.position - new Vector3(0f, okyonu, 0f);

                ok2.transform.position = ok2.transform.position - new Vector3(ok2hizi, 0f, 0f);
                ok2.transform.position = ok2.transform.position - new Vector3(0f, ok2yonu, 0f);
                //ok.transform.rotation = Quaternion.Euler(0f, 0f, 0.1f);
                //ok.transform.Rotate(0.0f, 0f, -0.01f, Space.Self);
            }
            if (okzamani == (okgeliszamanirastgele + 1))
            {
                rastgelesayi = Random.Range(-1.0f, 1.5f);
                rastgelesayi2 = Random.Range(-1.24f, 0.2f);
                ok.transform.position = new Vector3(okx, rastgelesayi);
                okyonu = Random.Range(-0.005f, 0.005f);
                ok2.transform.position = new Vector3(ok2x, rastgelesayi2);
                ok2yonu = Random.Range(-0.005f, 0.005f);
                if (oyunzamanı < 1000)
                {
                    okhizi = Random.Range(0.00010f, 0.0025f);
                    ok2hizi = Random.Range(0.00010f, 0.0025f);
                }
                if ((oyunzamanı > 1000) && (oyunzamanı < 2000))
                {
                    okhizi = Random.Range(0.0025f, 0.0055f);
                    ok2hizi = Random.Range(0.0025f, 0.0055f);
                }
                if ((oyunzamanı > 2000) && (oyunzamanı < 3000))
                {
                    okhizi = Random.Range(0.15f, 0.25f);
                    ok2hizi = Random.Range(0.15f, 0.25f);
                }
                if ((oyunzamanı > 3000) && (oyunzamanı < 4000))
                {
                    ok2.SetActive(true);
                    okhizi = Random.Range(0.25f, 0.35f);
                    ok2hizi = Random.Range(0.25f, 0.35f);
                }
                if ((oyunzamanı > 4000) && (oyunzamanı < 6000))
                {
                    okhizi = Random.Range(0.40f, 0.50f);
                    ok2hizi = Random.Range(0.40f, 0.50f);
                }
                if ((oyunzamanı > 6000) && (oyunzamanı < 10000))
                {
                    okhizi = Random.Range(0.15f, 0.25f);
                    ok2hizi = Random.Range(0.15f, 0.25f);
                }
                if (oyunzamanı > 10000)
                {
                    oyunzamanı = 0;
                }
                okzamani = 0;
            }
            if (oksifirlama == 0)
            {
                gift.transform.position = new Vector3(giftkonumx, giftkonumy, 0f);
                gift.SetActive(false);
                oyunzamanı = 0;
                okbasla = 0;
                oksifirlama = 1;
                ok2.SetActive(false);
            }
        }
    }
    static public void oksifirla()
    {
        oksifirlama = 0;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //ziplamakod.oktemas();
    }

     IEnumerator hediye()
     {
         string url2 = "http://www.bnesoftware.xyz/horserunning/yapimcihediyesi.php";//bağlanacağımız linki yazıyoruz
         WWWForm sendForm2 = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
         sendForm2.AddField("isim", oyuncuismi.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
         WWW sendData2 = new WWW(url2, sendForm2);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
         yield return sendData2;//karşı taraftan bize bir sonuç geri dönüyor
         Debug.Log(" az onceki sonuc " + sendData2.text);
        if(sendData2.text == "1")
        {
            gift.SetActive(true);
            vur = 1;
        }
        if(sendData2.text == "0")
        {
            vur = 0;
        }
     }
}
