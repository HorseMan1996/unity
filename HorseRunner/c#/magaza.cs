using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magaza : MonoBehaviour
{
    public GameObject anamenu;
    public GameObject magazamenu;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    //mağaza buton işlemleri.
    public void magazabtn()
    {
        anamenu.SetActive(false);
        magazamenu.SetActive(true);
    }
    public void magazageribtn()
    {
        anamenu.SetActive(true);
        magazamenu.SetActive(false);
    }
}
