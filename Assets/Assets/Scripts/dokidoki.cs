using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class dokidoki : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    private GameObject kaku;
    kakureru ka;
    //public AudioClip sound1;
    AudioSource audioSource;
    bool ha = false;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        kaku = GameObject.Find("kakure");
        ka = kaku.GetComponent<kakureru>();
        animator = GetComponent<Animator>();
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
       if(th.GAMEOVER == true) {
            audioSource.mute = true;
        }
        if (ha == true)
        {
            audioSource.mute = false;
            ha = false;
        }

       
        if (ka.TENMETU == true)
        {
            ha = true;
            animator.SetBool("hart", true);
        }
       else if(ka.TENMETU == false)
        {
            //audioSource.Stop();
            //audioSource.mute = audioSource.mute;
            audioSource.mute = true;
            animator.SetBool("hart", false);
        }
    }
}
