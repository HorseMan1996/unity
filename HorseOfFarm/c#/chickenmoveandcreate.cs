using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenmoveandcreate : MonoBehaviour
{

    public GameObject buyingpanel;
    float x, y, z;
    // Start is called before the first frame update
   /* void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    void OnTriggerEnter(Collider collision)
    {
        if ((collision.name == "Hillbilly"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            buyingpanel.SetActive(true);
            Cursor.visible = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if ((collision.name == "Hillbilly"))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            buyingpanel.SetActive(false);
            Cursor.visible = false;
        }
    }
}
