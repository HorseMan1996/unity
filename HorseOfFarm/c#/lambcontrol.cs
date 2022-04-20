using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class lambcontrol : MonoBehaviour
{
    public AudioClip switchonsound;
    public AudioClip switchoffsound;

    public GameObject balconylamps1;
    public GameObject balconylamps2;
    public GameObject balconylamps3;
    public GameObject balconylamps4;
    public AudioSource balconyaudio;

    public GameObject kitchenlamps1;
    public GameObject kitchenlamps2;
    public GameObject kitchenlamps3;
    public AudioSource kitchenaudio;

    public GameObject bedroomlamps;
    public AudioSource bedroomaudio;

    public GameObject livingroomlamps1;
    public GameObject livingroomlamps2;
    public GameObject livingroomlamps3;
    public AudioSource livingroomaudio;

    public GameObject bathroomfrontlamps1;
    public GameObject bathroomfrontlamps2;
    public AudioSource bathroomaudio;

    public GameObject bedroom2lamps1;
    public GameObject bedroom2lamps2;
    public AudioSource bedroom2audio;

    public GameObject ardiyelamps1;
    public GameObject ardiyelamps2;
    public GameObject ardiyelamps3;
    public AudioSource ardiyeaudio;

    public GameObject kumeslamps1;
    public AudioSource kumesaudio;

    public Text energys;
    float use = 0;

    float a = 0f, b = 0f, c = 0f, d = 0f, f = 0f, g = 0f, e = 0f, j = 0f, sum = 0f;
    int i = 0;
    // Start is called before the first frame update
    /* void Start()
     {

     }*/

    // Update is called once per frame
      void FixedUpdate()
      {
        if(i == 1)
        {
            i = 0;
            sum = a + b + c + d + f + g + e + j;
        }

        if ((System.Convert.ToDouble(energys.text) <= 100f) && (System.Convert.ToDouble(energys.text) >= 0f))
        {
            energys.text = System.Convert.ToString(System.Convert.ToDouble(energys.text) - sum);
        }

        if (System.Convert.ToDouble(energys.text) < 0.001)
        {
            a = 0f;
            b = 0f;
            c = 0f;
            d = 0f;
            f = 0f;
            g = 0f;
            e = 0f;
            j = 0f;

            balconylamps1.SetActive(false);
            balconylamps2.SetActive(false);
            balconylamps3.SetActive(false);
            balconylamps4.SetActive(false);

            kitchenlamps1.SetActive(false);
            kitchenlamps2.SetActive(false);
            kitchenlamps3.SetActive(false);

            bedroomlamps.SetActive(false);

            livingroomlamps1.SetActive(false);
            livingroomlamps2.SetActive(false);
            livingroomlamps3.SetActive(false);

            bathroomfrontlamps1.SetActive(false);
            bathroomfrontlamps2.SetActive(false);

            bedroom2lamps1.SetActive(false);
            bedroom2lamps2.SetActive(false);

            ardiyelamps1.SetActive(false);
            ardiyelamps2.SetActive(false);
            ardiyelamps3.SetActive(false);

            kumeslamps1.SetActive(false);
        }

      }

    void OnTriggerStay(Collider collision)
    {
        if (System.Convert.ToDouble(energys.text) > 0)
        {
            if (collision.name == "balconylampswitch")
            {
                if (Input.GetKeyDown("e"))
                {
                    balconyaudio.PlayOneShot(switchonsound, 1F);
                    i = 1;
                    a = 0.001f;
                    balconylamps1.SetActive(true);
                    balconylamps2.SetActive(true);
                    balconylamps3.SetActive(true);
                    balconylamps4.SetActive(true);
                }

                if (Input.GetKeyDown("r"))
                {
                    balconyaudio.PlayOneShot(switchoffsound, 1F);
                    i = 1;
                    a = 0f;
                    balconylamps1.SetActive(false);
                    balconylamps2.SetActive(false);
                    balconylamps3.SetActive(false);
                    balconylamps4.SetActive(false);
                }
            }

            if (collision.name == "kitchenlampswitch")
            {
                if (Input.GetKeyDown("e"))
                {
                    kitchenaudio.PlayOneShot(switchonsound, 1F);
                    i = 1;
                    b = 0.001f;
                    kitchenlamps1.SetActive(true);
                    kitchenlamps2.SetActive(true);
                    kitchenlamps3.SetActive(true);
                }
                if (Input.GetKeyDown("r"))
                {
                    kitchenaudio.PlayOneShot(switchoffsound, 1F);
                    i = 1;
                    b = 0f;
                    kitchenlamps1.SetActive(false);
                    kitchenlamps2.SetActive(false);
                    kitchenlamps3.SetActive(false);
                }
            }

            if (collision.name == "bedroomlampswitch")
            {
                if (Input.GetKeyDown("e"))
                {
                    bedroomaudio.PlayOneShot(switchonsound, 1F);
                    i = 1;
                    c = 0.001f;
                    bedroomlamps.SetActive(true);
                }
                if (Input.GetKeyDown("r"))
                {
                    bedroomaudio.PlayOneShot(switchoffsound, 1F);
                    i = 1;
                    c = 0f;
                    bedroomlamps.SetActive(false);
                }
            }

            if (collision.name == "livingroomlampswitch")
            {
                if (Input.GetKeyDown("e"))
                {
                    livingroomaudio.PlayOneShot(switchonsound, 1F);
                    i = 1;
                    d = 0.001f;
                    livingroomlamps1.SetActive(true);
                    livingroomlamps2.SetActive(true);
                    livingroomlamps3.SetActive(true);
                }
                if (Input.GetKeyDown("r"))
                {
                    livingroomaudio.PlayOneShot(switchoffsound, 1F);
                    i = 1;
                    d = 0f;
                    livingroomlamps1.SetActive(false);
                    livingroomlamps2.SetActive(false);
                    livingroomlamps3.SetActive(false);
                }
            }

            if (collision.name == "bathroomfrontlampswitch")
            {
                if (Input.GetKeyDown("e"))
                {
                    bathroomaudio.PlayOneShot(switchonsound, 1F);
                    i = 1;
                    f = 0.001f;
                    bathroomfrontlamps1.SetActive(true);
                    bathroomfrontlamps2.SetActive(true);
                }
                if (Input.GetKeyDown("r"))
                {
                    bathroomaudio.PlayOneShot(switchoffsound, 1F);
                    i = 1;
                    f = 0f;
                    bathroomfrontlamps1.SetActive(false);
                    bathroomfrontlamps2.SetActive(false);
                }
            }

            if (collision.name == "bedroom2lampswitch")
            {
                if (Input.GetKeyDown("e"))
                {
                    bedroom2audio.PlayOneShot(switchonsound, 1F);
                    i = 1;
                    g = 0.001f;
                    bedroom2lamps1.SetActive(true);
                    bedroom2lamps2.SetActive(true);
                }
                if (Input.GetKeyDown("r"))
                {
                    bedroom2audio.PlayOneShot(switchoffsound, 1F);
                    i = 1;
                    g = 0f;
                    bedroom2lamps1.SetActive(false);
                    bedroom2lamps2.SetActive(false);
                }
            }

            if (collision.name == "ardiyelampswitch")
            {
                if (Input.GetKeyDown("e"))
                {
                    ardiyeaudio.PlayOneShot(switchonsound, 1F);
                    i = 1;
                    e = 0.001f;
                    ardiyelamps1.SetActive(true);
                    ardiyelamps2.SetActive(true);
                    ardiyelamps3.SetActive(true);
                }
                if (Input.GetKeyDown("r"))
                {
                    ardiyeaudio.PlayOneShot(switchoffsound, 1F);
                    i = 1;
                    e = 0f;
                    ardiyelamps1.SetActive(false);
                    ardiyelamps2.SetActive(false);
                    ardiyelamps3.SetActive(false);
                }
            }

            if (collision.name == "kumeslampswitch")
            {
                if (Input.GetKeyDown("e"))
                {
                    kumesaudio.PlayOneShot(switchonsound, 1F);
                    i = 1;
                    j = 0.001f;
                    kumeslamps1.SetActive(true);
                }
                if (Input.GetKeyDown("r"))
                {
                    kumesaudio.PlayOneShot(switchoffsound, 1F);
                    i = 1;
                    j = 0f;
                    kumeslamps1.SetActive(false);
                }
            }
        }
        
    }
    

}
