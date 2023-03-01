using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scaleimage : MonoBehaviour
{
    Tyutoriaruhyouji ty;
    RectTransform w;
    int speed = 1;
    //RectTransform h;
    // Start is called before the first frame update
    void Start()
    {
        w = GetComponent<RectTransform>();
        //h = GetComponent<RectTransform>();
        ty = GetComponentInParent<Tyutoriaruhyouji>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ty.MAX == true) {
            if(w.localScale.x <= 2 && w.localScale.y <= 2) { 
            this.transform.localScale += new Vector3(w.localScale.x + speed, w.localScale.y +speed , 1);
            } else {
                ty.MAX = false;
            }
        }
    }
}
