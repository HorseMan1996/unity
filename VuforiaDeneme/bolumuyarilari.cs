using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class bolumuyarilari : MonoBehaviour
{
    public GameObject bolum1text;
    public GameObject bolum2text;
    public GameObject bolum3text;
    public GameObject bolum4text;
    public GameObject bolum5text;
    int bolum = 0;
    // Start is called before the first frame update
    void Start()
    {
        bolum = bolumyukle();
        if (bolum == 0)
        {
            bolum1text.SetActive(true);
        }
        if(bolum == 2)
        {
            bolum2text.SetActive(true);
        }
        if (bolum == 3)
        {
            bolum3text.SetActive(true);
        }
        if (bolum == 4)
        {
            bolum4text.SetActive(true);
        }
        if (bolum == 5)
        {
            bolum5text.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static int bolumyukle()
    {
        int data3 = 0;
        string path = Application.persistentDataPath + "/bolum.btr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data3 = System.Convert.ToInt32(formatter.Deserialize(stream));
            stream.Close();
            return data3;
        }
        return data3;
    }
}
