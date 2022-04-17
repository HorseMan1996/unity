using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodhold : MonoBehaviour
{
    [SerializeField] Rigidbody woodrg;

    private GameObject characterss3;
    //public GameObject usepanelaxe3;
    private Transform theperson2;
    float minDist = 4;
    float dist = 5f;
    // Start is called before the first frame update
    void Start()
    {
        theperson2 = GameObject.Find("thepoint").GetComponent<Transform>();
        characterss3 = GameObject.Find("FirstPersonController");
        //usepanelaxe3 = GameObject.Find("usepanel");
    }

    // Update is called once per frame
     void Update()
     {
        
        if (woodrg.velocity.magnitude > 40f)
        {
            this.gameObject.transform.position = theperson2.position;
        }
     }
    private void OnMouseEnter()
    {
        dist = Vector3.Distance(characterss3.transform.position, transform.position);
        if (dist < minDist)
        {
            usepanelactive.whichobject.text = "wood";
            usepanelactive.takepanel.SetActive(true);
        }
        else
        {
            usepanelactive.whichobject.text = "";
            usepanelactive.takepanel.SetActive(false);
        }
    }
    private void OnMouseExit()
    {
        usepanelactive.whichobject.text = "";
        usepanelactive.takepanel.SetActive(false);
    }
    private void OnMouseDrag()
    {
        // Debug.Log("tıklandı");
        if (dist < minDist)
            this.transform.position = theperson2.position;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Prop_Crate02")
        {
            Destroy(this.gameObject);
        }
    }
}
