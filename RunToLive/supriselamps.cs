using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supriselamps : MonoBehaviour
{
    bool son = false;
    [SerializeField] AudioSource ear;
    [SerializeField] AudioSource lightbulb;
    [SerializeField] Light tablelight;
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
    void Update()
    {
        if (open)
        {
            tablelight.intensity = tablelight.intensity + 0.01f;
        }
        if (tablelight.intensity > 10f)
        {
            son = true;
            open = false;
            lightclose.Play();
            lightsoff.SetActive(true);
            lights1.SetActive(false);
            lights2.SetActive(false);
            tablelight.intensity = 0f;
            lightbulb.Play();
            ear.Stop();
        }
    }

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
    private void OnMouseDown()
    {
        if (dist < minDist && !open && !son)
        {
            open = true;
            ear.Play();
            lightopen.Play();
            lightsoff.SetActive(false);
            lights1.SetActive(true);
            lights2.SetActive(true);
            //StartCoroutine(lightbomb());
        }
       /* else if (dist < minDist && open)
        {
            open = false;
            lightclose.Play();
            lightsoff.SetActive(true);
            lights1.SetActive(false);
            lights2.SetActive(false);
        }*/
    }
    private void OnMouseExit()
    {
        paneluse.usepanel.SetActive(false);
    }
    IEnumerator lightbomb()
    {
        tablelight.intensity = tablelight.intensity + 0.1f;
        yield return new WaitForSecondsRealtime(0.1f);
        StartCoroutine(lightbomb());
    }
}
