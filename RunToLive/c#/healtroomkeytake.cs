using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healtroomkeytake : MonoBehaviour
{
    public AudioClip enemysclip;
    public AudioSource enemysource;

    public GameObject keyspanel;
    public GameObject enemyss;
    // Start is called before the first frame update
    /* void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {

     }*/
    private void OnMouseDown()
    {
        //enemysource.PlayOneShot(enemysclip, 1f);
        enemyss.SetActive(true);
        keyspanel.SetActive(true);
    }
}
