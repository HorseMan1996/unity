using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ucuncubolumtus : MonoBehaviour
{
    public GameObject gerisayimtext;
    public GameObject ucuncubolumkapi;
    float konumz;
    public Text gerisayim;
    int i = 0;
    void Update()
    {
        if(i == 650)
        {
            gerisayimtext.SetActive(true);
            ucuncubolumkapi.SetActive(false);
        }
        if(i <= 650 && i > 0)
        {
            gerisayim.text = System.Convert.ToString(i);
            i--;
        }
        if(i == 0)
        {
            ucuncubolumkapi.SetActive(true);
            gerisayimtext.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        i = 650;
    }
}
