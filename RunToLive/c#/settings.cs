using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class settings : MonoBehaviour
{
    [SerializeField] Slider light;
    // Start is called before the first frame update
    /*void Start()
    {
    }*/

    // Update is called once per frame
    void Update()
    {
        RenderSettings.ambientSkyColor = new Color(light.value, light.value, light.value);
    }
}
