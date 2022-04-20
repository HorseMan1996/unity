using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using TMPro;

public class profilcode : MonoBehaviour
{
    [SerializeField] Text secname2;
    [SerializeField] Text seclastname2;
    [SerializeField] Text secpassword2;
    [SerializeField] Text secemail2;
    [SerializeField] Text secnumber2;
    [SerializeField] Text secage2;
    [SerializeField] Text secmale2;
    [SerializeField] Text secusername2;

    [SerializeField] TextMeshProUGUI name3;
    [SerializeField] TextMeshProUGUI lastname3;
    [SerializeField] TextMeshProUGUI password3;
    [SerializeField] TextMeshProUGUI email3;
    [SerializeField] TextMeshProUGUI number3;
    [SerializeField] TextMeshProUGUI age3;
    [SerializeField] TextMeshProUGUI male3;
    [SerializeField] TextMeshProUGUI username3;
    // Start is called before the first frame update
    void Start()
    {
        name3.text = secname2.text;
        lastname3.text = seclastname2.text;
        password3.text = secpassword2.text;
        email3.text = secemail2.text;
        number3.text = secnumber2.text;
        age3.text = secage2.text;
        male3.text = secmale2.text;
        username3.text = secusername2.text;
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
