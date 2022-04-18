using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysmouselook : MonoBehaviour
{
    bool look = false;
    [SerializeField] AudioSource jumps;
    private void OnMouseEnter()
    {
        if (!look)
        {
            look = true;
            jumps.Play();
        }
    }
}
