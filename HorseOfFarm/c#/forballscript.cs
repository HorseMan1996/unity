using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forballscript : MonoBehaviour
{
    public GameObject footballpanel;

    public Slider footballpower;

    public AudioClip kickball;
    public AudioSource kickballsource;

    public Rigidbody m_Rigidbody;
    public Rigidbody character_Rigidbody;
    public GameObject characterssforball;
    float minDist = 4;
    float characterspeed;
    float tx, ty, tz, cx, cy, cz, fx, fy, fz;
    public float dist = 5f;
    public float power = 0;
    // Start is called before the first frame update
    /*  void Start()
    {
        
    }*/

    // Update is called once per frame
     void FixedUpdate()
     {
        dist = Vector3.Distance(characterssforball.transform.position, transform.position);
        characterspeed = character_Rigidbody.velocity.magnitude;
        if (dist < minDist)
        {
            footballpanel.SetActive(true);
            footballpower.value = power;
        }
        else
            footballpanel.SetActive(false);
    }

    private void OnMouseEnter()
    {
        if (dist < minDist)
            usepanelactive.takepanel.SetActive(true);
    }
    private void OnMouseExit()
    {
        usepanelactive.takepanel.SetActive(false);
    }
    private void OnMouseDrag()
    {
        if (power < 15)
        {
            power = power + 0.2f;
        }
    }

    private void OnMouseUp()
    {
        if (dist < minDist)
        {
            kickballsource.PlayOneShot(kickball, 1f);
            tx = transform.position.x;
            ty = transform.position.y;
            tz = transform.position.z;

            cx = characterssforball.transform.position.x;
            cy = characterssforball.transform.position.y;
            cz = characterssforball.transform.position.z;

            fx = cx - tx;
            fy = cy - ty;
            fz = cz - tz;

            /*if (power > 5f)
            {
                kickballsource.PlayOneShot(kickball, 0.7f);
            }
            if (power < 5f && power > 10)
            {
                kickballsource.PlayOneShot(kickball, 1f);
            }*/
            m_Rigidbody.AddForce(-fx * power, 3f, -fz * power, ForceMode.VelocityChange);
            Debug.Log("top top");
        }
        power = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FirstPersonController")
        {
            kickballsource.PlayOneShot(kickball, 1f);
            tx = transform.position.x;
            ty = transform.position.y;
            tz = transform.position.z;

            cx = characterssforball.transform.position.x;
            cy = characterssforball.transform.position.y;
            cz = characterssforball.transform.position.z;

            fx = cx - tx;
            fy = cy - ty;
            fz = cz - tz;
            m_Rigidbody.AddForce(-fx * 4f, 2f, -fz * 4f, ForceMode.VelocityChange);
        }
        else
        {
            kickballsource.PlayOneShot(kickball, m_Rigidbody.velocity.magnitude);
        }
    }
}
