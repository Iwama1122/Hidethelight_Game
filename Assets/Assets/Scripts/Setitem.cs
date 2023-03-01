using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
//using System;

public class Setitem : MonoBehaviour
{
    [SerializeField] private RectTransform[] images;
    float move = 1.5f;
    bool up = false;
    bool down = false;
    int imageslong;
    int pcount = 0;
    [SerializeField] RawImage arrow;
    public bool UP {
        set {
            this.up = value;
        }
        get {
            return this.up;
        }
    }

    public bool DOWN {
        set {
            this.down = value;
        }
        get {
            return this.down;
        }
    }
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject gama;
    GameManager ga;
    Animator itemanim;
    // Start is called before the first frame update
    void Start()
    {
        itemanim = GetComponent<Animator>();
        arrow = GameObject.Find("ItemArrow").GetComponent<RawImage>();
        imageslong = images.Length;
        cas = ca.GetComponent<CameraController>();
        ga = gama.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
       if(ga.START == true){  
         if(cas.STOP == false) { 
        if(Gamepad.current.buttonWest.wasReleasedThisFrame) {
            arrow.enabled = true;
                pcount++;
            up = true;
            down = false;
        }
        if(pcount == 2) {
            up = false;
            down = true;
            pcount = 0;
        }

        if(up == true) {
            itemanim.SetBool("item",true);
            //Idouup(move, imageslong);
        }
        if(down == true) {
            //Idoudown(move, imageslong);
                    itemanim.SetBool("item", false);
                }
            }
        }
    }

    public void Idouup(float move,int imagelong) {
        if(images[imagelong - 4].localPosition.y < 
            130f && images[imagelong - 1].localPosition.y > -130f) {
            images[imagelong - 4].localPosition += new Vector3(0, move, 0);
            images[imagelong - 1].localPosition += new Vector3(0, -move, 0);
        }
        if(images[imagelong - 3].localPosition.x <
            900f && images[imagelong - 2].localPosition.x > -900f) {
            images[imagelong - 3].localPosition += new Vector3(move, 0, 0);
            images[imagelong - 2].localPosition += new Vector3(-move,0, 0);
        }


    }
    public void Idoudown(float move, int imagelong) {
        if(images[imagelong - 4].localPosition.y >
            0 && images[imagelong - 1].localPosition.y < 0) {
            images[imagelong - 4].localPosition -= new Vector3(0, move, 0);
            images[imagelong - 1].localPosition -= new Vector3(0, -move, 0);
        }
        if(images[imagelong - 3].localPosition.x >
            -772.9f && images[imagelong - 2].localPosition.x < 772.9f) {
            images[imagelong - 3].localPosition -= new Vector3(move, 0, 0);
            images[imagelong - 2].localPosition -= new Vector3(-move, 0, 0);
        }
    }
}
