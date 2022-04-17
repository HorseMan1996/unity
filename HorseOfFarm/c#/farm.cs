using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class farm : MonoBehaviour
{

    public GameObject grass;
    public GameObject dirtsounds;
    //public Text seedcoun;
    Text seedcoun;
    // Start is called before the first frame update
    void Start()
    {
        seedcoun = GameObject.Find("haveseed").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((grass.activeSelf) && (grass.transform.localScale.x < 3f))
        {
            grass.transform.localScale += new Vector3(0.00001f, 0.00001f, 0.00001f);
        }
        
    }

    private void OnMouseDown()
    {
        if ((System.Convert.ToInt32(seedcoun.text) > 0) && (grass.activeSelf != true))
        {
            dirtsounds.SetActive(true);
            grass.SetActive(true);
            seedcoun.text =System.Convert.ToString(System.Convert.ToInt32(seedcoun.text) - 1);
        }

        if ((grass.transform.localScale.x >= 3f) && (grass.activeSelf != true))
        {
            grass.SetActive(false);
            seedcoun.text = System.Convert.ToString(System.Convert.ToInt32(seedcoun.text) + Random.Range(1,4));
        }  
    }
}
