using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hairu : MonoBehaviour
{
    bool hairuyo = false;
    public bool HAIRU {
        set {
            this.hairuyo = value;
        }
        get {
            return this.hairuyo;
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
            hairuyo = true;
        }
    }
}
