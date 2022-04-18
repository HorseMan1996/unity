using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class painttable : MonoBehaviour
{
    [SerializeField] GameObject characters;
    float minDist = 3;
    float dist = 5f;

    [SerializeField] AudioSource tick;
    float rotate = 0f;
    Quaternion rotationtable;
    Quaternion rotationtable2;
    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.Find("FirstPersonController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        dist = Vector3.Distance(characters.transform.position, transform.position);
    }

    private void OnMouseDown()
    {
        if (dist < minDist)
        {
            tick.Play();
            this.transform.Rotate(new Vector3(0f, 90f, 0f));
        }
    }
}
