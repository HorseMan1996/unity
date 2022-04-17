using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class treecutcode : MonoBehaviour
{
    public TMP_Text treepoint;
    public TMP_Text loosetree;

    public Text havewoods;
    public GameObject axe, startposition, stopposition;
    public AudioSource woodcutsound;
    public AudioClip woodcuts;
    public AudioSource woodfailcutsound;
    public AudioClip woodfailcuts;
    float speed = 1f;
    float x, y, z;
    public int x1 = 0;
    public Slider charactertired;
    // Start is called before the first frame update
    void Start()
    {
        loosetree.text = "3";
        x = axe.transform.position.x;
        y = axe.transform.position.y;
        z = axe.transform.position.z;
        startposition.transform.position = new Vector3(x + 500, y, z);
        stopposition.transform.position = new Vector3(x + 550, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (loosetree.text == "0")
        {
            treepoint.text = "0";
            loosetree.text = "3";
        }

        if (axe.transform.position.x > (x + 700))
        {
            woodfailcutsound.PlayOneShot(woodfailcuts, 1F);
            //charactertired.value = charactertired.value - 1;
            axe.transform.position = new Vector3(x, y, z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if ((axe.transform.position.x > x + 500) && ((axe.transform.position.x < x + 550)))
            {
                treepoint.text = System.Convert.ToString(System.Convert.ToInt32(treepoint.text) + 1);
                woodcutsound.PlayOneShot(woodcuts, 1F);
                x1++;
                axe.transform.position = new Vector3(x, y, z);
            }

            else if ((axe.transform.position.x < x + 500) || ((axe.transform.position.x > x + 550)))
            {
                loosetree.text = System.Convert.ToString(System.Convert.ToInt32(loosetree.text) - 1);
                woodfailcutsound.PlayOneShot(woodfailcuts, 1F);
               // charactertired.value = charactertired.value - 1;
                axe.transform.position = new Vector3(x, y, z);
            }


            speed = Random.Range(3f, 15f);
        }

      /*  if(x1 == 3)
        {
            havewoods.text = "3";
            x1 = 0;
        }*/

        axe.transform.Rotate(0f, 0f, -speed, Space.Self);
        axe.transform.position = axe.transform.position + new Vector3(speed, 0f, 0f);
    }
}
