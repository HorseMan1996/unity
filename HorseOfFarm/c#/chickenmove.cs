using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class chickenmove : MonoBehaviour
{

    static int t = 0;
    private GameObject egggss;
    public Animator chickenanimation;
    private NavMeshAgent nma = null;
    private GameObject[] RandomPoint;
    private int CurrentRandom;
    public AudioSource chickensounds;
    public AudioClip chickenmusic;

    int i = 0;

    private void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        RandomPoint = GameObject.FindGameObjectsWithTag("RandomPoint");
        Debug.Log("RandomPoints = " + RandomPoint.Length.ToString());
        chickenanimation.SetBool("Walk", true);
        egggss = GameObject.Find("egg");
        //createegg();
    }

    private void FixedUpdate()
    {
        i++;
        if(i == 800)
        {
            i = 0;
            chickensounds.PlayOneShot(chickenmusic, 1F);
        }

        if (nma.hasPath == false)
        {
           
            CurrentRandom = Random.Range(0, RandomPoint.Length + 1);
            nma.SetDestination(RandomPoint[CurrentRandom].transform.position);
            Debug.Log("Moving to RandomPoint " + CurrentRandom.ToString());
        }
        if (t == 1)
        {
            t = 0;
            createegg();
        }
    }

    void createegg()
    {
        GameObject egg = Instantiate(egggss) as GameObject;
        egg.transform.position = this.transform.position + new Vector3(0f, 0f, 0f);
    }
    static public void clockcreateegg()
    {
        t = 1;
    }

    private void OnMouseEnter()
    {
        usepanelactive.chickeninfpanel.SetActive(true);
        usepanelactive.chickeninfstext.text = "Good";
    }
    private void OnMouseExit()
    {
        usepanelactive.chickeninfpanel.SetActive(false);
    }
}