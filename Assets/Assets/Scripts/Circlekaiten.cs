using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circlekaiten : MonoBehaviour
{
   
    float z;
    float kaitenspeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
        z = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0, 0, z) * kaitenspeed);
    }
}
