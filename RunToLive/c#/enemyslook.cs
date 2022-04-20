using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyslook : MonoBehaviour
{
    [SerializeField] Transform person3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.right = person3.position - transform.position;
        transform.LookAt(person3);
    }
}
