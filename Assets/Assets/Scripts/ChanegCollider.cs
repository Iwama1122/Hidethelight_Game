using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanegCollider : MonoBehaviour
{
    BoxCollider bo;
    [SerializeField] private GameObject plg;
    Big bi;
    // Start is called before the first frame update
    void Start()
    {
        bo = this.GetComponent<BoxCollider>();
        plg = GameObject.Find("Playermono");
        bi = plg.GetComponent<Big>();
        bo.size =new Vector3(2.3f,2.05f,2.47f);
    }

    // Update is called once per frame
    void Update()
    {
        if(bi.BI == true) {
            bo.size = new Vector3(76.36f, 2.05f, 59.46f);
        } else {
            bo.size = new Vector3(2.3f, 2.05f, 2.47f);
        }
    }
}
