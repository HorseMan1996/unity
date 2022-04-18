using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characteranim : MonoBehaviour
{
    public Rigidbody rb1;
    public Animator anim;
    public float speed = 0;

    public AudioSource walks;
    // Start is called before the first frame update
  /*  void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(speed);
        speed = rb1.velocity.magnitude;
        anim.SetFloat("speed", speed);

        walks.volume = speed;
    }
}
