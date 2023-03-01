using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkCountGet : MonoBehaviour
{
    [SerializeField] private Text mashText;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    RawImage mash;
    [SerializeField]
    private GameObject child;
    RawImage chmash;
    [SerializeField] private GameObject hyy;
    hyoujisroto hyou;
    // Start is called before the first frame update
    void Start()
    {
        mashText = GetComponentInChildren<Text>();
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        mash = GetComponent<RawImage>();
        chmash = child.GetComponentInChildren<RawImage>();
        hyou = hyy.GetComponent<hyoujisroto>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hyou.COUNT == 2) {
            mashText.text = "Å~" + th.DRINK;
        } else {
            mashText.text = " ";
        }
        
        if(th.DRINK <= 0) {
            mash.color = new Color32(100, 100, 100, 255);
            chmash.color = new Color32(100, 100, 100, 255);
            mashText.color = new Color32(255, 0, 0, 255);
            
        } else {
            mash.color = new Color32(255, 255, 255, 255);
            chmash.color = new Color32(255, 255, 255, 255);
            mashText.color = new Color32(255, 241, 0, 255);
        }
    }
}
