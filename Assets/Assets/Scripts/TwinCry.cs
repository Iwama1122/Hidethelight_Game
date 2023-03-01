using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinCry : MonoBehaviour
{
    AudioSource cry;
    // Start is called before the first frame update
    void Start()
    {
        cry.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
            cry.mute = false;
        }
    }
    private void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
            cry.mute = true;
        }
    }
}
