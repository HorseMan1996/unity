using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mountaintable : MonoBehaviour
{
    [SerializeField] GameObject characters;
    float minDist = 3;
    float dist = 5f;
    int b = 0;
    void Start()
    {
        characters = GameObject.Find("FirstPersonController");
    }
    private void OnMouseOver()
    {
        dist = Vector3.Distance(characters.transform.position, transform.position);
    }
    private void OnMouseDown()
    {
        if (dist < minDist)
        {
            if (b < 4)
            {
                b++;
            }
            if (b == 4)
            {
                b = 0;
            }
            if (b == 3)
            {
                secretareamission.c = 2;
            }
        }
    }
}
