using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterprocess : MonoBehaviour
{
    static bool batterytake = false;
    static public float batteryadd;
    //menu
    [SerializeField] AudioSource menuclick;
    [SerializeField] AudioClip menuclicks;
    //-----
    //flaslight
    [SerializeField] AudioSource flashlightsound;
    [SerializeField] AudioClip flashlightsoundspoen;
    [SerializeField] AudioClip flashlightsoundsclose;
    [SerializeField] bool flash = true;
    [SerializeField] Text flaslight;
    [SerializeField] Slider flaslightenergy; 
    //---------

    bool yes = false;
    public GameObject surumpanel;
    public AudioSource breathing;
    public Light flashlightpower;
    public int f = 0;
    int t = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && flash)
        {
            flash = false;
            flashlightsound.PlayOneShot(flashlightsoundspoen,1f);
            flashlightpower.intensity = 0.0000001f;

        }
        else if (Input.GetKeyDown(KeyCode.F) && !flash)
        {
            flashlightsound.PlayOneShot(flashlightsoundsclose,1f);
            flash = true;
            StartCoroutine(ExampleCoroutine());
        }
        if (batterytake)
        {
            batterytake = false;
            flaslight.text = System.Convert.ToString(System.Convert.ToSingle(flaslight.text) + batteryadd);
            batteryadd = 0;
        }
        else if (flash && System.Convert.ToSingle(flaslight.text) > 5)
        {
            flaslight.text = System.Convert.ToString(System.Convert.ToSingle(flaslight.text) - 0.01);
            flaslightenergy.value = System.Convert.ToSingle(flaslight.text);
        }
        /* if (Input.GetKeyUp("f"))
         {
             StartCoroutine(ExampleCoroutine());
             f = 1;

         }
         if (Input.GetKeyUp("r"))
         {
             f = 0;
             flashlightpower.intensity = 0.0001f;
         }*/
        if (Input.GetKeyDown(KeyCode.Escape) && !yes)
        {
            yes = true;
            menuclick.PlayOneShot(menuclicks,1f);
            surumpanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && yes)
        {
            yes = false;
            menuclick.PlayOneShot(menuclicks, 1f);
            surumpanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
        /*if (Input.GetKey(KeyCode.C))
        {
           t = 1;
           flashlightpower.intensity = 2f;
        }
        if (!Input.GetKey(KeyCode.C))
        {
            StartCoroutine(ExampleCoroutine());
            t = 0;
        }*/
    }

    IEnumerator ExampleCoroutine()
    {
        if (flash)
        {
            flashlightpower.intensity = System.Convert.ToSingle(System.Convert.ToSingle(flaslight.text)/100);
            //yield return new WaitForSeconds(System.Convert.ToSingle(flaslight.text));
            yield return new WaitForSecondsRealtime(Random.Range(1f,3f));
            flashlightpower.intensity = System.Convert.ToSingle(System.Convert.ToSingle(flaslight.text) / 200); ;
            yield return new WaitForSeconds(0.2f);
        }
        if(t == 0)
        {
            StartCoroutine(ExampleCoroutine());
        }
    }
       
    public static void batteryaddwhich(float a)
    {
        batterytake = true;
        batteryadd = a;
    }
}
