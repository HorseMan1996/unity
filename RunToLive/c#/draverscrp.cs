using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draverscrp : MonoBehaviour
{
    [SerializeField] GameObject characters;
    float minDist = 4f;
    float dist = 5f;
    [SerializeField] AudioClip doorclosesound7;
    [SerializeField] AudioClip doorclosesound6;
    [SerializeField] AudioSource doorclosesounds6;
    float y;
    float hiz = -2f;
    [SerializeField] int open = 0;
    [SerializeField] int opens = 1;
    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.Find("FirstPersonController");
        doorclosesounds6.Play();
        doorclosesounds6.Pause();
    }
    private void OnMouseDown()
    {
        if (dist < minDist)
        {
            doorclosesounds6.Play();
            //doorclosesounds6.PlayOneShot(doorclosesound6, 1f);
        }
    }
    private void OnMouseDrag()
    {
        if (dist < minDist)
        {
            if (this.transform.localPosition.y > -0.0096 && open == 0 && opens == 1)
            {
                this.transform.localPosition = this.transform.localPosition - new Vector3(0f, 0.00005f, 0f);
            }

            if (this.transform.localPosition.y < -0.0096 && open == 0 && opens == 1)
            {
                doorclosesounds6.Stop();
                opens = 0;
                open = 1;
            }
            if (this.transform.localPosition.y < -0.006f && open == 1 && opens == 1)
            {
                this.transform.localPosition = this.transform.localPosition + new Vector3(0f, 0.00005f, 0f);
            }

            if (this.transform.localPosition.y > -0.006f && open == 1)
            {
                doorclosesounds6.Stop();
                //doorclosesounds6.PlayOneShot(doorclosesound6, 1f);
                opens = 0;
                open = 0;
            }
        }
    }

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
    private void OnMouseUp()
    {
        //zombiess.SetActive(true);
        doorclosesounds6.Pause();
        opens = 1;
    }
    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
