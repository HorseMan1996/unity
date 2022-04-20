using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    [SerializeField] static int a,b;
    public Animator enemyy;
    public GameObject enemyrunsound;
    public GameObject gamerhorrorsoun;
    // Start is called before the first frame update
   /* void Start()
    {

    }*/

    // Update is called once per frame
    void Update()
    {
        if (a==1)
        {
            this.transform.position = this.transform.position + new Vector3(-0.3f, 0f, 0f);
        }
        if(b == 1)
        {
            b = 0;
            animationtrue();
            enemyrunsound.SetActive(true);
            gamerhorrorsoun.SetActive(true);
        }
    }

    void animationtrue()
    {
        enemyy.SetBool("run", true);
    }

    public static void triggerr()
    {
        a = 1;
        b = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "enemy1trigger2")
        {
            this.gameObject.SetActive(false);
        }
    }
}
