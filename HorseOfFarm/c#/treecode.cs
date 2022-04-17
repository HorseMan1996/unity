using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class treecode : MonoBehaviour
{
    //public int cut = 0;
    public Animator treefalll;
    public Text havewoodss;
    public GameObject treecutpanel;
    public Text palledtree;
    public GameObject woodparth;
    [SerializeField] bool fall = false;

    int a = 0;
    // Update is called once per frame
    void Update()
     {
        /*  if(i == 0)
          {
              Debug.Log("bb");
              i++;
              a = a + 50;
              GameObject tree = Instantiate(tree2) as GameObject;
              tree.transform.position = new Vector3(x, y, z + a);
          }*/
        if (fall == true)
        {
            woodcreate();
            this.gameObject.SetActive(false);
        }
     }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "axe")
        {
            /*cut = Random.Range(0, 10);
            if(cut > 7)
            {
                havewoodss.text = "3";
            }*/
           /* if (a == 0)
            {
                a = 1;
                havewoodss.text = "1";
            }
            if (a == 2)
            {
                a = 3;
                havewoodss.text = "2";
            }
            if (a == 4)
            {
                a = 5;
                havewoodss.text = "3";
            }*/
        }

        if (havewoodss.text == "3")
        {
            havewoodss.text = "0";
            treefalll.SetBool("treefall", true);
            //Destroy(this);
            // palledtree.text = System.Convert.ToString(System.Convert.ToInt32(palledtree.text) + Random.Range(1,3));
            //treecutpanel.SetActive(false);
            //this.gameObject.SetActive(false);
            
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.name == "axe")
        {
            /*if (a == 1)
            {
                a = 2;
            }
            if (a == 3)
            {
                a = 4;
            }
            if (a == 5)
            {
                a = 0;
            }*/
        }
    }

    /* void OnTriggerStay(Collider collision)
     {
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
         }
     }*/
    public void woodcreate()
    {
        int a = Random.Range(1, 4);
        for (int i = 0; i < a; i++)
        {
            GameObject tree = Instantiate(woodparth) as GameObject;
            tree.transform.position = this.transform.position + new Vector3(0f,2f,0f);
        }
    }
}
