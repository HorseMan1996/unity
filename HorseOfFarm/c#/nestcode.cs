using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class nestcode : MonoBehaviour
{
    public Text nestegg;
    public Text collectegg;
    public Text haveeggg;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        nestegg.text = haveeggg.text;
    }

    public void collectbtn()
    {
        collectegg.text = System.Convert.ToString(System.Convert.ToInt32(collectegg.text) + System.Convert.ToInt32(nestegg.text));
        nestegg.text = "0";
        haveeggg.text = "0";        
    }
}
