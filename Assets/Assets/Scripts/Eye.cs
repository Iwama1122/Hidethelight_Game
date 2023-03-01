using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Eye : MonoBehaviour
{
    private  bool ey = false; 
    public bool EYE {
        set {
            this.ey = value;
        }
        get {
            return this.ey;
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

    public void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) { 
            if(cas.STOP == false) { 
            ey = true;
            }
            
        }
        
        
    }
}