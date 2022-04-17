using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basketballscrtipt : MonoBehaviour
{
    [SerializeField] Slider powersld;
    [SerializeField] GameObject footballpanel;
    public AudioClip kickball;
    public AudioSource kickballsource;
    float minDist = 4;
    float dist = 5f;
    public Transform hand;
    public Rigidbody basketballrg;
    bool hold = false;
    public float power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hold)
        {
            
            footballpanel.SetActive(true);
            this.transform.position = hand.position;
            if (Input.GetMouseButton(1))
            {
                powersld.value = power / 50f;
                if (power < 500)
                {
                    power = power + 10f;
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                footballpanel.SetActive(false);
                hold = false;
                //basketballrg.useGravity = true;
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                basketballrg.AddForce(hand.forward * power);
                power = 0f;
                powersld.value = power;
            }
        }

    }
    private void OnMouseOver()
    {
        dist = Vector3.Distance(hand.position, transform.position);
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
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        hold = true;
    }

    private void OnMouseUp()
    {
        footballpanel.SetActive(false);
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        hold = false;
        usepanelactive.takepanel.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision) {
        kickballsource.PlayOneShot(kickball, 1f);
    }
}
