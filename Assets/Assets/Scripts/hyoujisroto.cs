using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class hyoujisroto : MonoBehaviour
{
    [SerializeField] private RawImage[] raw;
    [SerializeField] private Text[] rawtext;
    [SerializeField] private RawImage[] rawchild;
    int counts = 0;
    public int COUNT {
        set {
            this.counts = value;
        }
        get {
            return this.counts;
        }
    }
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject gama;
    GameManager ga;
    Setitem se;
    // Start is called before the first frame update
    void Start()
    {
        cas = ca.GetComponent<CameraController>();
        ga= gama.GetComponent<GameManager>();
        se = GameObject.Find("ItemShotCut_Menu").GetComponent<Setitem>();
        raw[0].enabled = true;
        rawtext[0].enabled = true;
        rawchild[0].enabled = true;
        for(int i = 1; i < raw.Length; i++) {
            
            raw[i].enabled = false;
        }
        for(int i = 1; i < raw.Length; i++) {

            rawchild[i].enabled = false;
        }
        for(int i = 1; i < raw.Length; i++) {

            raw[i].enabled = false;
        }
        for(int i = 1; i < raw.Length; i++) {

            rawtext[i].enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
   
        if(ga.START == true) { 
            if(cas.STOP == false) { 
            if(se.UP == true) { 
               if(Gamepad.current.rightShoulder.wasReleasedThisFrame) {
           
                    counts++;//1234
                    if(counts == 5) {
                    nothyouji(counts);
                    counts = 0;

                     }
                hyouji(counts);//0123
                }

              }
            }
        }
    }
    public void hyouji(int count) {
        raw[count].enabled = true;
        rawchild[count].enabled = true;
        rawtext[count].enabled = true;
    }

    public void nothyouji(int count) {

            raw[count - 5].enabled = false;
            raw[count-4].enabled = false;
            raw[count-3].enabled = false;
            raw[count- 2].enabled = false;
            raw[count-1].enabled = false;
            rawchild[count - 5].enabled = false;
            rawchild[count - 4].enabled = false;
            rawchild[count - 3].enabled = false;
            rawchild[count - 2].enabled = false;
            rawchild[count - 1].enabled = false;
        rawtext[count - 5].enabled = false;
        rawtext[count - 4].enabled = false;
        rawtext[count - 3].enabled = false;
        rawtext[count - 2].enabled = false;
        rawtext[count - 1].enabled = false;
    }
    
}
