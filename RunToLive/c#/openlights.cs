using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openlights : MonoBehaviour
{
    [SerializeField] AudioSource lightopen;
    [SerializeField] AudioSource lightclose;
    bool open = false;
    float minDist = 3;
    float dist = 5f;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject lights1;
    [SerializeField] private GameObject lights2;
    [SerializeField] private GameObject lightsoff;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("FirstPersonController");
    }
    // Update is called once per frame
    /*void Update()
    {}*/

    private void OnMouseOver()
    {
        dist = Vector3.Distance(character.transform.position, transform.position);
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
        if (dist < minDist && !open)
        {
            open = true;
            lightopen.Play();
            lightsoff.SetActive(false);
            lights1.SetActive(true);
            lights2.SetActive(true);
        }
        else if (dist < minDist && open)
        {
            open = false;
            lightclose.Play();
            lightsoff.SetActive(true);
            lights1.SetActive(false);
            lights2.SetActive(false);
        }
    }

}
