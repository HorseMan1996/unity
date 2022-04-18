using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public Slider menusesi2;
    public Slider karaktersesi2;
    public Slider hareketsecenegi2;
    public Scrollbar bekleme;
    public GameObject beklemeyeri;
    int i = 0;
    //public Text bilgi;
    //string ayar1;
    //string[] ayar2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(i == 0)
        {
            i = 1;
            ayarlaryukle();
        }
    }

    public void baslabtn()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void anamenuyedon()
    {
        SceneManager.LoadScene("anamenu", LoadSceneMode.Single);
    }

    public void kapat()
    {
        Application.Quit();
    }

    public void yenidenbaslama()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }


    //-----------------------------------------------------ayarlar kısmının son halini yüklüyor--------------------------------------
    public void ayarlaryukle()
    {
        /* ayar1 = gyrosecenegiyukle();
         ayar2 = ayar1.Split('|');*/
        menusesi2.value = menusesyuksekligiyukle();
        karaktersesi2.value = karaktersesyuksekligiyukle();
        hareketsecenegi2.value = gyrosecenegiyukle();

    }
    public static float gyrosecenegiyukle()
    {
        float data = 0;
        string path = Application.persistentDataPath + "/bitirmegyrosec.btr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data = System.Convert.ToSingle(formatter.Deserialize(stream));
            stream.Close();
            return data;
        }
        return data;

    }
    public static float menusesyuksekligiyukle()
    {
        float data2 = 1;
        string path = Application.persistentDataPath + "/bitirmemenuses.btr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data2 = System.Convert.ToSingle(formatter.Deserialize(stream));
            stream.Close();
            return data2;
        }
        return data2;

    }
    public static float karaktersesyuksekligiyukle()
    {
        float data3 = 1;
        string path = Application.persistentDataPath + "/bitirmekarakterses.btr";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data3 = System.Convert.ToSingle(formatter.Deserialize(stream));
            stream.Close();
            return data3;
        }
        return data3;

    }
    //--------------------------------------------------------------------------------------------------------------------------

}
