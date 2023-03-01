using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFlower : MonoBehaviour
{
    
    float whtime;
    bool wh = false;
    [SerializeField] private GameObject whriaru;
    Renderer re;
    float red = 255f;
    float green = 255f;
    float blue = 255f;
    [SerializeField] private GameObject whflower;
    // Start is called before the first frame update
    void Start()
    {
        re = whriaru.GetComponent<Renderer>();
        whtime = 0;
        wh = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wh == true) {//5•bŒãÁ‚¦‚é‚æ‚¤‚É
            whtime += Time.deltaTime;
            if(whtime >= 5.0f) {
                Destroy(whflower);
                wh = false;
                whtime = 0;
            }
        }
    }

    public void OnTriggerStay(Collider col) {
        if(col.tag == "Enemy") {//F•ÏX‚·‚é
            re.material.color = new Color(red,green,blue);
            if(green >= 0 && blue >= 0) {
                green -= 1f;
                blue -= 1f;
                re.material.color = new Color(red / 255, green / 255, blue / 255);
                wh = true;
            }
            
        }
    }
}
