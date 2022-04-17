using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class fridgecode : MonoBehaviour
{
    public Text fridgefood;
    public Text fridgewater;
    public Text fridgeegg;
    public Text charackterhavewater;
    public Text charackterhavefood;
    public Text characterhaveegg;

    public GameObject eatbtn;
    public GameObject drinkbtn;

    public Text hungerseat;
    public Text hungerswater;

    public AudioSource drinkwatersound;
    public AudioClip drinkwaterssound;

    public AudioSource eatsound;
    public AudioClip eatssound;
    float water;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        fridgefood.text = charackterhavefood.text;
        fridgewater.text = charackterhavewater.text;
        fridgeegg.text = characterhaveegg.text;
        if (System.Convert.ToInt32(charackterhavefood.text) > 0)
        {
            eatbtn.SetActive(true);
        }
        if (System.Convert.ToInt32(charackterhavefood.text) <= 0)
        {
            eatbtn.SetActive(false);
        }

        if (System.Convert.ToInt32(charackterhavewater.text) > 0)
        {
            drinkbtn.SetActive(true);
        }
        if (System.Convert.ToInt32(charackterhavewater.text) <= 0)
        {
            drinkbtn.SetActive(false);
        }
    }

    public void fridgeeat()
    {
        bool eat = true;


        if (System.Convert.ToInt32(charackterhavefood.text) > 0)
        {
            charackterhavefood.text = System.Convert.ToString(System.Convert.ToInt32(charackterhavefood.text) - 1);
            hungerseat.text =System.Convert.ToString(System.Convert.ToSingle(hungerseat.text) + Random.Range(40f, 70f));
            eatsound.PlayOneShot(eatssound, 1f);
        }
    }

   /* public void fridgedrink()
    {
        if (System.Convert.ToInt32(charackterhavewater.text) > 0)
        {
            charackterhavewater.text = System.Convert.ToString(System.Convert.ToInt32(charackterhavewater.text) - 1);
            hungerswater.value = hungerswater.value + Random.Range(40, 70);
        }
    }*/

    public void drinkwater()
    {
        bool drink = true;
        if (System.Convert.ToInt32(fridgewater.text) > 0)
        {
            water = Random.Range(10f, 30f);
            water = System.Convert.ToSingle(hungerswater.text) + water;
            Debug.Log(water);
            if (water < 100 && drink)
            {
                drink = false;
                charackterhavewater.text = System.Convert.ToString(System.Convert.ToInt32(charackterhavewater.text) - 1);
                drinkwatersound.PlayOneShot(drinkwaterssound, 1f);
                hungerswater.text = System.Convert.ToString(water);
            }
            water = 0;
        }
    }
}
