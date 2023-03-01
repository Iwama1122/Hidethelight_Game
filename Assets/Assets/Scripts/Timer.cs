using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
 
    float watchz = 40;
    Transform watchrotez;
    [SerializeField] private GameObject ma;
    GameManager ga;
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject hourarrow;
    Transform rotehour;
    int timercount = 4;
    // Start is called before the first frame update
    void Start()
    {
        
        rotehour = hourarrow.GetComponent<Transform>();
        watchrotez = this.GetComponent<Transform>();
        watchrotez.localEulerAngles = new Vector3(0, 0, watchz);
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Alicetyutoriaru.gametutorial == false) { 
                if(ga.START == true) {
                    if(cas.STOP == false) {
                        if((int)ga.TIME == timercount) {
                        watchz -= 8f;
                        timercount--;
                        watchrotez.localEulerAngles = new Vector3(0, 0, watchz);
                        }
                        if((int)ga.TIME == 0) {
                        rotehour.localEulerAngles = new Vector3(0, 0, -90);
                    }
                       

                }

                }
                    
        }
            
        
    }
}
