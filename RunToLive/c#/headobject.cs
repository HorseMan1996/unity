using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headobject : MonoBehaviour
{
    [SerializeField] GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find("handhold");
    }

    // Update is called once per frame
   /* void Update()
    {
        
    }*/
    private void OnMouseDrag()
    {
        this.transform.position = hand.transform.position;
        this.transform.rotation = hand.transform.rotation;
    }
}
