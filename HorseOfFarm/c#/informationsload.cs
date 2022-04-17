using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;

public class informationsload : MonoBehaviour
{
    public GameObject menucamera;
    public GameObject newgamebtn; 
    public GameObject continuebtn;
    public GameObject firstmenu;

    public GameObject waitpanel;
    string[] load;

    string sum;
    float x, y, z, a, s, d, cx, cy, cz;
    public GameObject kutu;
    public GameObject balta;

    public GameObject charactersss;

    public Text tiredtexts;
    public Text hungertexts;
    public Text watertexts;
    public Text healthtexts;
    public Text havewater;
    public Text havefood;
    public Text havechicken;
    public Text haveeggcollect;
    public Text havemoney;
    public Text haveegg;
    public Text mainwatertankfull;
    public Text animalwatertankfull;
    public Text energy;
    public Text solarpanelstation;
    public Text havewood2;
    public Text havewarehousewood;
    public Text outdoortemperature;
    public Text indoortemperature;
    public Text haveseed;

    public GameObject feyyazabispecial;

    // Start is called before the first frame update
    void Start()
    {
        menucamera.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        string path = Application.persistentDataPath + "/HorseOfFarm.hrs";
        if (File.Exists(path) == true) // dizindeki dosya var mı ?
        {
            loadgame();
            continuebtn.SetActive(true);
        }
        else
        {
            continuebtn.SetActive(false);
        }
        x = kutu.transform.position.x;
        y = kutu.transform.position.y;
        z = kutu.transform.position.z;
        a = balta.transform.position.x;
        s = balta.transform.position.y;
        d = balta.transform.position.z;
    }

    public void newgame()
    {
        StartCoroutine(waitscreen());
        menucamera.SetActive(false);
        havewater.text = "3";
        havefood.text = "3";
        havechicken.text = "1";
        haveeggcollect.text = "1";
        havemoney.text = "10";
        haveegg.text = "2";
        mainwatertankfull.text = "100";
        animalwatertankfull.text = "100";
        energy.text = "100";
        solarpanelstation.text = "0";
        havewood2.text = "0";
        havewarehousewood.text = "3";
        haveseed.text = "4";
        tiredtexts.text = "100";
        hungertexts.text = "100";
        watertexts.text = "100";
        healthtexts.text = "100";
        continuebtn.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        firstmenu.SetActive(false);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            kutu.transform.position = new Vector3(x, y, z);
            balta.transform.position = new Vector3(a, s, d);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            feyyazabispecial.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            feyyazabispecial.SetActive(false);
        }
    }

    public void savegame()
    {
        StartCoroutine(waitscreen());
        sum = havewater.text + "|";
        sum = sum + havefood.text + "|";
        sum = sum + havechicken.text + "|";
        sum = sum + haveeggcollect.text + "|";
        sum = sum + havemoney.text + "|";
        sum = sum + haveegg.text + "|";
        sum = sum + mainwatertankfull.text + "|";
        sum = sum + animalwatertankfull.text + "|";
        sum = sum + energy.text + "|";
        sum = sum + solarpanelstation.text + "|";
        sum = sum + havewood2.text + "|";
        sum = sum + havewarehousewood.text + "|";
        sum = sum + outdoortemperature.text + "|";
        sum = sum + indoortemperature.text + "|";
        sum = sum + haveseed.text + "|";
        sum = sum + tiredtexts.text + "|";
        sum = sum + hungertexts.text + "|";
        sum = sum + watertexts.text + "|";
        sum = sum + healthtexts.text;
        kayit(sum);
    }

    IEnumerator waitscreen()
    {
        waitpanel.SetActive(true);
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(3);
        waitpanel.SetActive(false);
    }

    public void loadgame()
    {
        StartCoroutine(waitscreen());
        sum = yukle();

        load = sum.Split('|');

        havewater.text = load[0];
        havefood.text = load[1];
        havechicken.text = load[2];
        haveeggcollect.text = load[3];
        havemoney.text = load[4];
        haveegg.text = load[5];
        mainwatertankfull.text = load[6];
        animalwatertankfull.text = load[7];
        energy.text = load[8];
        solarpanelstation.text = load[9];
        havewood2.text = load[10];
        havewarehousewood.text = load[11];
        outdoortemperature.text = load[12];
        indoortemperature.text = load[13];
        haveseed.text = load[14];
        tiredtexts.text = load[15];
        hungertexts.text = load[16];
        watertexts.text = load[17];
        healthtexts.text = load[18];
    }

    public static string yukle()
    {
        string data = "100";
        string path = Application.persistentDataPath + "/HorseOfFarm.hrs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data = System.Convert.ToString(formatter.Deserialize(stream));
            stream.Close();
            return data;
        }
        return data;
    }



    public static void kayit(string bilgiler)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HorseOfFarm.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, bilgiler);
        stream.Close();
    }

    // Update is called once per frame
}
