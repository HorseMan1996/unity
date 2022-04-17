using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class energycode : MonoBehaviour
{
    public Text energycontrol;
    public Slider energyslider;

    // Update is called once per frame
    void Update()
    {
        energyslider.value = System.Convert.ToSingle(energycontrol.text);
    }
}
