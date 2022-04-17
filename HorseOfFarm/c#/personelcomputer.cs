using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class personelcomputer : MonoBehaviour
{

    private Text mymoney;
    //jobs----------------
    [SerializeField] GameObject mission1box;
    [SerializeField] GameObject jobpanel;
    //--------------------

    char[] array;
    //gamesss-------
    public GameObject treecut;
   // public TMP_Text loosetree;

    //--------------

    public AudioSource keyboard;
    public AudioClip keyboardclip;
    int proses = 0;

    //horsemessage--
    public Scrollbar textobject;
    public RectTransform messagesbox;
    public GameObject messagesendbtns;
    public GameObject horsemessagepanel;
    public Text horsemessageplace;
    public InputField horseyourmessage;
    public InputField horsemessagename;
    string[] array2;
    string horsemessagewriting;
    int i = 0;
    //--------------

    public InputField pcinputfields;

    public GameObject chairs;
    public Text pcempty;
    public Text pctextpanel;
    public GameObject personn;
    public GameObject pcpanel;
    // Start is called before the first frame update
    void Start()
    {
        mymoney = GameObject.Find("havemoney").GetComponent<Text>();
    }
    IEnumerator emptypanel()
    {
        yield return new WaitForSeconds(1f);
        pcempty.text = " ";
        yield return new WaitForSeconds(1f);
        pcempty.text = "_";
        StartCoroutine(emptypanel());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (proses == 0)
        {
        if (Input.GetMouseButtonDown(1)) {
            //personn.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            pcpanel.SetActive(false);
        }
        if (pcpanel.activeSelf)
        {
            personn.transform.position = new Vector3(chairs.transform.position.x, personn.transform.position.y, chairs.transform.position.z);
        }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (pctextpanel.text == "open/horsemessage.hrs")
                {
                    i = 1;
                    StartCoroutine(horsemessage());
                    Debug.Log("enter");
                    horsemessagepanel.SetActive(true);
                    //pcinputfields.text = "i'm HorseMan";
                }

                else if (pctextpanel.text == "whats your name")
                {
                    Debug.Log("enter");
                    StartCoroutine(emptypanelwriting("i'm HorseMan"));
                    //pcinputfields.text = "i'm HorseMan";
                }

                else if (pctextpanel.text == "open/treecut.hrs")
                {
                    StartCoroutine(emptypanelwriting("opened sir."));
                    treecut.SetActive(true);
                }

                else if (pctextpanel.text == "hi")
                {
                    StartCoroutine(emptypanelwriting("hello sir."));
                }

                else if (pctextpanel.text == "hello")
                {
                    StartCoroutine(emptypanelwriting("hi sir."));
                }

                else if (pctextpanel.text == "findjob.hrs")
                {
                    StartCoroutine(emptypanelwriting("Jobs panel opened."));
                    jobpanel.SetActive(true);
                }

                else if (pctextpanel.text == "mymoney")
                {
                    string a = "your money : " + mymoney.text + " h";
                    StartCoroutine(emptypanelwriting(a));
                }

                else if (pctextpanel.text == "close")
                {
                    StartCoroutine(emptypanelwriting("closed sir."));
                    treecut.SetActive(false);
                    horsemessagepanel.SetActive(false);
                }

                else
                {
                    StartCoroutine(emptypanelwriting("i dont understand you sir."));
                }
            }
        }
    }
    IEnumerator emptypanelwriting(string write)
    {
        proses = 1;
        pcinputfields.text = "";
        array = null;
        array = write.ToCharArray();
        foreach (var item in array)
        {
            pcinputfields.text += item;
            yield return new WaitForSeconds(0.15f);
        }
        //StartCoroutine(emptypanel());
        proses = 0;
    }

    public void messagesendbtn()
    {
        i = 0;
        StartCoroutine(horsemessage());
        messagesendbtns.SetActive(false);
    }

    IEnumerator horsemessage()
    {
        if (i == 1)
        {
            i = 2;
            string url = "bnesoftware.xyz/unitygame/horseoffarm/messagetake.php";//bağlanacağımız linki yazıyoruz
            WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
            WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
            yield return sendData;//karşı taraftan bize bir sonuç geri dönüyordeğişkenleri
            horsemessagewriting = sendData.text;
            Debug.Log(sendData.text);
            //  ctrl + 221 ▌
            array2 = horsemessagewriting.Split('▌');
            horsemessageplace.text = "";
            foreach (string add in array2)
            {
                horsemessageplace.text += add + "\n";
            }
            messagesbox.sizeDelta = new Vector2(messagesbox.rect.width, array2.Length * 45.5f);
            textobject.value = 0;
            /* for (int i = 0; i < array.Length; i++)
             {
                 horsemessageplace.text = horsemessageplace.text + array2[i] + "\n";
             }*/
            array = null;
            yield return new WaitForSecondsRealtime(10f);// WaitForSeconds(10f);
            i = 1; 
            StartCoroutine(horsemessage());
        }
        if (i == 0)
        {
            string url = "bnesoftware.xyz/unitygame/horseoffarm/messagesend.php";//bağlanacağımız linki yazıyoruz
            WWWForm sendForm = new WWWForm();//karşı tarafa bir istekte bulunuyoruz form gönderiyoruz yani
            sendForm.AddField("who", horsemessagename.text + " : " + horseyourmessage.text + "▌");//karşı tarafada yazdığımız değişkenleri isimleri aynı olacak şekilde eşleştiriyoruz
            WWW sendData = new WWW(url, sendForm);//formu karşıya gönderiyoruz url ve eklediğimiz bilgilerle
            yield return sendData;//karşı taraftan bize bir sonuç geri dönüyordeğişkenleri
            horsemessagewriting = sendData.text;
            yield return new WaitForSecondsRealtime(6f);
            messagesendbtns.SetActive(true);
            i = 1;
            StartCoroutine(horsemessage());
        }
        //array = write.ToCharArray();
    }
    public void jobs(int whichjob)
    {
        if (whichjob == 1)
        {
            StartCoroutine(emptypanelwriting("Job accepted."));
            mission1box.SetActive(true);
        }
    }
    private void OnMouseDown()
    {
        usepanelactive.whichobject.text = "";
        usepanelactive.takepanel.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pcpanel.SetActive(true); 
        StartCoroutine(emptypanel());
        //personn.SetActive(false);
    }

    private void OnMouseEnter()
    {
        usepanelactive.takepanel.SetActive(true);
        usepanelactive.whichobject.text = "Computer";
    }

    private void OnMouseExit()
    {
        usepanelactive.whichobject.text = "";
        usepanelactive.takepanel.SetActive(false);
    }

    public void keyboardsound()
    {
        keyboard.PlayOneShot(keyboardclip, Random.Range(0.1f,1f));
    }
}
