using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WatchLast : MonoBehaviour
{
    [SerializeField] private GameObject WatchText;
    Text wa;
    [SerializeField] private GameObject searea;
    SwitchCamera sw;
    AudioSource au;
    Animator anim;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    // Start is called before the first frame update
    void Start()
    {
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
       wa = WatchText.GetComponent<Text>();
       sw = searea.GetComponent<SwitchCamera>();
       au = GetComponent<AudioSource>();
       au.mute = true;
       anim = this.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
        
        if(sw.SINDOU == true) { 
        //StartCoroutine("Yre");
        anim.SetBool("watch",true);
            wa.color = new Color(255, 0, 0, 255);
            au.mute = false;
        }
        if(th.WARP == true)
        {
            sw.SINDOU = false;
            anim.SetBool("watch", false);
            wa.color = new Color(0, 0, 0, 255);
            au.mute = true;
        }
    }
    
}
