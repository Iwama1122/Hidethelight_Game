using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class table : MonoBehaviour
{
    [SerializeField] private Text rousokutext;
    [SerializeField]
    private GameObject ro;
    rousokude r;
    BoxCollider bo;
    [SerializeField] private GameObject  sousa;
    // Start is called before the first frame update
    void Start()
    {
        rousokutext.text = " ";
        ro = GameObject.Find("Rousokumanager");
        r = ro.GetComponent<rousokude>();
        bo = GetComponent<BoxCollider>();
        sousa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (r.LIGHTUP == true)
        {
            bo.enabled = false;
            rousokutext.text = " ";
            sousa.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
            sousa.SetActive(true);
            rousokutext.text = " ‚Å‚ë‚¤‚»‚­‚ðŽæ“¾";
        }
    }

    private void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
            sousa.SetActive(false);
            rousokutext.text = " ";
          
        }
    }
}
