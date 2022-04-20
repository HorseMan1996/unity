using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemylookcharacter : MonoBehaviour
{
    [SerializeField] private GameObject charactersss;
    // Start is called before the first frame update
    void Start()
    {
        charactersss = GameObject.Find("FirstPersonController");


    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(charactersss.transform);
    }
}
