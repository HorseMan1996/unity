using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seatable : MonoBehaviour
{
    [SerializeField] GameObject characters;
    float minDist = 3;
    float dist = 5f;
    int b = 0;
    // Start is called before the first frame update
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
            if (b == 1)
            {
                secretareamission.b = 2;
            }
        }
    }
}
