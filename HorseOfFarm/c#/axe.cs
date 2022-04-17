using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour
{
    public GameObject characterss;
    public GameObject usepanelaxe;
   
    public GameObject axes;
    float minDist = 4;
    float dist = 5f;
    // public Transform personsss;
    //int a = 0;
    // Start is called before the first frame update
    /*  void Start()
      {

      }*/

    // Update is called once per frame
   /* void FixedUpdate()
    {
         if (a == 1)
         {
             this.transform.position = personsss.transform.position;
         }

         if (Input.GetMouseButtonDown(1))
         {
             a = 0;
         }


    }*/
    private void OnMouseOver()
    {
        dist = Vector3.Distance(characterss.transform.position, transform.position);
        if (dist < minDist)
        {
            usepanelactive.whichobject.text = "Axe";
            usepanelaxe.SetActive(true);
        }
        else
        {
            usepanelactive.whichobject.text = "";
            usepanelaxe.SetActive(false);
        }

    }
    private void OnMouseExit()
    {
        usepanelactive.whichobject.text = "";
        usepanelaxe.SetActive(false);
    }
    private void OnMouseDown()
    {
        usepanelactive.whichobject.text = "";
        usepanelaxe.SetActive(false);
        if (dist < minDist)
        {
            axes.SetActive(true);
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }

    }
}
