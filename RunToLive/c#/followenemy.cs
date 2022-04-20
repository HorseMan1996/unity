using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class followenemy : MonoBehaviour
{
    public GameObject menscream;
    static int a = 0;
    public GameObject enemysrunning;
    public NavMeshAgent enemy;
    public Transform we;
    public Rigidbody enemys;

    public float enemyspeed;

    public Animator enemyanim;
    // Start is called before the first frame update
    void Start()
    {
        a = 0;
        we = GameObject.Find("FirstPersonController").GetComponent<Transform>();
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        enemyspeed = enemys.velocity.magnitude;
        if (a == 1)
        {
            enemy.SetDestination(we.position);
            enemysrunning.SetActive(true);
            menscream.SetActive(true);
            enemyanim.SetFloat("speed", enemyspeed);
        }
    }

    public static void followstart()
    {
        a = 1;
    }
}

