using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seiucheat : MonoBehaviour
{
    [SerializeField] private GameObject eat;
    Animator seeat;
    [SerializeField]
    private GameObject seeye;
    Seiucheye se;
    int eatcount = 0;
    bool eats = false;
    public int EATCOUNT {
        set {
            this.eatcount = value;
        }
        get {
            return this.eatcount;
        }
    }
    public bool EAT {
        set {
            this.eats = value;
        }
        get {
            return this.eats;
        }
    }
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    // Start is called before the first frame update
    void Start()
    {
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        seeat = eat.GetComponent<Animator>();
        se = seeye.GetComponent<Seiucheye>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "Child") {
            if(th.SEA == true) { 
            seeat.SetBool("moause",true);
            col.gameObject.SetActive(false);
            eatcount++;
            eats = true;
            }
            //se.CHILDSE = false ;
        } 
    }
    private void OnTriggerExit(Collider col) {
        if(col.tag == "Child") {
            if(th.SEA == true) {
                seeat.SetBool("moause", false);
            }
        }
    }
}
