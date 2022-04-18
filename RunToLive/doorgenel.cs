using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorgenel : MonoBehaviour
{
    [SerializeField] GameObject characters;
    float minDist = 3;
    float dist = 5f;

    public Animator door1anim2;
    // Start is called before the first frame update
     void Start()
     {
          characters = GameObject.Find("FirstPersonController");
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
            if (Input.GetMouseButtonDown(1))
            {
                door1anim2.SetBool("open", false);
            }
        }
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
    void OnMouseDown()
    {
        if (dist < minDist)
        {
            door1anim2.SetBool("open", true);
        }
        /*  door1anim.SetBool("try", true);
      /* if ((Input.GetMouseButtonUp(0)) && lockd == 0)
       {
           door1anim.SetBool("try", false);
       }
          keypanel.SetActive(false);
          lockd = 1;
          door1anim.SetBool("lock", true);
          ac = 0;


          door1anim.SetBool("open", true);*/
    }
}
