using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class mainwatertankpanelcode : MonoBehaviour
{
    public Text mainwatercontroll;

    public Slider mainwaterfulll;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        mainwaterfulll.value = System.Convert.ToSingle(mainwatercontroll.text);
    }
}
