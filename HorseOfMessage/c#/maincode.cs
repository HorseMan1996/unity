using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using TMPro;

public class maincode : MonoBehaviour
{
    string roomcontrol, passcontrol;
    public string[] roomcontrols;
    public string[] passcontrols;

    string pass;
    static string roomnam;
    static string roomna;
    static string roompa;

    static string a, passs;

    float n = -150;

    static int i = 0;
    public GameObject createroom;

    public GameObject talkingroom;

    static int startcoroutine = 0;

    [SerializeField] Transform menupaneltrs;
    [SerializeField] TextMeshProUGUI mainusername;

    [SerializeField] Text secmainusername2;

    [SerializeField] GameObject mainpanel;
    [SerializeField] GameObject roombtn;

    [SerializeField] TextMeshProUGUI roomname;
    [SerializeField] TextMeshProUGUI roompass;
    // Start is called before the first frame update
    void Start()
    {
        mainusername.text = secmainusername2.text;

        roomcontrol = roomnamesload();
        passcontrol = roompassload();
        if (roomcontrol != "0")
        {
            roomcontrols = roomcontrol.Split('|');
            passcontrols = passcontrol.Split('|');
            for (int i = 0; i < (roomcontrols.Length - 1); i++)
            {
                GameObject a = (GameObject)Instantiate(roombtn);
                a.transform.parent = menupaneltrs;
                a.SetActive(true);
                a.transform.GetChild(0).GetComponent<Text>().text = roomcontrols[i];
                a.transform.GetChild(1).GetComponent<Text>().text = passcontrols[i];
                a.gameObject.transform.SetParent(menupaneltrs);
                a.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, n);
                n = n - 140;
            }
        }
    }

    // Update is called once per frame
      void Update()
      {
        if(startcoroutine == 1)
        {
            startcoroutine = 0;
            StartCoroutine(getData2());
        }
      }

    public void createroombtn()
    {
        i = 0;
        StartCoroutine(getData2());
    }
    public void joinroombtn()
    {
        i = 1;
        StartCoroutine(getData2());
    }


    IEnumerator getData2()
    {
        if (i == 0)
        {
            i = 3;
            string url = "bnesoftware.xyz/horseofmessage/createroom.php";//bağlanacağımız linki yazıyoruz
            WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
            sendForm.AddField("roomname", roomname.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            sendForm.AddField("roompass", roompass.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            sendForm.AddField("personname", secmainusername2.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            sendForm.AddField("message", "0");//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
            yield return sendData;//karşı taraftan bize bir sonuç geri dönüyor

            if (System.Convert.ToString(sendData.text) == "okey")
            {
                //talkingroom.SetActive(true);
                GameObject a = (GameObject)Instantiate(roombtn);
                a.transform.parent = menupaneltrs;
                a.SetActive(true);
                //a.GetComponentInChildren<Text>().text = roomname.text;
                a.transform.GetChild(0).GetComponent<Text>().text = roomname.text;
                a.transform.GetChild(1).GetComponent<Text>().text = roompass.text;
                a.gameObject.transform.SetParent(menupaneltrs);
                a.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, n);
                n = n - 50;
                /*a.transform.position = new Vector3(0f, 0f);*/
                pass = roompass.text;
                roomnam = roomname.text;
                roompassrecord(pass);
                roomna = roomname.text + "|";
                roomnames(roomna);
                roompa = roompass.text + "|";
                roompasswords(roompa);
                createroom.SetActive(false);
            }
            //ad3 = sendData.text.Split('|');
        }
        if (i == 1)
        {
            i = 3;
            string url = "bnesoftware.xyz/horseofmessage/joinroom.php";//bağlanacağımız linki yazıyoruz
            WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
            sendForm.AddField("roomname", roomname.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            sendForm.AddField("roompass", roompass.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            sendForm.AddField("personname", secmainusername2.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            sendForm.AddField("message", "0");//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
            yield return sendData;//karşı taraftan bize bir sonuç geri dönüyor

            if (System.Convert.ToString(sendData.text) == "okey")
            {
                //talkingroom.SetActive(true);
                GameObject a = (GameObject)Instantiate(roombtn);
                a.transform.parent = menupaneltrs;
                a.SetActive(true);
                //a.GetComponentInChildren<Text>().text = roomname.text;
                a.transform.GetChild(0).GetComponent<Text>().text = roomname.text;
                a.transform.GetChild(1).GetComponent<Text>().text = roompass.text;
                a.gameObject.transform.SetParent(menupaneltrs);
                a.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, n);
                n = n - 50;
                /*a.transform.position = new Vector3(0f, 0f);*/
                pass = roompass.text;
                roomnam = roomname.text;
                roompassrecord(pass);
                roomna = roomname.text + "|";
                roomnames(roomna);
                roompa = roompass.text + "|";
                roompasswords(roompa);
                createroom.SetActive(false);
            }
            //ad3 = sendData.text.Split('|');
        }
        if(i == 2)
        {
            i = 3;
            string url = "bnesoftware.xyz/horseofmessage/roombtns.php";//bağlanacağımız linki yazıyoruz
            WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
            sendForm.AddField("roomname", a);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            sendForm.AddField("roompas", passs);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
            yield return sendData;//karşı taraftan bize bir sonuç geri dönüyor
            if (System.Convert.ToString(sendData.text) == "okey")
            {
                talkingroom.SetActive(true);
                room.roomssname(a);
            }
        }
    }

    public static void roompassrecord(string bilgiler)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + roomnam + ".hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, bilgiler);
        stream.Close();
    }

    public static void roomnames(string roomna)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/roomnames.hrs";
        FileStream stream = new FileStream(path, FileMode.Append);

        formatter.Serialize(stream, roomna);
        stream.Close();
    }
    public static void roompasswords(string roompa)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/roompasswords.hrs";
        FileStream stream = new FileStream(path, FileMode.Append);
        formatter.Serialize(stream, roompa);
        stream.Close();
    }


    public static void talkr(string room,string pass){
        i = 2;
        a = room;
        passs = pass;

        startcoroutine = 1;
    }


    public static string roomnamesload()
    {
        string data = "";
        string path = Application.persistentDataPath + "/roomnames.hrs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(path);

            while (stream.Position!=stream.Length)
            {
                data = data + System.Convert.ToString(formatter.Deserialize(stream));
            }
            

            //data = System.Convert.ToString(formatter.Deserialize(stream));
            stream.Close();
            Debug.Log(data);
            return data;
        }
        else
        {
            data = "0";
        }
        return data;
    }
    public static string roompassload()
    {
        string data = "";
        string path = Application.persistentDataPath + "/roompasswords.hrs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            while (stream.Position != stream.Length)
            {
                data = data + System.Convert.ToString(formatter.Deserialize(stream));
            }
            
            stream.Close();
            return data;
        }
        else
        {
            data = "0";
        }
        return data;
    }
}
