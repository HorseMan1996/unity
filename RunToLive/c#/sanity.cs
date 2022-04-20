using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sanity : MonoBehaviour
{
    [SerializeField] GameObject secretarea;
    public GameObject ligths;

    public AudioClip pill;
    public AudioSource pills;

    public GameObject secretdoor2;
    public GameObject endfornow;
    // Start is called before the first frame update
    /*void Start()
    {

    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }
   */
    private void OnMouseDown()
    {
        secretarea.SetActive(true);
        ligths.SetActive(true);
        appstart.whichmission(3);
        colliderprosess.pilltake();
        pills.PlayOneShot(pill, 1f);
        //endfornow.SetActive(true);
        secretdoor2.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
