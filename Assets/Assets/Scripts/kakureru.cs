using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kakureru : MonoBehaviour
{
    [SerializeField] private GameObject player;
    StarterAssets.ThirdPersonController pl;
    bool tenmetu = false;
    bool twin = false;
    public bool TENMETU
    {
        set
        {
            this.tenmetu = value;
        }
        get
        {
            return this.tenmetu;
        }
    }

    public bool TWIN {
        set {
            this.twin = value;
        }
        get {
            return this.twin;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerArmature");
        pl = player.GetComponent<StarterAssets.ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider col)
    {
        //if(pl.DOA == true)
        //{
            if (col.tag == "Enemy")//本来はenemyにする
            {
                tenmetu = true;
            }
            if(col.tag == "Twins")//本来はenemyにする
            {
               twin = true;
            }
       
    }

    public void OnTriggerExit(Collider col)
    {
        //if (pl.DOA == true)
        //{
            if (col.tag == "Enemy")//本来はenemyにする
            {
                tenmetu = false;
            }
            if(col.tag == "Twins")//本来はenemyにする
            {
                twin = false;
             }
        //}
    }
}
