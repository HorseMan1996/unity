using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wheelbarrowmove : MonoBehaviour
{
    public GameObject characterss2;
    public GameObject usepanelaxe2;
    float minDist = 4;
    float dist = 5f;

    public Text havewooods;
    public Transform theperson;
    public GameObject wood1;
    public GameObject wood2;
    public GameObject wood3;
    public GameObject wood4;
    public GameObject wood5;
    public GameObject wood6;
    public GameObject wood7;
    public GameObject wood8;
    public GameObject wood9;
    public GameObject wood10;
    public GameObject wood11;
    public GameObject wood12;
    public GameObject wood13;
    public GameObject wood14;
    public GameObject wood15;
    public GameObject wood16;
    public GameObject wood17;
    public GameObject wood18;
    public GameObject wood19;
    public GameObject wood20;

    public int howmuchwood;
    // Start is called before the first frame update
    void Start()
    {
        howmuchwood = 0;
    }

    // Update is called once per frame
    /* void Update()
     {

     }*/

    /*void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "FirstPersonController")
        {

        }

    }*/

    private void OnMouseOver()
    {
        dist = Vector3.Distance(characterss2.transform.position, transform.position);
        if (dist < minDist)
        {
            usepanelaxe2.SetActive(true);
        }
        else
        {
            usepanelaxe2.SetActive(false);
        }
    }
    private void OnMouseExit()
    {
        usepanelaxe2.SetActive(false);
    }

    private void OnMouseDrag()
    {
        if (dist < minDist) {
            this.transform.rotation = theperson.rotation;
            this.transform.position = theperson.position;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "woodparth(Clone)")
        {
            howmuchwood++;
            //createwoodd();
            if (howmuchwood == 1)
            {
                wood1.SetActive(true);
            }
            if (howmuchwood == 2)
            {
                wood2.SetActive(true);
            }
            if (howmuchwood == 3)
            {
                wood3.SetActive(true);
            }
            if (howmuchwood == 4)
            {
                wood4.SetActive(true);
            }
            if (howmuchwood == 5)
            {
                wood5.SetActive(true);
            }
            if (howmuchwood == 6)
            {
                wood6.SetActive(true);
            }
            if (howmuchwood == 7)
            {
                wood7.SetActive(true);
            }
            if (howmuchwood == 8)
            {
                wood8.SetActive(true);
            }
            if (howmuchwood == 9)
            {
                wood9.SetActive(true);
            }
            if (howmuchwood == 10)
            {
                wood10.SetActive(true);
            }
            if (howmuchwood == 11)
            {
                wood11.SetActive(true);
            }
            if (howmuchwood == 12)
            {
                wood12.SetActive(true);
            }
            if (howmuchwood == 13)
            {
                wood13.SetActive(true);
            }
            if (howmuchwood == 14)
            {
                wood14.SetActive(true);
            }
            if (howmuchwood == 15)
            {
                wood15.SetActive(true);
            }
            if (howmuchwood == 16)
            {
                wood16.SetActive(true);
            }
            if (howmuchwood == 17)
            {
                wood17.SetActive(true);
            }
            if (howmuchwood == 18)
            {
                wood18.SetActive(true);
            }
            if (howmuchwood == 19)
            {
                wood19.SetActive(true);
            }
            if (howmuchwood == 20)
            {
                wood20.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.name == "FireWood")
        {
            if (howmuchwood == 1)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood1.SetActive(false);
            }
            if (howmuchwood == 2)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood2.SetActive(false);
            }
            if (howmuchwood == 3)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood3.SetActive(false);
            }
            if (howmuchwood == 4)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood4.SetActive(false);
            }
            if (howmuchwood == 5)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood5.SetActive(false);
            }
            if (howmuchwood == 6)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood6.SetActive(false);
            }
            if (howmuchwood == 7)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood7.SetActive(false);
            }
            if (howmuchwood == 8)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood8.SetActive(false);
            }
            if (howmuchwood == 9)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood9.SetActive(false);
            }
            if (howmuchwood == 10)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood10.SetActive(false);
            }
            if (howmuchwood == 11)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood11.SetActive(false);
            }
            if (howmuchwood == 12)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood12.SetActive(false);
            }
            if (howmuchwood == 13)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood13.SetActive(false);
            }
            if (howmuchwood == 14)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood14.SetActive(false);
            }
            if (howmuchwood == 15)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood15.SetActive(false);
            }
            if (howmuchwood == 16)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood16.SetActive(false);
            }
            if (howmuchwood == 17)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood17.SetActive(false);
            }
            if (howmuchwood == 18)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood18.SetActive(false);
            }
            if (howmuchwood == 19)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood19.SetActive(false);
            }
            if (howmuchwood == 20)
            {
                havewooods.text = System.Convert.ToString(System.Convert.ToInt32(havewooods.text) + 1);
                howmuchwood--;
                wood20.SetActive(false);
            }
        }
    }
}

