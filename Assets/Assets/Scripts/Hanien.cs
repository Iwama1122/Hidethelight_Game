using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanien : MonoBehaviour
{
    Rigidbody ri;
    SphereCollider sp;
    Vector3 mysize;
    Vector3 mysizes;
    bool size = false;
    float sizetime;
    float sizex;
    
    [SerializeField] private Material ma;
    [SerializeField] private Material mas;
    [SerializeField] private GameObject paret;
    TwinEnemy tw;
    bool circle = false;
    // Start is called before the first frame update
    void Start()
    {
        ri = GetComponent<Rigidbody>();
        sp = GetComponent<SphereCollider>();
        mysize = transform.localScale;
        ri.isKinematic = true;
        sp.enabled = false;
        this.GetComponent<Renderer>().material = ma;
        tw = paret.GetComponent<TwinEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
     
        mysizes = transform.localScale;
        sizex = mysizes.x;
        if(tw.HUTAGO == true) {
            this.GetComponent<Renderer>().material = mas;
            size = true;
            tw.HUTAGO = false;
        }
        if(size == true) {
            //sizetime += Time.deltaTime;
            ri.isKinematic = false;
            sp.enabled = true;
            Large();
        }

            if(sizex >= 30.0f) {
                transform.localScale =
          new Vector3(mysizes.x, mysizes.y , mysizes.z);
            
            circle = true;
            
        }
            if(circle == true) {
            sizetime += Time.deltaTime;
            if(sizetime >= 3.0f) { 
            this.GetComponent<Renderer>().material = ma;
            transform.localScale = mysize;
                size = false;
                ri.isKinematic = true;
            sp.enabled = false;
            //tw.HUTAGO = false;
                circle = false;
            sizetime = 0;
            }
        }

        

    }

    public void Large() {
          transform.localScale += 
          new Vector3(mysizes.x*Time.deltaTime,mysizes.y * Time.deltaTime, mysizes.z * Time.deltaTime);
    }
}
