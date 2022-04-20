using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypressdown : MonoBehaviour
{
    [SerializeField] GameObject characters;
    float minDist = 3;
    float dist = 5f;

    string a = "";
    public AudioSource takesound;
    public AudioClip takesounds;
    public GameObject takekeypanel;

    void OnMouseDown()
    {
        StartCoroutine(talking.write(a));
        appstart.whichmission(1);
        takesound.PlayOneShot(takesounds, 1f);
        takekeypanel.SetActive(true);
        door1.takekey();
        this.gameObject.SetActive(false);
    }
    private void OnMouseExit()
    {
        paneluse.usepanel.SetActive(false);
    }
    private void OnMouseOver()
    {
        if (dist < minDist)
        {
            paneluse.usepanel.SetActive(true);
        }
        if (dist > minDist)
        {
            paneluse.usepanel.SetActive(false);
        }
    }

}
