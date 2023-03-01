using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildJump : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = this.transform.position.y;
        if(y > 2f) {
            transform.position += transform.up;
        } 
        else{
            transform.position -= transform.up;
            if(y <= 0f) {
                transform.position = this.transform.position;
            }
        }


    }
    
}
