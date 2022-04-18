using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dorduncubolumtus : MonoBehaviour
{
    public GameObject dorduncubolumkapi1;
    public GameObject dorduncubolumkapi2;
    public GameObject dorduncubolumkapi3;
    int i = 0;
    void OnCollisionEnter(Collision collision)
    {
        if(i == 0)
        {
            i = 1;
            dorduncubolumkapi1.SetActive(false);
            dorduncubolumkapi2.SetActive(true);
            dorduncubolumkapi3.SetActive(true);
        }

        if(i == 2)
        {
            i = 3;
            dorduncubolumkapi1.SetActive(true);
            dorduncubolumkapi2.SetActive(false);
            dorduncubolumkapi3.SetActive(true);
        }

        if(i == 4)
        {
            i = 5;
            dorduncubolumkapi1.SetActive(true);
            dorduncubolumkapi2.SetActive(true);
            dorduncubolumkapi3.SetActive(false);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(i == 1)
        {
            i = 2;
        }
        if (i == 3)
        {
            i = 4;
        }
        if(i == 5)
        {
            i = 0;
        }
    }
}
