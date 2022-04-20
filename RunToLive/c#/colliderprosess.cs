using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colliderprosess : MonoBehaviour
{
    [SerializeField] AudioSource wallcrash;
    [SerializeField] AudioClip wallcrashsound;
    int wallscrash = 0;
    int wallscrash2 = 0;
    [SerializeField] GameObject waitscreen;

    static int pill = 0;
    public GameObject secretwallcreate;

    public AudioClip jumpscare;
    public AudioSource jumpscares;

    public GameObject secretwall1;
    public GameObject secretenemy;
    public GameObject breathing2;

    public GameObject jumpscareenemy;
    public GameObject jumpscareenemytrigger;
    public GameObject jumpscarecamera;
    [SerializeField] GameObject enemy1;

    public GameObject lightss;
    public GameObject secretdoorwall1;

    public GameObject secretwaldoor4;

    //bolum1secretarea
    [SerializeField] GameObject section1door;
    //----------------

    //koşubölümü--
    [SerializeField] GameObject warning;
    //------------

    // Start is called before the first frame update
      void Start()
      {
        StartCoroutine(starts());
      }
    IEnumerator starts()
    {
        waitscreen.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        waitscreen.SetActive(false);
    }
    // Update is called once per frame
    /*void Update()
    {

    }*/

    void aryoudead()
    {
        if (wallscrash == 1 && wallscrash2 == 1)
        {
            dead();
            this.transform.position = new Vector3(32.26f, 3.93f, 4.35f);
        }
    }
    public void dead()
    {
        StartCoroutine(deads());
    }
    IEnumerator deads()
    {
        wallcrash.PlayOneShot(wallcrashsound, 1f);
        waitscreen.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "secretarea (1)")
        {
            wallscrash = 0;
        }
        if (other.name == "secretarea (2)")
        {
            wallscrash = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "enemy1trigger")
        {
            secretdoorwall1.SetActive(true);
            enemycontroller.triggerr();
            triggerclosedoor.closedoor = true;
            secretenemy.SetActive(true);
            secretwall1.SetActive(false);
            StartCoroutine(ExampleCoroutine());
        }
        if (other.name == "enemyjumpscaretrigger")
        {
            StartCoroutine(talking.write("DAMN IT, WHAT IS THAT"));
            enemy1.SetActive(false);
            appstart.whichmission(2);
            StartCoroutine(ExampleCoroutine3());
        }
        if (other.name == "enemy1trigger3")
        {
            StartCoroutine(ExampleCoroutine4());
            secretwaldoor4.SetActive(false);

            jumpscares.PlayOneShot(jumpscare, 1f);
            secretdoorwall1.SetActive(false);
            followenemy.followstart();
        }

        //ölme durumu
        if (other.name == "secretarea (1)")
        {
            wallscrash2 = 1;
            aryoudead();
        }
        if (other.name == "secretarea (2)")
        {
            wallscrash = 1;
            aryoudead();
        }
        if (other.name == "enemy Variant follow")
        {
            dead();
            this.transform.position = new Vector3(12.7f, 3.93f, 71.3f);
        }
        //----------

        //bolum1secretarea
        if (other.name == "secretarea1trigger")
        {
            secretareamission.begin = true;
        }
        //----------------
        //koşbölüm
        if (other.name == "warningtriger")
        {
            warning.SetActive(true);
        }
        //--------
    }

    IEnumerator ExampleCoroutine4()
    {
        lightss.SetActive(false);
        yield return new WaitForSeconds(1f);
        lightss.SetActive(true);
    }

    IEnumerator ExampleCoroutine()
    {
        breathing2.SetActive(true);
        yield return new WaitForSeconds(2);
        breathing2.SetActive(false);
    }
    IEnumerator ExampleCoroutine2()
    {
        jumpscareenemy.SetActive(true);
        yield return new WaitForSeconds(1);
        jumpscareenemy.SetActive(false);
    }
    IEnumerator ExampleCoroutine3()
    {
        breathing2.SetActive(true);
        jumpscarecamera.SetActive(true);
        jumpscares.PlayOneShot(jumpscare, 1f);
        yield return new WaitForSeconds(0.3f);
        jumpscarecamera.SetActive(false);
        yield return new WaitForSecondsRealtime(Random.Range(5f, 20f));
        breathing2.SetActive(false);
        if (pill != 1)
        {
            StartCoroutine(ExampleCoroutine3());
        }
    }

    public static void pilltake()
    {
        pill = 1;
    }

}
