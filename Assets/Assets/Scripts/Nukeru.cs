using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nukeru : MonoBehaviour
{
    bool nukeru = false;
    public bool NUKERU {
        set {
            this.nukeru = value;
        }
        get {
            return this.nukeru;
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

 

    void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
            nukeru = true;
        }
    }
}
