using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paneluse : MonoBehaviour
{
    [SerializeField] static public GameObject usepanel; 
    // Start is called before the first frame update
    void Start()
    {
        usepanel = GameObject.Find("usepanel");
        usepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
