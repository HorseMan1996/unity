using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcamera : MonoBehaviour
{
    float minDist = 4;
    float dist = 5f;
    bool areyouin = false;

    public Rigidbody maincharacter2;
    public GameObject characterfreeze2;
    public GameObject incarcamera2;
    public GameObject incharacter2;
    public Transform mycharactertransform2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (areyouin)
        {
            mycharactertransform2.position = characterfreeze2.transform.position;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (areyouin)
            {
                areyouin = false;
                sesler.notincar();
                mycharactertransform2.position = this.gameObject.transform.position + new Vector3(0f, 0f, 4f);
                incharacter2.SetActive(true);
                incarcamera2.SetActive(false);
            }
        }
    }

    private void OnMouseOver()
    {
        dist = Vector3.Distance(mycharactertransform2.position, transform.position);
        if (dist < minDist)
        {
            usepanelactive.takepanel.SetActive(true);
        }
        else
        {
            usepanelactive.takepanel.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        usepanelactive.takepanel.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (dist < minDist)
        {
            areyouin = true;
            sesler.areyouincar();
            incarcamera2.SetActive(true);
            incharacter2.SetActive(false);
        }

    }
}
