using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class stovefirepanel : MonoBehaviour
{
    public Text stovewood;
    public Text warewood;
    public AudioSource stovesounds;
    public Slider fireslider;
    // Start is called before the first frame update
   /* void Start()
    {
        
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        fireslider.value = System.Convert.ToSingle(stovewood.text);
        if (Input.GetKeyDown("e"))
        {
            if(System.Convert.ToDouble(warewood.text) > 0f)
            {
                stovewood.text = System.Convert.ToString(System.Convert.ToDouble(stovewood.text) + 1f);
                warewood.text = System.Convert.ToString(System.Convert.ToDouble(warewood.text) - 1f);
                stovesounds.Play();
            }
        }
    }
}
