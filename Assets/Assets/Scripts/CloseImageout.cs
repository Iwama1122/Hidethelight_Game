using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseImageout : MonoBehaviour
{
    Image myimage;
    float alpha;
    // Start is called before the first frame update
    void Start()
    {
        myimage = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alpha <= 255) {
            alpha += Time.deltaTime/2;
            myimage.color = new Color(0,0,0,alpha);
        }
    }
}
