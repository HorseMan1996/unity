using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;

public class butonss : MonoBehaviour
{
    public string[] roomcontrolsbtn;
    public string[] passcontrolsbtn;
    string rooms;
    string passs;


    public string a;
    static string b;


    public string pass;
    // Start is called before the first frame update
  /*  void Start()
    {
        //talkroom = GameObject.Find("talkroom").GetComponent<GameObject>();

    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void buton()
    {
        /*rooms = maincode.roomnamesload();
        passs = maincode.roompassload();
        roomcontrolsbtn = rooms.Split('|');
        passcontrolsbtn = passs.Split('|');*/
        a = this.transform.GetChild(0).GetComponent<Text>().text;
        b = this.transform.GetChild(1).GetComponent<Text>().text;
        

        maincode.talkr(a, b);
        /*for (int i = 0; i < (roomcontrolsbtn.Length-1); i++)
        {
            if (a == roomcontrolsbtn[i])
            {
                pass = passcontrolsbtn[i];
                a = roomcontrolsbtn[i];
                maincode.talkr(a, pass);
            }
        }*/
    }
}
