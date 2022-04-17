using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outselectable : MonoBehaviour
{
    [SerializeField] float tailgatespeed = 0f;
    Quaternion tailgatespeedq;
    [SerializeField] private AudioSource tailgateopensound;

    [SerializeField] private GameObject cartailgate;
    [SerializeField] private string tailgate;
    [SerializeField] private Camera outcarcamera;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = outcarcamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (tailgatespeed == 0 || tailgatespeed == 50)
            {
                tailgateopensound.Stop();
            }
            if (Input.GetMouseButtonUp(0))
            {
                tailgateopensound.Pause();
            }
            var selection = hit.collider.transform;
            if (selection.CompareTag(tailgate))
            {
                if (selection != null)
                {
                    Debug.Log(selection);
                    if (Input.GetMouseButton(0))
                    {
                        if (tailgatespeed < 50)
                        {
                            tailgatespeed = tailgatespeed + 1f;
                            tailgatespeedq = Quaternion.AngleAxis(tailgatespeed, new Vector3(1f, 0f, 0f));
                            cartailgate.transform.localRotation = tailgatespeedq;
                        }
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        tailgateopensound.Play();
                    }
                    if (Input.GetMouseButtonDown(1))
                    {
                        tailgateopensound.Play();
                    }
                    if (Input.GetMouseButton(1))
                    {
                        if (tailgatespeed > 0)
                        {
                            tailgatespeed = tailgatespeed - 1f;
                            tailgatespeedq = Quaternion.AngleAxis(tailgatespeed, new Vector3(1f, 0f, 0f));
                            cartailgate.transform.localRotation = tailgatespeedq;
                        }
                    }
                }
            }
            //var selectionrenderer = selection.GetComponent<Renderer>();
        }
    }
}
