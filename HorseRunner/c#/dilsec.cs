using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dilsec : MonoBehaviour
{
    string instagram = "https://www.instagram.com/horsemansgame/";


    public GameObject bilgipanel;
    public Text surumbilgisi;
    public Text dil;
    public Text jenerik;
    public Text isimgirin;
    public Text eniyiyapanlarisim;
    public Text eniyiyapanlarpuan;
    public Text surumyazi;
    public GameObject ayarlarpanel;
    public Text reklamuyariyazisi;

    public Text kalkan;
    public Text parayetersiz;
    public Text kalkanalindi;
    public Text kalkanalbtntext;

    public Text ilerisar;
    public Text ilerisarparayetersiz;
    public Text ilerisaralindi;
    public Text ilerisarbtntext;

    public Text sapka1btn;
    public Text sapka2btn;
    public Text sapka3btn;
    public Text sapka4btn;
    public Text sapka5btn;
    public Text sapka6btn;

    //bilgiler-kısmı-
    public Text firstname, lastname, mailadress, telephone, bos;
    //--------------

    public Text dahafazlaparaicin;
    static int surumm = 0;
/*
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    
    public void trdili()
    //Ayarlar kısmında tr butonuna basıldığında yapılacak işlemler..
    {
        dil.text = "tr";
        isimgirin.text = "Adınızı yazın...";
        eniyiyapanlarisim.text = "İsimler";
        eniyiyapanlarpuan.text = "Puanlar";
        jenerik.text = "Jenerik";
        surumyazi.text = "Sürüm:";
        if (surumm == 1)
        {
            surumbilgisi.text = "Sürümünüz dogru.";
        }
        else
        {
            surumbilgisi.text = "Son sürümde degilsiniz.";
        }
        reklamuyariyazisi.text = "Oyunu oynamak için artı butonuna tıklayın.";


        //magaza
        kalkan.text = "KALKAN";
        parayetersiz.text = "Paran Yok";
        kalkanalindi.text = "Kalkanın Var";
        kalkanalbtntext.text = "AL";

        ilerisar.text = "+2000";
        ilerisarparayetersiz.text = "Paran Yok";
        ilerisaralindi.text = "Artı Puan Var";
        ilerisarbtntext.text = "AL";

        dahafazlaparaicin.text = "Daha Fazla Para";

        sapka1btn.text = "AL";
        sapka2btn.text = "AL";
        sapka3btn.text = "AL";
        sapka4btn.text = "AL";
        sapka5btn.text = "AL";
        sapka6btn.text = "AL";

        //bilgiler-kısmı-----
        firstname.text = "Gerçek isminizi giriniz...";
        lastname.text = "Gerçek soy isminizi giriniz...";
        mailadress.text = "Mail adresinizi giriniz...";
        telephone.text = "Telefon bumaranızı giriniz...";
        bos.text = "Lütfen boş alanları doldurun.";
        //---------------------
    }
    public void endili()
    //Ayarlar kısmında en butonuna basıldığında yapılacak işlemler..
    {
        dil.text = "en";
        isimgirin.text = "Write your name...";
        eniyiyapanlarisim.text = "Names";
        eniyiyapanlarpuan.text = "Points";
        jenerik.text = "Credits";
        surumyazi.text = "Version:";
        if (surumm == 1)
        {
            surumbilgisi.text = "Your version is correct.";
        }
        else
        {
            surumbilgisi.text = "You are not on the latest version.";
        }
        reklamuyariyazisi.text = "Click the plus button to play the game";

        //magaza
        kalkan.text = "SHIELD";
        parayetersiz.text = "You Are Poor";
        kalkanalindi.text = "Shield taken";
        kalkanalbtntext.text = "BUY";

        ilerisar.text = "+2000";
        ilerisarparayetersiz.text = "You Are Poor";
        ilerisaralindi.text = "Plus Point Taken";
        ilerisarbtntext.text = "BUY";

        dahafazlaparaicin.text = "More Money";

        sapka1btn.text = "BUY";
        sapka2btn.text = "BUY";
        sapka3btn.text = "BUY";
        sapka4btn.text = "BUY";
        sapka5btn.text = "BUY";
        sapka6btn.text = "BUY";

        //bilgiler-kısmı-----
        firstname.text = "Enter real firstname...";
        lastname.text = "Enter real lastname...";
        mailadress.text = "Enter mail adress...";
        telephone.text = "Enter telephone number...";
        bos.text = "Please fill in blank text";
        //---------------------
    }

    //ayarlar ve bilgi paneli btn işlemleri..
    public void ayarlar()
    {
        ayarlarpanel.SetActive(true);
    }
    public void bilgi()
    {
        bilgipanel.SetActive(true);
    }

    //sürüm kontrolünden sonra text için..
    public static void surumdogru()
    {
        surumm = 1;
    }


    //instagram yönlendirmesi..
    public void goinstagram()
    {
        Application.OpenURL(instagram);
    }
}
