using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BodyColorChange : MonoBehaviour
{
    [SerializeField] private Material ma;
    [SerializeField] private Material mas;
    [SerializeField] private GameObject kumo;
    [SerializeField] private GameObject ItemCount;
    hyoujisroto hyouji;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject mane;
    GameManager ga;
    
    bool toumei = false;
    bool efstart = false;
    bool efend = false;

    public bool TOUMEI {
        set {
            this.toumei = value;
        }
        get {
            return this.toumei;
        }
    }
    float toumeitime;
    float retoumeitime;
    // Start is called before the first frame update
    void Start()
    {
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        kumo.SetActive(false);
        hyouji = ItemCount.GetComponent<hyoujisroto>();
        
        this.GetComponent<Renderer>().material = ma;
        
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
        mane = GameObject.Find("GameManager");
        ga = mane.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("“§–¾ŽžŠÔ "+th.CATTIME);
        if(ga.START == true) {
            if(cas.STOP == false) {
                //if(hyouji.COUNT == 4) {
                    if(th.CATPUSH == true && th.CAT != 0) {
                        toumei = true;
                        
                        this.GetComponent<Renderer>().material = mas;
                       
                        kumo.SetActive(true); 
                        efstart = true;
                     }
                     if(efstart == true) 
                        {
                            //toumeitime += Time.deltaTime;
                            if(th.CATTIME >= 1) {
                                kumo.SetActive(false);
                            }
                            if(th.CATTIME >= 9.9) 
                                {
                                    this.GetComponent<Renderer>().material = ma;
                                    kumo.SetActive(true);
                                    th.CATPUSH = false;
                                    toumei = false;
                                    efstart = false;
                                    efend = true;
                                    //toumeitime = 0;
                                }
                            
                        }
                        if(efend == true) {
                            retoumeitime += Time.deltaTime;
                            if(retoumeitime >= 1) {
                               kumo.SetActive(false);
                                efend = false;
                                retoumeitime = 0;
                            }
                        }
                    
                //}
                
                
             } 
            if(cas.STOP == true) {
                kumo.SetActive(false);
            }
            
        }
    }
}
