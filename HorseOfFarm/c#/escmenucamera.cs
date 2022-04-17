using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escmenucamera : MonoBehaviour
{
    public GameObject esCamera;
    // Start is called before the first frame update
  /*  void Start()
    {
        
    }
  */
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0f, -0.1f, 0f);
    }
}
