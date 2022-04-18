using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talking : MonoBehaviour
{
    static char[] array;
    [SerializeField] static private Text talkings;
    // Start is called before the first frame update
    void Start()
    {
        talkings = GameObject.Find("talk").GetComponent<Text>();
    }

    // Update is called once per frame
   /* void Update()
    {
        
    }*/


    static public IEnumerator write(string a)
    {
        talkings.text = "";
        array = null;
        array = a.ToCharArray();
        foreach (var item in array)
        {
            talkings.text += item;
            yield return new WaitForSeconds(0.05f);
        }
        //StartCoroutine(emptypanel());
        yield return new WaitForSecondsRealtime(5f);
        talkings.text = "";
    }


}
