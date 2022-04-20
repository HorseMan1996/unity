using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using TMPro;

public class registercode : MonoBehaviour
{
    string time;

    public string[] ad3;
    string information;
    public string[] ad;
    string inf;

    public string control;

    public GameObject registerpnl;
    public GameObject loginsuccess;

    [SerializeField] Text secname;
    [SerializeField] Text seclastname;
    [SerializeField] Text secpassword;
    [SerializeField] Text secemail;
    [SerializeField] Text secnumber;
    [SerializeField] Text secage;
    [SerializeField] Text secmale;
    [SerializeField] Text secusername;



    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI lastname;
    [SerializeField] TextMeshProUGUI password;
    [SerializeField] TextMeshProUGUI email;
    [SerializeField] TextMeshProUGUI number;
    [SerializeField] TextMeshProUGUI age;
    [SerializeField] TextMeshProUGUI male;
    [SerializeField] TextMeshProUGUI username;
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/recorded.hrs";
        if (File.Exists(path) == true) // dizindeki dosya var mı ?
        {
            inf = fileload();
            ad = inf.Split('|');
            secname.text = ad[0];
            seclastname.text = ad[1];
            secpassword.text = ad[2];
            secemail.text = ad[3];
            secnumber.text = ad[4];
            secage.text = ad[5];
            secmale.text = ad[6];
            secusername.text = ad[7];
            loginsuccess.SetActive(true);
            registerpnl.SetActive(false);
        }
        else
        {
            Debug.Log("dosya yok");
        }
    }

    // Update is called once per frame
   /* void FixedUpdate()
    {
        
    }*/

    public void sendbtn()
    {
        /*  if(name.text == "" || lastname.text == "" || password.text == "" || email.text == "" || number.text == "" || age.text == "" || male.text == "" || username.text == "")
          {
              Debug.Log("boş bırakmayınız.");
          }
          else
          {
          }*/
        StartCoroutine(getData());
    }

    IEnumerator getData()
    {
        time = System.DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-dd");
        string url = "bnesoftware.xyz/horseofmessage/register.php";//bağlanacağımız linki yazıyoruz
        WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
        sendForm.AddField("name", name.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm.AddField("lastname", lastname.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm.AddField("password", password.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm.AddField("email", email.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm.AddField("numbers", number.text);//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
        sendForm.AddField("age", age.text);
        sendForm.AddField("male", male.text);
        sendForm.AddField("username", username.text);
        sendForm.AddField("firsttime", time);
        WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
        yield return sendData;//karşı taraftan bize bir sonuç geri dönüyor
        Debug.Log(System.Convert.ToString(sendData.text));
        ad3 = sendData.text.Split('|');
        if (ad3[0] == "success")
            {
            information = name.text + "|" + lastname.text + "|" + password.text + "|" + email.text + "|" + number.text + "|" + age.text + "|" + male.text + "|" + username.text + "|" + time;
            filerecord(information);
            inf = fileload();
            ad = inf.Split('|');
            secname.text = ad[0];
            seclastname.text = ad[1];
            secpassword.text = ad[2];
            secemail.text = ad[3];
            secnumber.text = ad[4];
            secage.text = ad[5];
            secmale.text = ad[6];
            secusername.text = ad[7];
            loginsuccess.SetActive(true);
            registerpnl.SetActive(false);
        }

    }

    public static void filerecord(string bilgiler)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/recorded.hrs";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, bilgiler);
        stream.Close();
    }

    public static string fileload()
    {
        string data = "";
        string path = Application.persistentDataPath + "/recorded.hrs";
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
}
