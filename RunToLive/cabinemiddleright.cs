using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabinemiddleright : MonoBehaviour
{
    [SerializeField] GameObject characters;
    float minDist = 3;
    float dist = 5f;

    public GameObject zombiess;
    public AudioClip doorclosesound7;
    public AudioClip doorclosesound6;
    public AudioSource doorclosesounds6;
    public float y;
    float hiz = -2f;
    int open = 0;
    int opens = 1;
    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.Find("FirstPersonController");
        doorclosesounds6.Play();
        doorclosesounds6.Pause();
    }
    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    private void OnMouseDrag()
    {
        if (dist < minDist)
        {
            if (this.transform.localPosition.z < 0.6 && open == 0 && opens == 1)
            {
                this.transform.localPosition = this.transform.localPosition + new Vector3(0f, 0f, 0.003f);
            }

            if (this.transform.localPosition.z > 0.6 && open == 0 && opens == 1)
            {
                doorclosesounds6.Stop();
                opens = 0;
                open = 1;
            }
            if (this.transform.localPosition.z > 0.23 && open == 1 && opens == 1)
            {
                this.transform.localPosition = this.transform.localPosition - new Vector3(0f, 0f, 0.003f);
            }

            if (this.transform.localPosition.z < 0.23 && open == 1)
            {
                doorclosesounds6.Stop();
                //doorclosesounds6.PlayOneShot(doorclosesound6, 1f);
                opens = 0;
                open = 0;
            }
        }
    }

    private void OnMouseDown()
    {
        if (dist < minDist)
        {
            doorclosesounds6.Play();
            //doorclosesounds6.PlayOneShot(doorclosesound6, 1f);
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
    private void OnMouseUp()
    {
        if (this.transform.localRotation.y < 0.23)
        {
            doorclosesounds6.Pause();
        }
        
            opens = 1;
    }
    private void OnMouseExit()
    {
        paneluse.usepanel.SetActive(false);
    }
}
