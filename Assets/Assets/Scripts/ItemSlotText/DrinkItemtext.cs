using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkItemtext : MonoBehaviour
{
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    Text mytext;
    // Start is called before the first frame update
    void Start()
    {
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        mytext = GetComponent<Text>();
        mytext.color = new Color(0, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        mytext.text = "Å~" + th.DRINK;
        if(th.DRINK <= 0) {
            mytext.color = new Color(0, 0, 0, 255);
        } else {
            mytext.color = new Color(255, 0, 0, 255);
        }
    }
}
