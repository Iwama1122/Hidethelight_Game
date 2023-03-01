using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Childeye : MonoBehaviour
{
    bool seiuch = false;
    public bool SEIUCH {
        set {
            this.seiuch = value;
        }
        get {
            return this.seiuch;
        }
    }
    bool alice = false;
    public bool ALICE {
        set {
            this.alice = value;
        }
        get {
            return this.alice;
        }
    }
    CameraController cas;
    // Start is called before the first frame update
    void Start()
    {
        cas = GameObject.Find("MainCamera").GetComponent<CameraController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player") {
            alice = true;
        }
        if(other.tag == "Enemy") {
            seiuch = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            alice = false;
        }
    }
}
