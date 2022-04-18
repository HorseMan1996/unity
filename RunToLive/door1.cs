using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door1 : MonoBehaviour
{
    bool lockedtalk = false;
    [SerializeField] GameObject characters;
    float minDist = 3;
    float dist = 5f;

    public GameObject keypanel;
    static int key = 0;
    public Animator door1anim;
    int lockd = 0;
    int ac = 0;
    // Start is called before the first frame update
    void Start()
    {
        lockd = 0;
        characters = GameObject.Find("FirstPersonController");
    }

    /*void OnTriggerStay(Collider collision)
    {


    }*/


    private void OnMouseExit()
    {
        door1anim.SetBool("try", false);
        paneluse.usepanel.SetActive(false);

    }

    private void OnMouseOver()
    {
        dist = Vector3.Distance(characters.transform.position, transform.position);
        if (dist < minDist)
        {
            if (Input.GetMouseButtonDown(1))
            {
                door1anim.SetBool("open", false);
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

    void OnMouseDown()
    {
        if (dist < minDist)
        {
            if (lockd == 0)
            {
                door1anim.SetBool("try", true);
                if (!lockedtalk)
                {
                    lockedtalk = true;
                    StartCoroutine(talking.write("The door is locked, I have to find the key"));
                }
                
            }
            /* if ((Input.GetMouseButtonUp(0)) && lockd == 0)
             {
                 door1anim.SetBool("try", false);
             }*/
            if (key == 1)
            {
                keypanel.SetActive(false);
                lockd = 1;
                door1anim.SetBool("lock", true);
                ac = 0;
                key = 0;
            }
            if (lockd == 1)
            {
                door1anim.SetBool("open", true);
            }
        }
    }

    public static void takekey()
    {
        key = 1;
    }

}
