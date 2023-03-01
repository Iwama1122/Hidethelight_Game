using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sutamina : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    [SerializeField]
    private GameObject player;
    StarterAssets.ThirdPersonController su;
    [SerializeField]
    private GameObject fil;
     Image fill;
    [SerializeField] private GameObject ma;
    GameManager ga;
    [SerializeField] private GameObject ca;
    CameraController cas;
    bool sutaminazero = false;

    public bool SUTA {
        set {
            this.sutaminazero = value;
        }
        get {
            return this.sutaminazero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1000;
        player = GameObject.Find("PlayerArmature");
        su = player.GetComponent<StarterAssets.ThirdPersonController>();
        fil = GameObject.Find("Fill");
        fill = fil.GetComponent<Image>();
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
      if(ga.START == true ) {
        if(cas.STOP == false) {
          if(su.SU == true) {
            slider.value-=0.8f;
        } else {
            slider.value += 0.8f;
        }
        if(slider.value <= 200) {
            fill.color = new Color32(255,0,0,255);
        } else {
            fill.color = new Color32(255, 255, 0, 255);
        }
        if(slider.value <= 0) {
            sutaminazero = true;
        } else {
            sutaminazero = false; 
        }
      }
        }
    }
}
