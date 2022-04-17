using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class parakodu : MonoBehaviour
{
    public Text paramiktari;

    public Text kalkanfiyat;
    public GameObject kalkanyetersizbakiye;
    public GameObject kalkanalindimi;
    public GameObject kalkanalindimibtn;
    public Text kalkanvar;

    public Text ilerisarfiyat;
    public GameObject ilerisaryetersizbakiye;
    public GameObject ilerisaralindimi;
    public GameObject ilerisaralindimibtn;
    public Text ilerisarvar;

    static int paraekle = 0, sapkalarindurumu = 0;
    public int parayiekle = 0;
    int para,ilkpara,ilksapka;


    //sapkalar--------------------------------------
    public GameObject sapka1;
    public GameObject sapka2;
    public GameObject sapka3;
    public GameObject sapka4;
    public GameObject sapka5;
    public GameObject sapka6;
    public Text sapkahangi;
    //----------------------------------------------
    
    // Start is called before the first frame update
    void Start()
    {
        ilkpara = ziplamakod.parayukle();
        paramiktari.text = System.Convert.ToString(ilkpara);

        if(ziplamakod.malzemeyukle() == 1)
        {
            kalkanvar.text = "kalkanvar";
        }
        if (ziplamakod.malzemeyukle() == 0)
        {
            kalkanvar.text = "kalkanyok";
        }

        if(ziplamakod.ilerisaryukle() == 1)
        {
            ilerisarvar.text = "ilerisarvar";
        }
        if (ziplamakod.ilerisaryukle() == 0)
        {
            kalkanvar.text = "ilerisaryok";
        }

        sapkahangi.text = System.Convert.ToString(ziplamakod.sapkayukle());
    }

    // Update is called once per frame
    void Update()
    {
        if (System.Convert.ToInt32(paramiktari.text) < 10)
        {
            kalkanalindimi.SetActive(false);
            kalkanalindimibtn.SetActive(false);
            kalkanyetersizbakiye.SetActive(true);


        }

        if (System.Convert.ToInt32(paramiktari.text) < 15)
        {
            ilerisaralindimi.SetActive(false);
            ilerisaralindimibtn.SetActive(false);
            ilerisaryetersizbakiye.SetActive(true);
        }

        if ((System.Convert.ToInt32(paramiktari.text) >= 10) && (kalkanvar.text == "kalkanyok"))
        {
            kalkanalindimi.SetActive(false);
            kalkanalindimibtn.SetActive(true);
            kalkanyetersizbakiye.SetActive(false);
        }

        if ((System.Convert.ToInt32(paramiktari.text) >= 15) && (ilerisarvar.text == "ilerisaryok"))
        {
            ilerisaralindimi.SetActive(false);
            ilerisaralindimibtn.SetActive(true);
            ilerisaryetersizbakiye.SetActive(false);
        }

        if ((System.Convert.ToInt32(paramiktari.text) >= 10) && (kalkanvar.text == "kalkanvar"))
        {
            kalkanalindimi.SetActive(true);
            kalkanalindimibtn.SetActive(false);
            kalkanyetersizbakiye.SetActive(false);

        }

        if ((System.Convert.ToInt32(paramiktari.text) >= 15) && (ilerisarvar.text == "ilerisarvar"))
        {
            ilerisaralindimi.SetActive(true);
            ilerisaralindimibtn.SetActive(false);
            ilerisaryetersizbakiye.SetActive(false);
        }

        if (paraekle > 0)
        {
            parayiekle = paraekle;
            Debug.Log(parayiekle);
            paraekle = 0;
            parayiekle = System.Convert.ToInt32(paramiktari.text) + parayiekle;
            paramiktari.text = System.Convert.ToString(parayiekle);
            parayiekle = 0;
        }


        //şapkabutonları-----------------------------------

        if((System.Convert.ToInt32(paramiktari.text) <= 0))
        {
            sapka1.SetActive(false);
            sapka2.SetActive(false);
            sapka3.SetActive(false);
            sapka4.SetActive(false);
            sapka5.SetActive(false);
            sapka6.SetActive(false);
        }

        if(sapkalarindurumu == 1)
        {
            sapkalarindurumu = 0;
            sapka1.SetActive(true);
            sapka2.SetActive(true);
            sapka3.SetActive(true);
            sapka4.SetActive(true);
            sapka5.SetActive(true);
            sapka6.SetActive(true);
        }
        //-------------------------------------------------
    }

    public void kalkanalindi()
    {
        para = System.Convert.ToInt32(paramiktari.text) - System.Convert.ToInt32(kalkanfiyat.text);
        paramiktari.text = System.Convert.ToString(para);
        kalkanvar.text = "kalkanvar";
        kalkanalindimi.SetActive(true);
        kalkanalindimibtn.SetActive(false);
        kalkanyetersizbakiye.SetActive(false);
        ziplamakod.parakayit(System.Convert.ToInt32(paramiktari.text));
        ziplamakod.malzemekayit(1);
    } 

    public void ilerisaralindi()
    {
        para = System.Convert.ToInt32(paramiktari.text) - System.Convert.ToInt32(ilerisarfiyat.text);
        paramiktari.text = System.Convert.ToString(para);
        ilerisarvar.text = "ilerisarvar";
        ilerisaralindimi.SetActive(true);
        ilerisaralindimibtn.SetActive(false);
        ilerisaryetersizbakiye.SetActive(false);
        ziplamakod.parakayit(System.Convert.ToInt32(paramiktari.text));
        ziplamakod.ilerisarkayit(1);
    }

    public static void kazanilanpara(int gelenpara)
    {
        paraekle = gelenpara / 2000;
        ziplamakod.parakayit(System.Convert.ToInt32(paraekle));
    }

    //sapkalar-----------------------------------------------------------------------
    public void sapka11()
    {
        ziplamakod.sapkakayit(1);
        sapkahangi.text = "1";
        para = System.Convert.ToInt32(paramiktari.text) - 1;
        paramiktari.text = System.Convert.ToString(para);
        sapka1.SetActive(false);
        sapka2.SetActive(true);
        sapka3.SetActive(true);
        sapka4.SetActive(true);
        sapka5.SetActive(true);
        sapka6.SetActive(true);
    }
    public void sapka22()
    {
        ziplamakod.sapkakayit(2);
        sapkahangi.text = "2";
        para = System.Convert.ToInt32(paramiktari.text) - 1;
        paramiktari.text = System.Convert.ToString(para);
        sapka1.SetActive(true);
        sapka2.SetActive(false);
        sapka3.SetActive(true);
        sapka4.SetActive(true);
        sapka5.SetActive(true);
        sapka6.SetActive(true);
    }
    public void sapka33()
    {
        ziplamakod.sapkakayit(3);
        sapkahangi.text = "3";
        para = System.Convert.ToInt32(paramiktari.text) - 1;
        paramiktari.text = System.Convert.ToString(para);
        sapka1.SetActive(true);
        sapka2.SetActive(true);
        sapka3.SetActive(false);
        sapka4.SetActive(true);
        sapka5.SetActive(true);
        sapka6.SetActive(true);
    }
    public void sapka44()
    {
        ziplamakod.sapkakayit(4);
        sapkahangi.text = "4";
        para = System.Convert.ToInt32(paramiktari.text) - 1;
        paramiktari.text = System.Convert.ToString(para);
        sapka1.SetActive(true);
        sapka2.SetActive(true);
        sapka3.SetActive(true);
        sapka4.SetActive(false);
        sapka5.SetActive(true);
        sapka6.SetActive(true);
    }
    public void sapka55()
    {
        ziplamakod.sapkakayit(5);
        sapkahangi.text = "5";
        para = System.Convert.ToInt32(paramiktari.text) - 1;
        paramiktari.text = System.Convert.ToString(para);
        sapka1.SetActive(true);
        sapka2.SetActive(true);
        sapka3.SetActive(true);
        sapka4.SetActive(true);
        sapka5.SetActive(false);
        sapka6.SetActive(true);
    }
    public void sapka66()
    {
        ziplamakod.sapkakayit(6);
        sapkahangi.text = "6";
        para = System.Convert.ToInt32(paramiktari.text) - 1;
        paramiktari.text = System.Convert.ToString(para);
        sapka1.SetActive(true);
        sapka2.SetActive(true);
        sapka3.SetActive(true);
        sapka4.SetActive(true);
        sapka5.SetActive(true);
        sapka6.SetActive(false);
    }

    public static void sapkalariac()
    {
        sapkalarindurumu = 1;
    }
    //-----------------------------------------------------------------
}
