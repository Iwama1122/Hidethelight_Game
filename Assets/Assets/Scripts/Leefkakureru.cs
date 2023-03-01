using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leefkakureru : MonoBehaviour
{
    bool kakureteiru = false;
    bool hanareru = false;
    public bool KAKURERU {
        set {
            this.kakureteiru = value;
        }
        get {
            return this.kakureteiru;
        }
    }
    public bool HANARERU {
        set {
            this.hanareru = value;
        }
        get {
            return this.hanareru;
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
    void OnTriggerStay(Collider col) {
        if(col.tag == "Player") {

            kakureteiru = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
            kakureteiru = false;
            hanareru = true;
        }
    }
}
