using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class Clock : MonoBehaviour {
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Simple Clock Script / Andre "AEG" Bürger / VIS-Games 2012
    //
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------------------------------------
    //

    //güneş
    public Light sun;


    int i, a= 0;

    float gelensaat;
    float turnsky = 0;
    //
    //-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;
    
    //-- time speed factor
    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //carsetting
    public GameObject sellingcarss;
    public GameObject selercarpoint;
    public int createcar;

    //eggsettings
    public Text characterhavechicken;
    public Text characterhaveegg;

    //sleeping setting
    public Animator sleepinganimation;
    public Slider charactersleepslider;
    public Slider charactertired;

    //outdoortemperature
    public Text outhdoortemperature;


    //-- internal vars
    int seconds;
    float msecs;
    GameObject pointerSeconds;
    GameObject pointerMinutes;
    GameObject pointerHours;
    //----------------------------------------------------------------------------------
    float isik = 0;

//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
void Start() 
{
    pointerSeconds = transform.Find("rotation_axis_pointer_seconds").gameObject;
    pointerMinutes = transform.Find("rotation_axis_pointer_minutes").gameObject;
    pointerHours   = transform.Find("rotation_axis_pointer_hour").gameObject;

    msecs = 0.0f;
    seconds = 0;

        createcar = Random.Range(9, 12);

}
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
void Update() 
{
    //-- calculate time
    msecs += Time.deltaTime * clockSpeed;
    if(msecs >= 1.0f)
    {
        msecs -= 1.0f;
        seconds++;
        if(seconds >= 60)
        {
            seconds = 0;
            minutes++;
            if(minutes > 60)
            {
                minutes = 0;
                hour++;
                if(hour >= 24)
                    hour = 0;
            }
        }
    }

        watercontrolcode.thesunstart(sun.intensity);

        if((hour == 19f) && (minutes == 30) && (seconds == 30))
        {
            outhdoortemperature.text = System.Convert.ToString(Random.Range(10, 17));
        }
        if (((hour == 7f) || (hour == 8f) || (hour == 9f) || (hour == 10f) || (hour == 11f) || (hour == 12f) || (hour == 13f) || (hour == 14f) || (hour == 15f) || (hour == 16f)) && (minutes == 30) && (seconds == 30))
        {
            outhdoortemperature.text = System.Convert.ToString(Random.Range(14, 22));
        }

        //hava aydınlığı------
        if ((hour >= 0f) && (hour <= 5f))
        {
           // sun.intensity = 0f;
            RenderSettings.skybox.SetFloat("_Exposure", 0.2f);
        }
        if ((hour == 5f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.08f;
            RenderSettings.skybox.SetFloat("_Exposure", 0.6f);
        }

        if ((hour == 6f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.16f;
            RenderSettings.skybox.SetFloat("_Exposure", 1.2f);
        }

        if ((hour == 7f) && (minutes == 10f) && (seconds == 10f))
        {
          // sun.intensity = 0.24f;
            RenderSettings.skybox.SetFloat("_Exposure", 1.8f);
        }
        if ((hour == 8f) && (minutes == 10f) && (seconds == 10f))
        {
          //  sun.intensity = 0.32f;
            RenderSettings.skybox.SetFloat("_Exposure", 2.4f);
        }
        if ((hour == 9f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.40f;
            RenderSettings.skybox.SetFloat("_Exposure", 3f);
        }
        if ((hour == 10f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.48f;
            RenderSettings.skybox.SetFloat("_Exposure", 3.6f);
        }
        if ((hour == 11f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.56f;
            RenderSettings.skybox.SetFloat("_Exposure", 4.2f);
        }
        if ((hour == 12f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.64f;
            RenderSettings.skybox.SetFloat("_Exposure", 4.8f);
        }
        if ((hour == 12f) && (minutes == 10f) && (seconds == 10f))
        {
          //  sun.intensity = 0.72f;
            RenderSettings.skybox.SetFloat("_Exposure", 5.4f);
        }
        if ((hour == 13f) && (minutes == 10f) && (seconds == 10f))
        {
          //  sun.intensity = 0.80f;
            RenderSettings.skybox.SetFloat("_Exposure", 6f);
        }
        if ((hour == 14f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.88f;
            RenderSettings.skybox.SetFloat("_Exposure", 6.6f);
        }
        if ((hour == 15f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 1f;
            RenderSettings.skybox.SetFloat("_Exposure", 7.2f);
        }
        if ((hour == 16f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.88f;
            RenderSettings.skybox.SetFloat("_Exposure", 6.6f);
        }
        if ((hour == 17f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.72f;
            RenderSettings.skybox.SetFloat("_Exposure", 6f);
        }
        if ((hour == 18f) && (minutes == 10f) && (seconds == 10f))
        {
          //  sun.intensity = 0.64f;
            RenderSettings.skybox.SetFloat("_Exposure", 5.2f);
        }
        if ((hour == 19f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.50f;
            RenderSettings.skybox.SetFloat("_Exposure", 4f);
        }
        if ((hour == 20f) && (minutes == 10f) && (seconds == 10f))
        {
         //   sun.intensity = 0.4f;
            RenderSettings.skybox.SetFloat("_Exposure", 3f);
        }
        if ((hour == 21f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.2f;
            RenderSettings.skybox.SetFloat("_Exposure", 2f);
        }
        if ((hour == 22f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.1f;
            RenderSettings.skybox.SetFloat("_Exposure", 1f);
        }
        if ((hour == 23f) && (minutes == 10f) && (seconds == 10f))
        {
           // sun.intensity = 0.05f;
            RenderSettings.skybox.SetFloat("_Exposure", 0.5f);
        }
        turnsky = turnsky + 0.001f;
        RenderSettings.skybox.SetFloat("_Rotation", turnsky);
        //---------------------------



        if (Input.GetKeyDown("space"))
        {
            gelensaat = karakterislemleri.sleepingsend();


            if ((((hour >= 21) && (hour <= 24)) || ((hour >= 0) && (hour < 7))) && (gelensaat == 1))
            {
                Debug.Log(gelensaat);
                a = 1;
                sleepinganimation.SetBool("uyu", true);
                charactertired.value = 100f;
                hour = 8;
                minutes = 8;
            }

            /*if (gelensaat != 0)
            {
                Debug.Log(hour);
                if ((hour >= 21) && (hour <= 24))
                {
                    a = 1;
                    sleepinganimation.SetBool("uyu", true);

                    charactersleepslider.value = charactersleepslider.value + gelensaat * 10;
                    hour = (hour + System.Convert.ToInt32(gelensaat));
                    if (hour > 24)
                    {
                        hour = hour - 24;
                    }

                }
                if ((hour >= 0) && (hour < 7))
                {
                    charactersleepslider.value = charactersleepslider.value + gelensaat * 10;
                    a = 1;
                    sleepinganimation.SetBool("uyu", true);
                    hour = hour + karakterislemleri.sleepingsend();
                }
                else
                {
                    Debug.Log("saat gündüz.");
                }
            }*/
        }   

        if (a > 0)
        {
            a++;
            if (a == 50)
            {
                a = 0;
                sleepinganimation.SetBool("uyu", false);
            }

        }

        if((hour == createcar) && (minutes == createcar) && (seconds == createcar))
        {
            createcar = Random.Range(9, 12);
            sellingcarss.transform.position = new Vector3(selercarpoint.transform.position.x, selercarpoint.transform.position.y, selercarpoint.transform.position.z);
            chickenmove.clockcreateegg();
            //characterhaveegg.text = System.Convert.ToString(System.Convert.ToInt32(characterhaveegg.text) + Random.Range(1, System.Convert.ToInt32(characterhavechicken.text)));
        }

        //-- calculate pointer angles
    float rotationSeconds = (360.0f / 60.0f)  * seconds;
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

    //-- draw pointers
    pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
    pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);
    }

    public int sleeping(int saat)
    {
        i = 1;
        return saat;
    }
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
}
