using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildCollision : MonoBehaviour
{
    [SerializeField] private Text childtext;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject seiteki;
    Seiucheat sei;
    [SerializeField] private GameObject my;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    // Start is called before the first frame update
    void Start()
    {
        sei = seiteki.GetComponent<Seiucheat>();
        childtext.text = " ";
        icon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
    }

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
            if(th.SEA == true) { 
            icon.SetActive(true);
            childtext.text = "  ‚ÅŽæ‚é ";
            }
        }
        if(col.tag == "Seiuch") {
            if(th.SEA == true) { 
            sei.EATCOUNT++;
            my.SetActive(false);
            }
        }
    }
    private void OnTriggerStay(Collider col) {
        if(col.tag == "Seiuch") {
            if(th.SEA == true) {
                sei.EATCOUNT++;
                my.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
            if(th.SEA == true) { 
            icon.SetActive(false);
            childtext.text = " ";
            }
        }
    }
}
