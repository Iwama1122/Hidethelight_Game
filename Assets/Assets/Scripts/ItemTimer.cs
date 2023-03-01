using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTimer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    StarterAssets.ThirdPersonController th;
    [SerializeField] private GameObject biger;
    Big big;
    [SerializeField] private GameObject[] itemicon;
    int itemlength;
    [SerializeField] private GameObject mashtext;
    [SerializeField] private GameObject childtext;
    [SerializeField] private GameObject cattext;
    Text matext;
    Text chtext;
    Text catext;
    float bigtime;
    float speedtime;
    float cattime;
    // Start is called before the first frame update
    void Start()
    {
        matext = mashtext.GetComponent<Text>();
        chtext = childtext.GetComponent<Text>();
        catext = cattext.GetComponent<Text>();
        itemlength = itemicon.Length;
        for(int i = 0; i < itemlength; i++) {
            itemicon[i].SetActive(false);
        }
        th = player.GetComponent<StarterAssets.ThirdPersonController>();
        big = biger.GetComponent<Big>();
    }

    // Update is called once per frame
    void Update()
    {
        if(big.BI == true) {
            itemicon[0].SetActive(true);
            bigtime = (int)big.BIGTIME;
            matext.text = bigtime.ToString() + "•b";
        } else {
            itemicon[0].SetActive(false);
            matext.text = " ";
        }

        if(th.SPUP == true) {
            itemicon[1].SetActive(true);
            speedtime = (int)th.SPEEDTIME;
            chtext.text = speedtime.ToString() + "•b";
        } else {
            itemicon[1].SetActive(false);
            chtext.text = " ";
        }

        if(th.CATPUSH == true) {
            itemicon[2].SetActive(true);
            cattime = (int)th.CATTIME;
            catext.text = cattime.ToString() + "•b";
        } else {
            itemicon[2].SetActive(false);
            catext.text = " ";
        }

    }

    
}
