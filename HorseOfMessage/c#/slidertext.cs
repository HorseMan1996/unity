using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class slidertext : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI ageslider;
    [SerializeField] Slider age;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ageslider.text = System.Convert.ToString(age.value);
    }
}
