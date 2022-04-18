using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saglik : MonoBehaviour
{
    public GameObject bandage;
    public int saglikolusturr = 0, deger = 3000, bandagekaydir = 0;
    float bandagex, bandagey, rastgele;
    // Start is called before the first frame update
    void Start()
    {
        deger = Random.Range(1000, 3000);
        rastgele = Random.Range(-1.24f, 1.2f);
        bandagex = this.transform.position.x;
        bandagey = this.transform.position.y;
    }

    //random aralıklarla bandaj oluşumu ve hareketi.
    void Update()
    {
        saglikolusturr++;
        if (saglikolusturr == deger)
        {
            bandage.SetActive(true);
            rastgele = Random.Range(0f, 3.5f);
            bandagekaydir = 1;
            deger = deger + Random.Range(1000, 3000);
        }
        if(bandagekaydir >= 1)
        {
            bandagekaydir++;
            this.transform.position = this.transform.position - new Vector3(0.1f, 0f, 0f);
            if(bandagekaydir == 300)
            {
                this.transform.position = new Vector3(bandagex, rastgele, 0f);
                bandagekaydir = 0;
            }
        }
    }

    //karakter bandajla temas ettiğinde yapılacak işlem.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        bandage.SetActive(false);
        ziplamakod.sagliktemas();
    }
}
