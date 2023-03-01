using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    bool whstop = false;
    public bool WHSTOP {
        set {
            this.whstop = value;
        }
        get {
            return this.whstop;
        }
    }

    [SerializeField] private GameObject eye;
    SphereCollider ey;
    [SerializeField] private GameObject plg;
    Big bi;
    BoxCollider bo;
    [SerializeField] private GameObject plbody;
    BodyColorChange body;
    // Start is called before the first frame update
    void Start()
    {
        body = plbody.GetComponent<BodyColorChange>();
        plg = GameObject.Find("Playermono");
        bi = plg.GetComponent<Big>();
        ey = eye.GetComponent<SphereCollider>();
        bo = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(body.TOUMEI == false) {
            ey.enabled = true;
            bo.enabled = true;
        }
        if(body.TOUMEI == true) {
            ey.enabled = false;
            bo.enabled = false;
        }

        if(bi.SM == true) {
            ey.enabled = false;
            bo.enabled = false;
        }
        if(bi.SM == false) {
            ey.enabled = true;
            bo.enabled = true;
        }
    }

    public void OnTriggerEnter(Collider col) {
        if(col.tag == "White") {
            whstop = true;
        }
      
    }
}
