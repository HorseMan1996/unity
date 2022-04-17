using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class karakterislemleri : MonoBehaviour
{

    public AudioClip esccapes;
    public AudioSource esccapess;

    public GameObject seedpanel;

    public GameObject sleeppanel;
    public Slider sleepsliders;
    static int sleep = 0;
    static int sliderdeger = 0;
    static int i = 0;

    int inorout;
    public Text havemoneycharacter;

    public Text havewood;
    public Text characterinchill;
    public Text characteroutchill;
    public Slider healtvalue;

    public GameObject fridgepanel;
    public GameObject nestpanel;
    public GameObject mainwaterpanel;
    public GameObject animalwaterpanel;
    public GameObject energypanel;
    public Text energycontrol;
    public GameObject charactertrigerpanel;
    public GameObject treecutterpanel;
    public GameObject warehousepanel;
    public GameObject stovepanel;
    public GameObject flaslightsarjpanel;

    public GameObject solarupgradepanel;
    public GameObject solarupgradebtn;

    public GameObject tableflashlight;
    public GameObject manflashlight;

    public GameObject menucamera;
    public GameObject menupanel;

    public static bool gamepaused = false;
    // Start is called before the first frame update
     /* void Start()
      {
          Cursor.visible = true;
          Cursor.lockState = CursorLockMode.None;
    }*/

      // Update is called once per frame
    void FixedUpdate()
    {
        if(inorout == 1)
        {
             if (System.Convert.ToSingle(characterinchill.text) < 14f)
             {
                  healtvalue.value = healtvalue.value - 0.001f;
             }
        }
        if (inorout == 0)
        {
            if (System.Convert.ToSingle(characteroutchill.text) < 14f)
            {
                healtvalue.value = healtvalue.value - 0.001f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamepaused)
            {

                resume();
            }
            else
            {

                pause();
            }
        }
    }

    public void resume()
    {
        esccapess.PlayOneShot(esccapes, 1f);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menucamera.SetActive(false);
        menupanel.SetActive(false);
        gamepaused = false;
    }
    void pause()
    {
        esccapess.PlayOneShot(esccapes, 1f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        menucamera.SetActive(true);
        menupanel.SetActive(true);
        gamepaused = true;
    }

    void OnTriggerStay(Collider collision)
    {
       /* if (collision.name == "yatak")
        {
            if (Input.GetKeyDown("e"))
            {
                sleepsliders.value++;
                sliderdeger = System.Convert.ToInt32(sleepsliders.value);
            }
            if (Input.GetKeyDown("q"))
            {
                sleepsliders.value--;
                sliderdeger = System.Convert.ToInt32(sleepsliders.value);
            }
        }*/
        if (collision.name == "sarjistation")
        {
            if (Input.GetKeyDown("r"))
            {
                sesler.flaslightontable(0);
                tableflashlight.SetActive(true);
                manflashlight.SetActive(false);
            }
            if (Input.GetKeyDown("e"))
            {
                sesler.flaslightontable(1);
                tableflashlight.SetActive(false);
                manflashlight.SetActive(true);
            }
        }
    }



    void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "farmplane")
        {
            seedpanel.SetActive(true);
        }
        if (collision.name == "seedcabin")
        {
            seedpanel.SetActive(true);
        }
        if (collision.name == "sarjistation")
        {
            flaslightsarjpanel.SetActive(true);
        }

        if (collision.name == "fayans(boxcolliderses)")
        {
            inorout = 1;
        }

        if (collision.name == "stove")
        {
            stovepanel.SetActive(true);
        }
        if (collision.name == "FireWood")
        {
            warehousepanel.SetActive(true);
        }
       /* if (collision.name == "tree" || collision.name == "tree(Clone)")
        {
            treecutterpanel.SetActive(true);
        }*/
        if (collision.name == "SolarPanel")
        {
            Cursor.visible = true;
            if (System.Convert.ToInt32(havemoneycharacter.text) < 2000)
            {
                solarupgradebtn.SetActive(false);
            }
            if (System.Convert.ToInt32(havemoneycharacter.text) >= 2000)
            {
                solarupgradebtn.SetActive(true);
            }
            solarupgradepanel.SetActive(true);
        }

        if (collision.name == "indoorcenterright" || collision.name == "ardiyelampswitch" || collision.name == "balconylampswitch" || collision.name == "bathroomfrontlampswitch" || collision.name == "bedroom2lampswitch" || collision.name == "bedroomlampswitch" || collision.name == "kitchenlampswitch" || collision.name == "kumeslampswitch" || collision.name == "livingroomlampswitch" || collision.name == "coopdoor" || collision.name == "energyroomdoor" || collision.name == "entrydoor1" || collision.name == "indoorcenter" || collision.name == "indoorcenterleft" || collision.name == "indoorleft" || collision.name == "indoorright" || collision.name == "outdoor" || collision.name == "toilet1door" || collision.name == "toilet2door" || collision.name == "warehousedoor" || collision.name == "warehousedoor (1)")
        {
            charactertrigerpanel.SetActive(true);
        }

        if (collision.name == "energy")
        {
            energypanel.SetActive(true);
        }

        if (collision.name == "yatak")
        {
            sleep = 1;
            sleeppanel.SetActive(true);
        }

        if (collision.name == "mainwatertank")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mainwaterpanel.SetActive(true);
        }

        if (collision.name == "animalwatertank")
        {
            animalwaterpanel.SetActive(true);
        }

        if (collision.name == "FridgeSBS")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fridgepanel.SetActive(true);
        }

        /*if (collision.name == "mentese")
        {
            Cursor.visible = true;
            nestpanel.SetActive(true);
        }*/
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.name == "farmplane")
        {
            seedpanel.SetActive(false);
        }
        if (collision.name == "seedcabin")
        {
            seedpanel.SetActive(false);
        }
        if (collision.name == "sarjistation")
        {
            flaslightsarjpanel.SetActive(false);
        }
        if (collision.name == "fayans(boxcolliderses)")
        {
            inorout = 0;
        }
        if (collision.name == "stove")
        {
            stovepanel.SetActive(false);
        }
        if (collision.name == "FireWood")
        {
            warehousepanel.SetActive(false);
        }
        /*if (collision.name == "tree" || collision.name == "tree(Clone)")
        {
            treecutterpanel.SetActive(false);
        }*/
        if (collision.name == "SolarPanel")
        {
            Cursor.visible = false;
            solarupgradepanel.SetActive(false);
        }

        if (collision.name == "indoorcenterright" || collision.name == "ardiyelampswitch" || collision.name == "balconylampswitch" || collision.name == "bathroomfrontlampswitch" || collision.name == "bedroom2lampswitch" || collision.name == "bedroomlampswitch" || collision.name == "kitchenlampswitch" || collision.name == "kumeslampswitch" || collision.name == "livingroomlampswitch" || collision.name == "coopdoor" || collision.name == "energyroomdoor" || collision.name == "entrydoor1" || collision.name == "indoorcenter" || collision.name == "indoorcenterleft" || collision.name == "indoorleft" || collision.name == "indoorright" || collision.name == "outdoor" || collision.name == "toilet1door" || collision.name == "toilet2door" || collision.name == "warehousedoor" || collision.name == "warehousedoor (1)")
        {
            charactertrigerpanel.SetActive(false);
        }

        if (collision.name == "energy")
        {
            energypanel.SetActive(false);
        }

        if (collision.name == "yatak")
        {
            sleep = 0;
            sleeppanel.SetActive(false);
        }

        if (collision.name == "mainwatertank")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mainwaterpanel.SetActive(false);
        }

        if (collision.name == "animalwatertank")
        {
            animalwaterpanel.SetActive(false);
        }

        if (collision.name == "FridgeSBS")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            fridgepanel.SetActive(false);
        }

        /*if (collision.name == "mentese")
        {
            Cursor.visible = false;
            nestpanel.SetActive(false);
        }*/
    }

    public static int sleepingsend()
    {
        return sleep;
    }
}
