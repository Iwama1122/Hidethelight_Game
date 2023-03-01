using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Text etext;
    [SerializeField] private GameObject sousa;
    // Start is called before the first frame update
    void Start()
    {
        etext.text = " ";
        sousa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
            sousa.SetActive(true);
            etext.text = "  ‚ÅŽæ‚é ";
        }
    }
    private void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
            sousa.SetActive(false);
            etext.text = " ";
        }
    }
}
