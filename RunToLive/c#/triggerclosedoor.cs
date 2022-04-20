using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerclosedoor : MonoBehaviour
{
    [SerializeField] Animator door4anim2;
    public static bool closedoor = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (closedoor)
        {
            closedoor = false;
            door4anim2.SetBool("open", false);
        }
       
    }
}
