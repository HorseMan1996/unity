using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class missionbox : MonoBehaviour
{
    private Text mymoney;
    bool move = false;
    [SerializeField] Rigidbody box;
    float speed;
    bool carin = false;
    bool carcontrol = false;
    [SerializeField] GameObject cars;
    [SerializeField] GameObject characterss3;
    [SerializeField] Transform theperson;
    [SerializeField] float minDist = 4;
    [SerializeField] float dist = 5f;

    // Start is called before the first frame update
    void Start()
    {
        mymoney = GameObject.Find("havemoney").GetComponent<Text>();
        characterss3 = GameObject.Find("FirstPersonController");
        theperson = GameObject.Find("thepoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = box.velocity.magnitude;
        /* if (carin)
         {
             Debug.Log("dasdf");
             this.transform.position = cars.transform.position;
         }*/
        //speed = carrg.velocity.magnitude * 3.6f;
       /* if (speed > 400)
        {
            this.transform.position = cars.transform.position + new Vector3(0f,3f,0f);
        }*/
    }

    private void OnMouseOver()
    {
        dist = Vector3.Distance(characterss3.transform.position, transform.position);
        if (dist < minDist)
        {
            if (!move)
            {
                usepanelactive.takepanel.SetActive(true);
                usepanelactive.whichobject.text = "Box";
            }
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
        if (dist < minDist)
        {
            this.transform.position = theperson.position;
            this.transform.rotation = theperson.rotation;
        }
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MyCar" && carcontrol)
        {
            carcontrol = false;
            carin = true;
        }
    }*/

   //görev tamam kutu kapıya ulaştı
    private void OnCollisionEnter(Collision collisions)
    {
 
        if (collisions.gameObject.name == "warehousedoorrss")
        {
            Debug.Log("asdf");
            mymoney.text = System.Convert.ToString(System.Convert.ToInt32(mymoney.text) + Random.Range(50, 100));
            this.gameObject.SetActive(false);
        }
        
    }
    //----------------------------
    private void OnMouseDown()
    {
        move = true;
        carcontrol = true;
    }
    private void OnMouseUp()
    {
        move = false;
    }
}
