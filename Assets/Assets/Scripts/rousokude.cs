using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rousokude : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject fires;
    bool lightup = false;
    [SerializeField]
    private GameObject player;
    StarterAssets.ThirdPersonController bg;
    public bool LIGHTUP {
        set {
            this.lightup = value;
        }
        get {
            return this.lightup;
        }
    }
    [SerializeField] private GameObject tyumane;
    TyutorialManager tyuma;
    bool t = false;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
       tyuma = tyumane.GetComponent<TyutorialManager>();
        fire.SetActive(false);
        fires.SetActive(true);
        player = GameObject.Find("PlayerArmature");
        bg = player.GetComponent<StarterAssets.ThirdPersonController>();
    }

    // Update is called once per frame
    void Update() {
        if(Gamepad.current.buttonNorth.wasReleasedThisFrame && bg.TABLE == true) {
           
            fire.SetActive(true);
            fires.SetActive(false);
            lightup = true; 
            bg.TABLE = false;
            if(count != 1) { 
            if (Alicetyutoriaru.gametutorial == true)
            {
                    count = 1;
                    t = true;
                
            }
            if(t == true)
            {
                tyuma.TYUCOUNT = true;
                t = false;
            }
            }
        }
    }
}
