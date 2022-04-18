using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission1doordock : MonoBehaviour
{
    [SerializeField] AudioSource knock;
    bool a = true;
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
        if (a == true)
        {
            a = false;
            knock.Play();
        }
    }
}
