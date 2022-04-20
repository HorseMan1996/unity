using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabinetrightdown : MonoBehaviour
{
    [SerializeField] GameObject characters;
    float minDist = 3;
    static public float dist = 5f;

    public AudioClip doorclosesound4;
    public AudioSource doorclosesounds4;
    float y;
    float hiz = -2f;
    int open = 0;
    int opens = 1;
    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.Find("FirstPersonController");
    }
    // Update is called once per frame
    /*void Update()
      {

      }*/
    private void OnMouseDrag()
    {
        if (dist < minDist)
        {
            if (this.transform.localRotation.y > -0.99 && open == 0 && opens == 1)
            {
                this.transform.Rotate(0, hiz, 0);
            }
            if (this.transform.localRotation.y < -0.99 && open == 0)
            {
                doorclosesounds4.Stop();
                opens = 0;
                open = 1;
            }
            if (this.transform.localRotation.y < 0 && open == 1 && opens == 1)
            {
                this.transform.Rotate(0, -hiz, 0);
            }
            if (this.transform.localRotation.y > 0 && open == 1)
            {
                doorclosesounds4.Stop();
                doorclosesounds4.PlayOneShot(doorclosesound4, 1f);
                opens = 0;
                open = 0;
            }
        }
    }
  /*  private void OnMouseDown()
    {

    }*/
    private void OnMouseDown()
    {
        if (dist < minDist)
        {
            doorclosesounds4.Play();
        }
    }
    private void OnMouseUp()
    {
        if (this.transform.localRotation.y < 0)
        {
            doorclosesounds4.Pause(); ;
        }
        
            opens = 1;
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
}