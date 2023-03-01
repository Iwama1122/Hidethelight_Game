using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tyutoriaruhyouji : MonoBehaviour
{
    float scalex;
    float scaley;  
    public GameObject child;
    bool max = false;
    public bool MAX {
        set {
            this.max = value;
        }
        get {
            return this.max;
        }
    }
    float time;
    // Start is called before the first frame update

    void Start()
    {
        child.SetActive(false);
        //float scalex = transform.localScale.x;
        //float scaley = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            child.SetActive(true);
            max = true;
            //time += Time.deltaTime;
        }
        
    }
}
