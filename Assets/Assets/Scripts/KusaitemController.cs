using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KusaitemController : MonoBehaviour
{
    [SerializeField]
    private GameObject icon;
    [SerializeField] private Text kusatext;
    // Start is called before the first frame update
    void Start()
    {
        icon.SetActive(false);
        kusatext.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
            icon.SetActive(true);
            kusatext.text = "  ‚Å‰B‚ê‚é";
        }
    }

    private void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
            icon.SetActive(false);
            kusatext.text = " ";
        }
    }

}
