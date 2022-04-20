using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabinemiddleleft : MonoBehaviour
{
    [SerializeField] GameObject characters;
    float minDist = 3;
    float dist = 5f;

    public AudioClip doorclosesound5;
    public AudioSource doorclosesounds5;
    public float y;
    float hiz = -2f;
    int open = 0;
    int opens = 1;
    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.Find("FirstPersonController");
    }
    // Update is called once per frame
    /* void Update()
     {
         y = this.transform.localPosition.z;
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
                doorclosesounds5.Stop();
                opens = 0;
                open = 1;
            }
            if (this.transform.localPosition.z > 0.23 && open == 1 && opens == 1)
            {
                this.transform.localPosition = this.transform.localPosition - new Vector3(0f, 0f, 0.003f);
            }

            if (this.transform.localPosition.z < 0.23 && open == 1)
            {
                doorclosesounds5.Stop();
                doorclosesounds5.PlayOneShot(doorclosesound5, 1f);
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

    private void OnMouseDown()
    {
        if (dist < minDist)
        {
            doorclosesounds5.Play();
        }
    }
    private void OnMouseUp()
    {
        if (this.transform.localRotation.y < 0.23)
        {
            doorclosesounds5.Pause();
        }
            opens = 1;
        
    }
    private void OnMouseExit()
    {
        paneluse.usepanel.SetActive(false);
    }
}
