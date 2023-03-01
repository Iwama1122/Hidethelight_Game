using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnknownText : MonoBehaviour
{
    [SerializeField] private Text Unknowntext;
    // Start is called before the first frame update
    void Start()
    {
        Unknowntext.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
            Unknowntext.text = "‚È‚ñ‚©‰ö‚µ‚¢‚È?";
        }
    }

    public void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
            Unknowntext.text = " ";
        }
    }
}
