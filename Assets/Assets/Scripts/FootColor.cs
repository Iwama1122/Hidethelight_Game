using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FootColor : MonoBehaviour
{
    [SerializeField] private Material ma;
    [SerializeField] private Material mas;
    [SerializeField] private GameObject ItemCount;
    hyoujisroto hyouji;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject mane;
    GameManager ga;
    //[SerializeField] private GameObject body;
    //BodyColorChange by;
    Renderer my;
    //[SerializeField] private 
    
    bool changecolor = false;
    float cotime;
    // Start is called before the first frame update
    void Start()
    {
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        hyouji = ItemCount.GetComponent<hyoujisroto>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
        mane = GameObject.Find("GameManager");
        ga = mane.GetComponent<GameManager>();
        //by = body.GetComponent<BodyColorChange>();
        my = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Material[] mats = my.materials;
        if(cas.STOP == false) { 
            //if(hyouji.COUNT == 4) {
            
            if(th.CATPUSH == true && th.CAT != 0) {
                //by.TOUMEI = true;
                
                mats[2] = mas;
                my.materials = mats;
                changecolor = true;
            }
            if(changecolor == true) {
                cotime += Time.deltaTime;
                if(cotime >= 10) {
                    th.CATPUSH = false;
                    changecolor = false;
                    mats[2] = ma;
                    my.materials = mats;
                    cotime = 0;
                }
            //}
            }
        }
    }
}
