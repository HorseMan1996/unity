using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning : MonoBehaviour
{
    bool actif = false;
    [SerializeField] AudioSource bumbb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!actif)
        {
            actif = true;
            bumbb.Play();
        }
    }
}
