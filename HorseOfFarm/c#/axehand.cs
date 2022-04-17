using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class axehand : MonoBehaviour
{
    public Text charactertired;
    public Text cuttttertext;

    public int cut = 0;
    public AudioClip axe;
    public AudioSource axes;

    public AudioClip treecutsound;

    public GameObject createaxe;
    public float x, y, z;
    public float y2;

    bool cuttime = false;
    // Start is called before the first frame update
    void Start()
    {
        x = this.transform.localEulerAngles.x;
        y = this.transform.localEulerAngles.y;
        z = this.transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        y2 = this.transform.localEulerAngles.y;
        if (Input.GetMouseButtonDown(1))
        {

            GameObject newaxe = Instantiate(createaxe) as GameObject;
            newaxe.transform.position = this.gameObject.transform.position;
            newaxe.SetActive(true);
            this.gameObject.SetActive(false);
        }
        if (Input.GetMouseButton(0))
        {
            cuttime = true;
            axerotation();
        }
        if (Input.GetMouseButtonDown(0))
        {
            charactertired.text = System.Convert.ToString(System.Convert.ToSingle(charactertired.text) - 0.1f);
            axes.PlayOneShot(axe, 1f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            cuttime = false;
            axebackrotation();
        }
    }

    void axerotation()
    {
        if (y2 > 36f)
        {
            this.transform.Rotate(0f, 10f, 0f);
        }
    }
    void axebackrotation()
    {
        this.transform.localEulerAngles = new Vector3(x, y, z);
        //Quaternion.Euler(x, y, z);
       // Quaternion.EulerAngles(x, y, z);
         //Quaternion.EulerRotation(x, y, z);
       // Quaternion.FromToRotation(x,y,z);
        //this.transform.Rotate(0f, 1f, 0f);
    }
    void OnTriggerEnter(Collider collision)
    {
        if ((collision.name == "tree(Clone)") && (cuttime == true))
        {
            axes.PlayOneShot(treecutsound, 1f);
            cut = cut + Random.Range(0, 20);
            if(cut > 90)
            {
                cut = 0;
                cuttttertext.text = "3";
            }
        }
        /* if (collision.name == "FirstPersonController")
         {
             if(havewoodss.text == "3")
             {
                 //Destroy(this);
                 woodcreate();
                // palledtree.text = System.Convert.ToString(System.Convert.ToInt32(palledtree.text) + Random.Range(1,3));
                 treecutpanel.SetActive(false);
                 havewoodss.text = "0";
                 this.gameObject.SetActive(false);
             }
         }*/
    }
}
