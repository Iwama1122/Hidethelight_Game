using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CupController : MonoBehaviour
{
    [SerializeField] private GameObject plbig;
    Big big;
    Animator cup;
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
        cup = this.GetComponent<Animator>();
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
                cup.SetBool("Cup", true);
                //nukeru = true;

            }
            if(count == 2) {
                cup.SetBool("Cup", false);
                count = 0;
                //nukeru = false;
            }
        }
    }
}
