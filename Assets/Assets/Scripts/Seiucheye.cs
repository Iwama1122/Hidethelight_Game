using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seiucheye : MonoBehaviour
{
    bool child = false;
    public bool CHILDSE {
        set {
            this.child = value;
        }
        get {
            return this.child;
        }
    }
    bool seplayer = false;
    public bool SEPLAYER {
        set {
            this.seplayer = value;
        }
        get {
            return this.seplayer;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "Child") {
            child = true;
        }
        if(col.tag == "Player") {
            seplayer = true;
        }
    }
}
