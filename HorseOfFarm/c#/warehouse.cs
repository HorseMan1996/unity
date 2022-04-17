using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class warehouse : MonoBehaviour
{
    public GameObject woodgraph;
    public Text doyouhavewood;
    public Text doyouhavewoodpaneltext;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        doyouhavewoodpaneltext.text = doyouhavewood.text;
    }
}
