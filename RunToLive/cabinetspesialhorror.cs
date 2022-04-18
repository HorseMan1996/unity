using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabinetspesialhorror : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    // Start is called before the first frame update
   /* void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }*/
    private void OnMouseDrag()
    {
        if (this.transform.localRotation.y < -0.99)
        {
            enemy.SetActive(true);
        }
    }
}
