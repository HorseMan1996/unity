using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class watercontrolcode : MonoBehaviour
{

    public GameObject kumeswater;

    static int a = 0;
    static float sunpanel = 0f;
    int i = 0;
    public Text mainwatercontroll;
    public Text animalwatercontroll;
    public Text energyset;
    public Text havesolarpanelstation;

    public Text stovewood2;
    public AudioSource stovesounds2;

    public Text animaltankfullness;
    public Text chickencounts;

    public AudioSource waterpumpsound;
    public AudioSource waterpipesound1;
    public AudioSource waterpipesound2;
    public AudioSource waterpipesound3;
    public AudioSource waterpipesound4;
    public AudioSource waterpipesound5;
    public AudioSource waterpipesound6;
    public AudioSource waterpipesound7;
    public AudioSource waterpipesound8;
    public AudioSource waterpipesound9;
    public AudioSource waterpipesound10;
    static float sunpanelupgrade = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (System.Convert.ToDouble(mainwatercontroll.text) < 100)
        {
            mainwatercontroll.text = System.Convert.ToString(System.Convert.ToDouble(mainwatercontroll.text) + 0.0001f);
        }

        if(System.Convert.ToSingle(energyset.text) > 0f)
        {
            if (i == 1 && System.Convert.ToDouble(mainwatercontroll.text) > 0 && (System.Convert.ToDouble(animalwatercontroll.text) >= 0) && (System.Convert.ToDouble(animalwatercontroll.text) <= 100))
            {
                energyset.text = System.Convert.ToString(System.Convert.ToSingle(energyset.text) - 0.001f);
                mainwatercontroll.text = System.Convert.ToString(System.Convert.ToDouble(mainwatercontroll.text) - 0.001f);
                animalwatercontroll.text = System.Convert.ToString(System.Convert.ToDouble(animalwatercontroll.text) + 0.002f);
            }
        }


        if((System.Convert.ToDouble(energyset.text) <= 100) && (System.Convert.ToDouble(energyset.text) >= 0))
        {
            energyset.text = System.Convert.ToString(System.Convert.ToDouble(energyset.text) + sunpanel);
        }

        if (System.Convert.ToDouble(animaltankfullness.text) > 0)
        {

            animaltankfullness.text = System.Convert.ToString(System.Convert.ToDouble(animaltankfullness.text) - (System.Convert.ToDouble(chickencounts.text) / 1000));
        }
        if (System.Convert.ToDouble(animaltankfullness.text) < 0.01f)
        {
            kumeswater.SetActive(false);
        }
        if (System.Convert.ToDouble(animaltankfullness.text) > 0.01f)
        {
            kumeswater.SetActive(true);
        }
        //stove code
        if (System.Convert.ToDouble(stovewood2.text) > 0)
        {
            stovewood2.text = System.Convert.ToString(System.Convert.ToDouble(stovewood2.text) - 0.0001f);
        }
        if (System.Convert.ToDouble(stovewood2.text) <= 0)
        {
            stovewood2.text = "0";
            stovesounds2.Stop();
        }
        //---------
    }

    //Güneş paneli upgrade------
    public static void thesunstart(float sunpanelenergy)
    {
        if(sunpanelenergy >= 0.4f)
        {
            sunpanel = (sunpanelenergy / 100f) * sunpanelupgrade;
        }
        else
        {
            sunpanel = 0f;
        }
    }
    //--------------------------

    public void sendwater()
    {
        waterpumpsound.Play();
        waterpipesound1.Play();
        waterpipesound2.Play();
        waterpipesound3.Play();
        waterpipesound4.Play();
        waterpipesound5.Play();
        waterpipesound6.Play();
        waterpipesound7.Play();
        waterpipesound8.Play();
        waterpipesound9.Play();
        waterpipesound10.Play();
        i = 1;
    }
    public void stopwater()
    {
        waterpumpsound.Stop();
        waterpipesound1.Stop();
        waterpipesound2.Stop();
        waterpipesound3.Stop();
        waterpipesound4.Stop();
        waterpipesound5.Stop();
        waterpipesound6.Stop();
        waterpipesound7.Stop();
        waterpipesound8.Stop();
        waterpipesound9.Stop();
        waterpipesound10.Stop();
        i = 0;
    }

    public void upgradesunpanel()
    {
        sunpanelupgrade = sunpanelupgrade + 0.1f;
        havesolarpanelstation.text = System.Convert.ToString(sunpanelupgrade);
    }
}
