using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesler : MonoBehaviour
{
    static bool incar = false;
    public GameObject deadpanel;

    public Light flashlightpower;
    public GameObject flashlight;
    static int flk = 1;
    public int flac = 0;
    public AudioSource fenerac;
    public AudioSource fenerkapa;
    public AudioClip fenera;
    public AudioClip fenerk;

    public float speed;
    public AudioSource tassesisi;
    public AudioSource cimensesi;
    public AudioSource fayans;
    public AudioSource yolsesi;
    public Rigidbody fizik;
    int i = 0, f;
    float fl = 2f;
    // Start is called before the first frame update
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        tassesisi.volume = 0;
        cimensesi.volume = 0;
        fayans.volume = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!incar)
        {
            speed = fizik.velocity.magnitude;
        }
        if (incar)
        {
            speed = 0;
            i = 4;
            tassesisi.volume = 0;
            cimensesi.volume = 0;
            fayans.volume = 0;
        }

        if(i == 0)
        {
            tassesisi.volume = speed / 100f;
            cimensesi.volume = 0;
            fayans.volume = 0;
            yolsesi.volume = 0;
        }

        if(i == 1)
        {
            tassesisi.volume = 0;
            cimensesi.volume = speed / 100f;
            fayans.volume = 0;
            yolsesi.volume = 0;
        }

        if (i == 2)
        {
            fayans.volume = speed / 100f;
            tassesisi.volume = 0;
            cimensesi.volume = 0;
            yolsesi.volume = 0;
        }

        if (i == 3)
        {
            yolsesi.volume = speed / 100f;
            fayans.volume = 0;
            tassesisi.volume = 0;
            cimensesi.volume = 0;

        }
        //flashlight-------------------------
        if (Input.GetKeyDown("f") && (f == 0) && (flk == 1))
        {
            f = 1;
            fenerac.PlayOneShot(fenera, 1F);
        }
        if(Input.GetKeyDown("g") && (f == 1) && (flk == 1))
        {
            f = 0;
            fenerkapa.PlayOneShot(fenerk, 1F);
            flashlightpower.intensity = Mathf.PingPong(Time.time, 0.1f);
            //flashlightpower.color -= (Color.white / 0f) * Time.deltaTime;
        }
        if((f == 1) && (flk == 1))
        {
            if(fl > 0)
            {
                fl = fl - 0.0001f;
            }
            flashlightpower.intensity = fl;
            //flashlightpower.color -= (Color.white / fl) * Time.deltaTime;
        }
        if (flk == 0)
        {
            if (fl < 2)
            {
                fl = fl + 0.001f;
            }
        }
        //------------------------------------

    }

    public static void areyouincar()
    {
        incar = true;
    }
    public static void notincar()
    {
        incar = false;
    }

    public static void flaslightontable(int flkon)
    {
        flk = flkon;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (speed > 35f)
        {
            //deadpanel.SetActive(true);
        }
        //cisim duvarlara çarptığında 
        if (collision.collider.name == "Terrain")
        {
            i = 1;
        }
        if (collision.collider.name == "fayans(boxcolliderses)")
        {
            i = 2;
        }

    }
    void OnTriggerEnter(Collider collision)
    {
        //cisim duvarlara çarptığında 
        if (collision.name == "Plane(boxcollider)")
        {
            i = 0;
        }
        if (collision.name == "yol(boxcollider)")
        {
            i = 3;
        }
    }

}
