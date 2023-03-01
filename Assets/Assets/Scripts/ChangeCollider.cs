using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCollider : MonoBehaviour
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
        bo.size = new Vector3(7.85f,0.75f,1.42f);
    }

    // Update is called once per frame
    void Update()
    {
        if(bi.BI == true) {
            bo.size = new Vector3(67.3f, 0.75f, 71f);
        } else {
            bo.size = new Vector3(7.85f, 0.75f, 1.42f);
        }
    }
}
