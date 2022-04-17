using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class usepanelactive : MonoBehaviour
{
    bool map = false;
    static public GameObject chickeninfpanel;
    static public TMP_Text chickeninfstext;
    static public Text addegg;
    static public GameObject takepanel;
    static public Text whichobject;

    [SerializeField] AudioSource mapsounds;
    [SerializeField] AudioClip mapsoundsopen;
    [SerializeField] AudioClip mapsoundsclose;

    [SerializeField] GameObject maps;
    // Start is called before the first frame update
    void Start()
    {
        chickeninfpanel = GameObject.Find("chickeninf");
        chickeninfstext = GameObject.Find("chickeninftext").GetComponent<TMP_Text>();
        whichobject = GameObject.Find("whichobject").GetComponent<Text>();
        whichobject.text = "";
        chickeninfpanel.SetActive(false);
        addegg = GameObject.Find("haveegg").GetComponent<Text>();
        takepanel = GameObject.Find("usepanel");
        //variableForPrefab = Resources.Load("prefabs/prefab1", GameObject) as GameObject;
        takepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (map)
            {
                map = false;
                mapsounds.PlayOneShot(mapsoundsopen, 1f);
                maps.SetActive(true);
            }
            else if (!map)
            {
                map = true;
                mapsounds.PlayOneShot(mapsoundsclose, 1f);
                maps.SetActive(false);
            }
        }
    }
}
