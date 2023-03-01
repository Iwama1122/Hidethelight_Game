using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tansuexit : MonoBehaviour
{
    [SerializeField] private Text doortext;
    [SerializeField] private GameObject sousa;
    // Start is called before the first frame update
    void Start()
    {
     sousa.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
            sousa.SetActive(true);
            doortext.text = "‚Åƒ^ƒ“ƒX‚ðŠJ‚¯‚é";
        }
    }
    public void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
            sousa.SetActive(false);
            doortext.text = " ";
        }
    }
}
