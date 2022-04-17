using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incarselectable : MonoBehaviour
{
    float a = 1;
    int signal = 1;
    [SerializeField] private AudioSource buttonsound;

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private string steerwheelrightarm = "rightarm";
    [SerializeField] private string radio = "radio";
    [SerializeField] private Camera incarcamera;
    // Start is called before the first frame update
   /* void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        var ray = incarcamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.collider.transform;
            if (selection.CompareTag(selectableTag))
            {
                if (selection != null)
                {
                    usepanelactive.takepanel.SetActive(true);
                    usepanelactive.whichobject.text = "Lights";
                    if (Input.GetMouseButtonDown(0))
                    {
                        buttonsound.Play();
                        teicarcontroller.headlightsopen();
                    }
                }
            }
            else if (selection.CompareTag(radio))
            {
                if (selection != null)
                {
                    usepanelactive.takepanel.SetActive(true);
                    usepanelactive.whichobject.text = "Radio";
                    a = Input.mouseScrollDelta.y;
                    if (a < 0)
                    {
                        teicarcontroller.carsound = teicarcontroller.carsound - 0.1f;
                    }
                    if (a > 0)
                    {
                        teicarcontroller.carsound = teicarcontroller.carsound + 0.1f;
                    }
                    teicarcontroller.radioscrool = true;
                    if (Input.GetMouseButtonDown(0))
                    {
                        teicarcontroller.radioin = true;
                    }
                }
            }
            else if (selection.CompareTag(steerwheelrightarm))
            {
                usepanelactive.takepanel.SetActive(true);
                usepanelactive.whichobject.text = "Signal";
                if (selection != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        buttonsound.Play();
                        teicarcontroller.signalgive = true;
                        if (signal == 0)
                        {
                            signal = 1;
                            teicarcontroller.forsignal = 1;
                        }
                        else if (signal == 1)
                        {
                            signal = 2;
                            teicarcontroller.forsignal = 2;
                        }
                        else if (signal == 2)
                        {
                        }
                    }
                    if (Input.GetMouseButtonDown(2))
                    {
                        buttonsound.Play();
                        teicarcontroller.signalgive = true;
                        if (signal == 2)
                        {
                            signal = 1;
                            teicarcontroller.forsignal = 1;
                        }
                        else if (signal == 1)
                        {
                            signal = 0;
                            teicarcontroller.forsignal = 0;
                        }
                        else if (signal == 0)
                        {

                        }
                    }
                }
            }
            else
            {
                usepanelactive.takepanel.SetActive(false);
                usepanelactive.whichobject.text = "";
            }
            //Debug.Log(selection);
            //var selectionrenderer = selection.GetComponent<Renderer>();
        }
    }
}
