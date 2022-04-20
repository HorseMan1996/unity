using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handrotation : MonoBehaviour
{
    float RotationSpeed = 5;
    float mousex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousex = Input.GetAxis("Mouse ScrollWheel");
        if (mousex > 0)
        {
            this.transform.Rotate(new Vector3(10f, 0f, 0f));
        }
        if (mousex < 0)
        {
            this.transform.Rotate(new Vector3(-10f, 0f, 0f));
        }
    }
}
