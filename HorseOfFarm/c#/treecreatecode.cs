using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class treecreatecode : MonoBehaviour
{
    public int i = 0, a = 20;
    public Text havewoodss2;
    public GameObject tree2;

    float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        x = tree2.transform.position.x;
        y = tree2.transform.position.y;
        z = tree2.transform.position.z;
        treecreate();
    }

    // Update is called once per frame
  /*  void Update()
    {
        
    }*/
    void treecreate()
    {
        for (int i = 0; i < 20; i++)
        {
            i++;
            a = a + 20;
            GameObject tree = Instantiate(tree2) as GameObject;
            tree.transform.position = new Vector3(x, y, z + a);
        }
    }
}
