using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatGet : MonoBehaviour
{
    [SerializeField] private Text mashText;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    RawImage cat;
    RawImage _cat;
    [SerializeField]
    private GameObject catimage;
    // Start is called before the first frame update
    void Start()
    {
        mashText = GetComponentInChildren<Text>();
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        cat = GetComponent<RawImage>();
        _cat = catimage.GetComponentInChildren<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        mashText.text = "Å~" + th.CAT;

        if(th.CAT <= 0) {
            cat.color = new Color32(100, 100, 100, 255);
            _cat.color = new Color32(100, 100, 100, 255);
            mashText.color = new Color32(255, 0, 0, 255);

        } else {
            cat.color = new Color32(255, 255, 255, 255);
            _cat.color = new Color32(255, 255, 255, 255);
            mashText.color = new Color32(255, 241, 0, 255);
        }
    }
}
