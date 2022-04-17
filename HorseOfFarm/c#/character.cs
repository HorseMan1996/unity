using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    public Text tiredtext;
    public Text hungerstext;
    public Text waterstext;
    public Text healthtext;

    public Slider tireds;
    public Slider hungers;
    public Slider waters;
    public Slider health;
    // Start is called before the first frame update
    // Update is called once per frame
    void FixedUpdate()
    {
        tiredtext.text = System.Convert.ToString(tireds.value - 0.001f);
        hungerstext.text = System.Convert.ToString(hungers.value - 0.001f);
        waterstext.text = System.Convert.ToString(waters.value - 0.001f);

        if((health.value > 0f) && (tireds.value <= 10f))
        {
            healthtext.text = System.Convert.ToString(health.value - 0.001f);
        }
        if ((health.value > 0f) && (hungers.value <= 10f))
        {
            healthtext.text = System.Convert.ToString(health.value - 0.001f);
        }
        if ((health.value > 0f) && (waters.value <= 10f))
        {
            healthtext.text = System.Convert.ToString(health.value - 0.001f);
        }

        if ((health.value < 100f) && (tireds.value > 80f))
        {
            healthtext.text = System.Convert.ToString(health.value + 0.002f);
        }
        if ((health.value < 100f) && (hungers.value > 80f))
        {
            healthtext.text = System.Convert.ToString(health.value + 0.002f);
        }
        if ((health.value < 100f) && (waters.value > 80f))
        {
            healthtext.text = System.Convert.ToString(health.value + 0.002f);
        }

        tireds.value = System.Convert.ToSingle(tiredtext.text);
        hungers.value = System.Convert.ToSingle(hungerstext.text);
        waters.value = System.Convert.ToSingle(waterstext.text);
        health.value = System.Convert.ToSingle(healthtext.text);

    }
}
