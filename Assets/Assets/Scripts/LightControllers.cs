using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControllers : MonoBehaviour
{
    Light li;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    float lightx = -22.22f;
   bool lights = false;
    // Start is called before the first frame update
    void Start()
    {
  
        
       
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        li = this.GetComponent<Light>();
      
    }

    // Update is called once per frame
    void Update()
    {
        float y = this.transform.rotation.y;
        float z = this.transform.rotation.z;
        if(th.WARPDO == true) {
            transform.rotation = Quaternion.Euler(50, y, z);
            li.color = new Color32(255, 244, 214, 255);
            
        }
        if(lights == false && th.WARPDO == false) {
            transform.rotation = Quaternion.Euler(lightx, y, z);
            li.color = new Color32(58, 46, 46, 255);
        }
        //ここでワープ先にいったらのフラグがtrueだったらで
        //角度はあとで調整する
        if(th.WARP == true ) { 
          lights = true;
        }
        if(lights == true) {
            transform.rotation = Quaternion.Euler(50, y, z);
            li.color = new Color32(255, 244, 214, 255);
           // light = false;
        }
       
    }
}
