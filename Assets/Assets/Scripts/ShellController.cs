using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShellController : MonoBehaviour
{
    [SerializeField] private GameObject plbig;
    Big big;
    Animator shell;
    [SerializeField] private GameObject kakure;
    Leefkakureru nu;
    bool nukeru = false;
    int count = 0;
    [SerializeField] private Text kaitext;
    [SerializeField] private GameObject icon;
    // Start is called before the first frame update
    void Start()
    {
        icon.SetActive(false);
        kaitext.text = " ";
        big = plbig.GetComponent<Big>();
        shell = this.GetComponent<Animator>();
        nu = kakure.GetComponent<Leefkakureru>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Gamepad.current.buttonEast.wasReleasedThisFrame && nu.KAKURERU == true) {
            count++;
            if(count == 1) {
                icon.SetActive(true);
                kaitext.text = "  Ç≈èoÇÈ";
                shell.SetBool("Shell",true);
            //nukeru = true;
                
            }
            if(count == 2) {
                shell.SetBool("Shell", false);
                count = 0;
                //nukeru = false;
            }
        }
        
    }
}
