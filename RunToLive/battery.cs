using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery : MonoBehaviour
{
    [SerializeField] AudioSource takebattery;
    [SerializeField] GameObject characters;
    float minDist = 3;
    float dist = 5f;
    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.Find("FirstPersonController");
        takebattery = GameObject.Find("takesounds").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    private void OnMouseOver()
    {
        dist = Vector3.Distance(characters.transform.position, transform.position);
        if (dist < minDist)
        {
            paneluse.usepanel.SetActive(true);
        }
        if (dist > minDist)
        {
            paneluse.usepanel.SetActive(false);
        }
    }
    private void OnMouseExit()
    {
        paneluse.usepanel.SetActive(false);
    }
    private void OnMouseDown()
    {
        paneluse.usepanel.SetActive(false);
        takebattery.Play();
        characterprocess.batteryaddwhich(Random.Range(10, 20));
        this.gameObject.SetActive(false);
    }
}
