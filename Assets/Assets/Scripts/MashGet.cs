using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MashGet : MonoBehaviour
{
    [SerializeField] private Text mashText;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    RawImage mash;
    [SerializeField]
    private GameObject child;
    RawImage chmash;
    // Start is called before the first frame update
    void Start()
    {
        mashText = GetComponentInChildren<Text>();
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        mash = GetComponent<RawImage>();
        chmash = child.GetComponentInChildren<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        mashText.text = "Å~" + th.KI;
        if(th.KI <= 0) {
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
