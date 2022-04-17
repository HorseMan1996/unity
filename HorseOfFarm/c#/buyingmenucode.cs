using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class buyingmenucode : MonoBehaviour
{
    public GameObject notenaughm;
    //chicken buying
    public GameObject chickensbuy;
    public GameObject chickenspawnposition;

    int chickenbuycount, i = 0;
    float x, y, z;
    //buy sliders
    public Slider foods;
    public Slider waters;
    public Slider chickens;
    public Slider woods;
    //buy price
    public Text foodcash;
    public Text watercash;
    public Text chickencash;
    public Text eggcash;
    public Text woodsscash;
    public Text woodssellcash;

    //sell sliders
    public Slider eggs;
    public Slider woodsell;

    //characterinformations
    public Text water;
    public Text food;
    public Text chicken;
    public Text egg;
    public Text money;
    public Text marketmoneys;
    public Text haveardiyewood;

    int foodmoney, watermoney, chickenmoney, eggmoney, woodmoney;

    int sum = 0;
    // Start is called before the first frame update
    void Start()
    {
        chickens.maxValue = (System.Convert.ToSingle(10 - System.Convert.ToInt32(chicken.text)));

        woodmoney = System.Convert.ToInt32(Random.Range(1, 3));
        foodmoney = System.Convert.ToInt32(Random.Range(5, 10));
        watermoney = System.Convert.ToInt32(Random.Range(2, 7));
        chickenmoney = System.Convert.ToInt32(Random.Range(20, 40));
        eggmoney = System.Convert.ToInt32(Random.Range(2, 5));
        foods.maxValue = System.Convert.ToInt32(Random.Range(1, 10));
        waters.maxValue = System.Convert.ToInt32(Random.Range(1, 10));
        chickens.maxValue = System.Convert.ToInt32(Random.Range(1, 10));

        woodsscash.text = System.Convert.ToString(woodmoney);
        woodssellcash.text = System.Convert.ToString(woodmoney);
        foodcash.text = System.Convert.ToString(foodmoney);
        watercash.text = System.Convert.ToString(watermoney);
        chickencash.text = System.Convert.ToString(chickenmoney);
        eggcash.text = System.Convert.ToString(eggmoney);
        
        x = chickenspawnposition.transform.position.x;
        y = chickenspawnposition.transform.position.y;
        z = chickenspawnposition.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        marketmoneys.text = money.text;
        eggs.maxValue = System.Convert.ToSingle(egg.text);
        woodsell.maxValue = System.Convert.ToSingle(haveardiyewood.text);
        

        /*foodcash.text = System.Convert.ToString(System.Convert.ToInt32(foods.value) * foodmoney);
        watercash.text = System.Convert.ToString(System.Convert.ToInt32(waters.value) * watermoney);
        chickencash.text = System.Convert.ToString(System.Convert.ToInt32(chickens.value) * chickenmoney);
        eggcash.text = System.Convert.ToString(System.Convert.ToInt32(eggs.value) * eggmoney);*/

        /* tavuk çoğaltma
        GameObject a = Instantiate(chicken) as GameObject;
        a.transform.position = new Vector3(x, y, z);*/

        if (i < chickenbuycount)
        {
            i++;
            GameObject a = Instantiate(chickensbuy) as GameObject;
            a.transform.position = new Vector3(x, y, z);
            if(i == chickenbuycount)
            {
                i = 0;
                chickenbuycount = 0;
            }
        }
    }

    public void buybutton()
    {
        chickens.maxValue = (System.Convert.ToSingle(10 - System.Convert.ToInt32(chicken.text)));
        sum = System.Convert.ToInt32(foods.value) * foodmoney + System.Convert.ToInt32(waters.value) * watermoney + System.Convert.ToInt32(chickens.value) * chickenmoney + System.Convert.ToInt32(woods.value) * woodmoney;
        if(sum > System.Convert.ToInt32(money.text))
        {
            notenaughm.SetActive(true);
        }
        if (sum < System.Convert.ToInt32(money.text))
        {
            money.text = System.Convert.ToString(System.Convert.ToInt32(money.text) - System.Convert.ToInt32(sum));
            food.text = System.Convert.ToString(System.Convert.ToInt32(foods.value) + System.Convert.ToInt32(food.text));
            water.text = System.Convert.ToString(System.Convert.ToInt32(waters.value) + System.Convert.ToInt32(water.text));
            chicken.text = System.Convert.ToString(System.Convert.ToInt32(chickens.value) + System.Convert.ToInt32(chicken.text));
            haveardiyewood.text = System.Convert.ToString(System.Convert.ToInt32(woods.value) + System.Convert.ToInt32(haveardiyewood.text));

            if (System.Convert.ToInt32(chickens.value) > 0 )
            {
                chickenbuycount = System.Convert.ToInt32(chickens.value);
            }
        }

    }

    public void sellbutton()
    {
        egg.text = System.Convert.ToString(System.Convert.ToInt32(eggs.value) - System.Convert.ToInt32(egg.text));
        haveardiyewood.text = System.Convert.ToString(System.Convert.ToInt32(woodsell.value) - System.Convert.ToInt32(haveardiyewood.text));
        money.text = System.Convert.ToString(System.Convert.ToInt32(woodsell.value) * woodmoney + System.Convert.ToInt32(eggs.value) * eggmoney + System.Convert.ToInt32(money.text));

    }

}
