using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class besincibolumtus : MonoBehaviour
{
    public GameObject cisimler, gerisaiym5a;
    public Text gerisayim5;
    int i = 0;
    // Update is called once per frame
    void Update()
    {
        if (i == 300)
        {
            gerisaiym5a.SetActive(true);
            cisimler.SetActive(true);
        }
        if (i <= 300 && i > 0)
        {
            gerisayim5.text = System.Convert.ToString(i);
            i--;
        }
        if (i == 0)
        {
            cisimler.SetActive(false);
            gerisaiym5a.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        i = 300;
    }
}
