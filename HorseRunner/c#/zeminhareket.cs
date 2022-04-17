using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeminhareket : MonoBehaviour
{
    public float movespeed = 1f;
    public float a, b,c=0;
    public GameObject zemin;
    // Start is called before the first frame update
    void Start()
    {
        a = zemin.transform.position.x;
        b = zemin.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        c++;
       zemin.transform.position = zemin.transform.position - new Vector3(movespeed, 0f);
        if(c == 2000)
        {
            zemin.transform.position = new Vector3(a, b);
            c = 0;
        }
    }
}
