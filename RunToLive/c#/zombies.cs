using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombies : MonoBehaviour
{
    public AudioClip scream;
    public AudioSource screams;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        screams.PlayOneShot(scream, 0.65f);
    }
}
