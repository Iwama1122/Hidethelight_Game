using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efekutoidou : MonoBehaviour
{
    public GameObject oya;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 px = oya.transform.position;
        this.transform.position += px;
    }
}
