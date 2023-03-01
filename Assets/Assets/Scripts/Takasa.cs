using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takasa : MonoBehaviour
{
    [SerializeField] private GameObject takasa;
    [SerializeField] private GameObject bg;
    Big big;
    Vector3 tks;

    // Start is called before the first frame update
    void Start()
    {
        bg = GameObject.Find("GameObject");
        big = bg.GetComponent<Big>();
    }

    // Update is called once per frame
    void Update()
    {
        //tks = takasa.transform.position;

        //if(big.BI == true)
        //{
          //  transform.position = tks;
        //}
    }
}
