using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class kaitenn : MonoBehaviour
{
    RectTransform rect;
    float rotation = 0;
    RawImage arrow;
    Setitem se;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        arrow = GetComponent<RawImage>();
        se = GameObject.Find("ItemShotCut_Menu").GetComponent<Setitem>();
        arrow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(se.DOWN == true) {
            arrow.enabled = false;
        }
        if(se.UP == true) {
            if(Gamepad.current.rightShoulder.wasReleasedThisFrame) {
                //arrow.enabled = true;
                rotation -= 72;
                rect.localRotation = Quaternion.Euler(0, 0, rotation);

            }
        }
    }
}
