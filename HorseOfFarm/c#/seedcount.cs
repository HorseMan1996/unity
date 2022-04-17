using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class seedcount : MonoBehaviour
{
    public Text seedcounts;
    public Text haveseed;
    // Start is called before the first frame update
   /* void Start()
    {
        
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        seedcounts.text = haveseed.text;
    }
}
