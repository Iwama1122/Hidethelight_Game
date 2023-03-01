using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    Light li;
    [SerializeField] private GameObject ga;
    Big big;
    //float li;

    // Start is called before the first frame update
    void Start()
    {
        _light = GameObject.Find("Spot Light");
        li = _light.GetComponent<Light>();
        ga = GameObject.Find("Playermono");
        big = ga.GetComponent<Big>();
    }

    // Update is called once per frame
    void Update()
    {

        li.spotAngle = 62.5f;
        
        if(big.BI == true) {
            
            
           
        }
        if(big.BI == false) {
          li.spotAngle = 54.2f;
        }
        if(big.SM == true) {
            li.spotAngle = 42.5f;

        }
        if(big.SM == false) {
            li.spotAngle = 54.2f;
        }
    }
}
