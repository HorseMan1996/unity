using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabinprocess : MonoBehaviour
{
    [SerializeField] GameObject secretarea;
    // Start is called before the first frame update
    /* void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {


     }*/
    private void OnMouseEnter()
    {
        if (secretareamission.a == 2 && secretareamission.b == 2 && secretareamission.c == 2)
        {
            secretarea.SetActive(false);
        }
       
    }
}
