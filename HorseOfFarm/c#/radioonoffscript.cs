using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioonoffscript : MonoBehaviour
{
    [SerializeField] float a;
    [SerializeField] GameObject characterss;
    bool opened = false;
    public AudioSource radio;
    public AudioClip song1;

    float minDist = 4;
    float dist = 5f;
    // Start is called before the first frame update
  /*  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(a);
    }*/

   /* private void OnMouseEnter()
    {

    }*/
    private void OnMouseOver()
    {
        dist = Vector3.Distance(characterss.transform.position, transform.position);
        if (dist < minDist)
        {
            a = Input.mouseScrollDelta.y;
            if (a < 0)
            {
                radio.volume = radio.volume - 0.1f;
            }
            if (a > 0)
            {
                radio.volume = radio.volume + 0.1f;
            }
            // 
            usepanelactive.whichobject.text = "Radio On/Off - Volume";
            usepanelactive.takepanel.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        usepanelactive.whichobject.text = "";
        usepanelactive.takepanel.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (dist < minDist)
        {
            if (opened == false)
            {
                opened = true;
                radio.Play();
            }
            else if (opened == true)
            {
                opened = false;
                radio.Pause();
            }
        }
    }
    
}
