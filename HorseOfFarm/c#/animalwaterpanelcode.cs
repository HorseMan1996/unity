using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class animalwaterpanelcode : MonoBehaviour
{
    public Text animalwaterfulll;
    public Slider animalwaterslider;

    // Update is called once per frame
    void Update()
    {
        animalwaterslider.value = System.Convert.ToSingle(animalwaterfulll.text);


    }
}
