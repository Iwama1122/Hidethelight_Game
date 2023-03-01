using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shorudercollider : MonoBehaviour
{
    bool shoruder = false;
    public bool SHORUDER {
        set {
            this.shoruder = value;
        }
        get {
            return this.shoruder;
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

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            shoruder = true;
        }
    }
}
