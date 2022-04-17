using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class roomtemperature : MonoBehaviour
{
    public Text outdoortemperature;
    public Text indoortemperature;
    public Text stovestart;
    
    // Start is called before the first frame update
    void Start()
    {
        outdoortemperature.text = System.Convert.ToString(Random.Range(10, 20));
        indoortemperature.text = "20";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((System.Convert.ToSingle(stovestart.text) > 0) && System.Convert.ToSingle(indoortemperature.text) < 25f)
        {
             indoortemperature.text = System.Convert.ToString(System.Convert.ToSingle(indoortemperature.text) + 0.001f);
             this.transform.Rotate(0f, 0f, -System.Convert.ToSingle(indoortemperature.text) / 1000f, Space.Self);
        }

        if ((System.Convert.ToSingle(outdoortemperature.text) < System.Convert.ToSingle(indoortemperature.text)) && (System.Convert.ToSingle(stovestart.text) <= 0))
        {
            indoortemperature.text = System.Convert.ToString(System.Convert.ToSingle(indoortemperature.text) - 0.001f);
            this.transform.Rotate(0f, 0f, System.Convert.ToSingle(indoortemperature.text) / 1000f, Space.Self);
        }

        if ((System.Convert.ToSingle(outdoortemperature.text) > System.Convert.ToSingle(indoortemperature.text)) && (System.Convert.ToSingle(stovestart.text) <= 0))
        {
            indoortemperature.text = System.Convert.ToString(System.Convert.ToSingle(indoortemperature.text) + 0.001f);
            this.transform.Rotate(0f, 0f, -System.Convert.ToSingle(indoortemperature.text) / 1000f, Space.Self);
        }
    }
}
