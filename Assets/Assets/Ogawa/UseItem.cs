using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    //主人公のスクリプト
    public bool WhiteRose = false;
    public bool Mushroom = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Mushroom")
            Mushroom = true;
        if(collision.gameObject.tag == "WhiteRose")
            WhiteRose = true;
    }

    
}
