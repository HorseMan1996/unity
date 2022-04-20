using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybreath : MonoBehaviour
{
    bool breathing = false;
    [SerializeField] GameObject characters;
    float minDist = 3;
    float dist = 5f;

    [SerializeField] AudioSource breath;

    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.Find("FirstPersonController");
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(characters.transform.position, transform.position);
        if (dist < minDist && !breathing)
        {
            breathing = true;
            breath.Play();
        }
    }

}
