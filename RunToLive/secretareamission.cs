using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretareamission : MonoBehaviour
{
    static public int a = 0;
    static public int b = 0;
    static public int c = 0;


    float hiz = 0.001f;
    bool walsound = false;
    [SerializeField] AudioSource walls1;
    [SerializeField] AudioSource walls2;
    [SerializeField] AudioSource walls3;

    [SerializeField] GameObject leftwall1;
    [SerializeField] GameObject rightwall2;
    [SerializeField] GameObject wall3;
    [SerializeField] GameObject wall4;
    [SerializeField] GameObject paint1;
    [SerializeField] GameObject paint2;
    [SerializeField] GameObject paint3;

    [SerializeField] GameObject door;
    static public bool begin = false;
    // Start is called before the first frame update
    void Start()
    {
        walsound = false;
        begin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (a == 2 && b == 2 && c == 2)
        {
            walls1.Stop();
            walls2.Stop();
            walls3.Stop();
            begin = false;
            wall4.SetActive(false);
            door.SetActive(true);
        }
        if (begin)
        {
            if (!walsound)
            {
                walsound = true;
                walls1.Play();
                walls2.Play();
                walls3.Play();
            }
            wall4.SetActive(true);
            door.SetActive(false);
            leftwall1.transform.position = leftwall1.transform.position + new Vector3(0f, 0f, hiz);
            rightwall2.transform.position = rightwall2.transform.position + new Vector3(0f, 0f, -hiz);
            wall3.transform.position = wall3.transform.position + new Vector3(hiz, 0f, 0f);
            paint1.transform.position = paint1.transform.position + new Vector3(0f, 0f, hiz);
            paint2.transform.position = paint2.transform.position + new Vector3(0f, 0f, -hiz);
            paint3.transform.position = paint3.transform.position + new Vector3(hiz, 0f, 0f);
        }
    }
}
