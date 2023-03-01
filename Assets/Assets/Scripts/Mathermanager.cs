using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mathermanager : MonoBehaviour
{
    [SerializeField] private GameObject seiuch;
    [SerializeField]
    private GameObject seikuti;
    Seiucheat seeat;
    [SerializeField] private GameObject mather;
    [SerializeField] private GameObject player;
    StarterAssets.ThirdPersonController th;
    int allchildcount = 0;
    [SerializeField] private GameObject kyuhutext;
    // Start is called before the first frame update
    void Start()
    {
        kyuhutext.SetActive(false);
        seiuch.SetActive(true);
        seeat = seikuti.GetComponent<Seiucheat>();
        mather.SetActive(false);
        th = player.GetComponent<StarterAssets.ThirdPersonController>();
        
    }

    // Update is called once per frame
    void Update()
    {
       

        allchildcount = th.CHILDCOUNT + seeat.EATCOUNT/2;
        if(th.SEA == true) {
            if(allchildcount >= 5) {
                kyuhutext.SetActive(true);
            }

            if(allchildcount >= 10) {
                seiuch.SetActive(false);
                mather.SetActive(true);
                kyuhutext.SetActive(false);
            }
        }
        else {
            kyuhutext.SetActive(false);
        }
        
    }
}
