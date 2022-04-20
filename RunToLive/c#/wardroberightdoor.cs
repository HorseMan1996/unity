using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wardroberightdoor : MonoBehaviour
{
    [SerializeField] GameObject characters;
    float minDist = 3;
    float dist = 5f;

    [SerializeField] private AudioClip cabinetdoorgicirti;
    [SerializeField] private AudioClip doorclosesound2;
    [SerializeField] private AudioSource doorclosesounds2;
    float y;
    float hiz = -2f;
    int open = 0;
    int opens = 1;
    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.Find("FirstPersonController");
    }

    // Update is called once per frame
    /* void Update()
      {

      }*/
    private void OnMouseDrag()
    {
        //Debug.Log(this.transform.localRotation.x);
        Debug.Log(this.transform.localRotation.y);
        //Debug.Log(this.transform.localRotation.z);
        if (dist < minDist)
        {
            if (this.transform.localRotation.y < 1 && open == 0 && opens == 1)
            {
                this.transform.Rotate(0, 0, -hiz);
            }
            if (this.transform.localRotation.y > 1 && open == 0)
            {
                doorclosesounds2.PlayOneShot(doorclosesound2, 1f);
                doorclosesounds2.Stop();
                opens = 0;
                open = 1;
            }
            if (this.transform.localRotation.y > 0.60 && open == 1 && opens == 1)
            {
                this.transform.Rotate(0, 0, hiz);
            }
            if (this.transform.localRotation.y < 0.60 && open == 1)
            {
                doorclosesounds2.Stop();
                opens = 0;
                open = 0;
            }
        }
    }

    private void OnMouseDown()
    {
        if (dist < minDist)
        {
            doorclosesounds2.Play();
        }
    }
    private void OnMouseUp()
    {
        doorclosesounds2.Pause();
        opens = 1;
    }
    private void OnMouseOver()
    {
        dist = Vector3.Distance(characters.transform.position, transform.position);
    }
}
