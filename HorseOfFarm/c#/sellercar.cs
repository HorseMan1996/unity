using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellercar : MonoBehaviour
{
    public GameObject sellercars;
    public float speed = 0.5f;
    public float speedsound = 0.5f;
    float wheelrotation = 3f;
    public float speed2;
    float hiz = 1.3f;
    public GameObject wheel1;
    public GameObject wheel2;
    public GameObject wheel3;
    public GameObject wheel4;
    public GameObject sellercarstoppoint;
    public Rigidbody fizikcar;
    int i = 0, a = 0;
    public AudioSource carsounds;
    public AudioSource carhorn;

    float x, y, z;
    // Start is called before the first frame update
  /* void Start()
    {

    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        /* if(i == 0)
         {

             /*Vector3 Nesneninyenipozisyonu = new Vector3(0f, 0f, 10f);

             //karaktere eklenecek güç
             fizikcar.AddForce(Nesneninyenipozisyonu * hiz);

             sellercars.transform.position = sellercars.transform.position + new Vector3(0f, 0f, 0.1f);

             speed = fizikcar.velocity.magnitude;
         speed2 = fizikcar.velocity.magnitude;
         }
         if (i == 1)
         {
             sellercars.transform.position = new Vector3(x, y, z);
         }*/
        if(i == 0)
        {
            sellercars.transform.position = sellercars.transform.position + new Vector3(0f, 0f, 0.1f);
            carsounds.volume = speedsound;

            wheel1.transform.Rotate(wheelrotation, 0f, 0f, Space.Self);
            wheel2.transform.Rotate(wheelrotation, 0f, 0f, Space.Self);
            wheel3.transform.Rotate(-wheelrotation, 0f, 0f, Space.Self);
            wheel4.transform.Rotate(-wheelrotation, 0f, 0f, Space.Self);
        }
        if(i == 1)
        {
            a++;
            sellercars.transform.position = new Vector3(x, y, z);
            if(a == 4000)
            {
                carhorn.Stop();
                i = 0;
                a = 0;
            }
        }


    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "sellercarstop")
        {
            carhorn.Play();
            x = sellercars.transform.position.x;
            y = sellercars.transform.position.y;
            z = sellercars.transform.position.z;
            i = 1;
            a = 0;
            speed = 0;
            sellercarstoppoint.SetActive(false);
        }
        if (collision.name == "sellercarstopcreate")
        {
            sellercarstoppoint.SetActive(true);
        }

        if (collision.name == "FirstPersonController")
        {
            carhorn.Stop();
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.name == "FirstPersonController")
        {
            i = 0;
            
        }
    }

    public void devamet()
    {
        i = 0;
    }
}
