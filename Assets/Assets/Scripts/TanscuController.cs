using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TanscuController : MonoBehaviour
{
    Animator anim;
    Animator anims;
    bool enter = false;
    [SerializeField] private GameObject tansdoor;
    [SerializeField] private GameObject tansdoorone;
    [SerializeField] private GameObject tansdoors;
    [SerializeField] private GameObject tansdoorstwo;
    int simeru;
    BoxCollider door1;
    BoxCollider door2;
    [SerializeField] GameObject pl;
    StarterAssets.ThirdPersonController th;
   bool clo = false;
    bool startwarp = false;
    public bool STWA {
        set {
            this.startwarp = value;
        }
        get {
            return this.startwarp;
        }
    }

    [SerializeField] private GameObject sousa;

    float clotime;
    [SerializeField] private Text doortext;
    // Start is called before the first frame update
    void Start()
    {
        sousa.SetActive(false);
        pl = GameObject.Find("PlayerArmature");
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        //tansdoor = GameObject.Find("BasePointone");
        //tansdoorone = GameObject.Find("Untitled.001");
        door1 = tansdoorone.GetComponent<BoxCollider>();
        anim = tansdoor.GetComponent<Animator>();
        //tansdoors = GameObject.Find("BasePointtwo");
        //tansdoorstwo = GameObject.Find("Untitled.002");
        door2 = tansdoorstwo.GetComponent<BoxCollider>();
        anims = tansdoors.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(clo == true) {
            clotime += Time.deltaTime;
            if(clotime >= 5.0f) { 
            anim.SetBool("door", false);
            anims.SetBool("Opens", false);
            door1.enabled = true;
            door2.enabled = true;
            clo = false;
            clotime = 0;
            }
            
        }
        if(th.FLOOR == true) {
            sousa.SetActive(true);
            doortext.text = "‚Åƒ^ƒ“ƒX‚ðŠJ‚¯‚é";
        }
        
    }

    

    public void OnTriggerStay(Collider col) {
        if(col.tag == "Player") {
            
            if(Gamepad.current.buttonNorth.isPressed) {
                anim.SetBool("door", true);
                anims.SetBool("Opens", true);
                door1.enabled = false;
                door2.enabled = false;
                clo = true;
                startwarp = true;

            }
            
            
        }
    }


}
