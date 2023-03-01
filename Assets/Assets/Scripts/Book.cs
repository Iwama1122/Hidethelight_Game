using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Book : MonoBehaviour
{
   
    [SerializeField] private Text booktext;
    bool bookOpen = false;
    [SerializeField] private GameObject openpage;
    [SerializeField] private GameObject sousa;
   
    public bool BOOK {
        set {
            this.bookOpen = value;
        }
        get {
            return this.bookOpen;
        }
    }
   bool count = false;
    // Start is called before the first frame update
    void Start()
    {
        sousa.SetActive(false);
        booktext.text = " ";
        openpage.SetActive(false);
        //open.mute = true;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider col) {
        if(col.tag == "Player") {
            sousa.SetActive(true);
            booktext.text = "  ‚Å–{‚ðŠJ‚­";
            if(Gamepad.current.buttonNorth.isPressed) {
                bookOpen = true;
                openpage.SetActive(true);
                StartCoroutine("OpenMusic");
            }
            
        }
    }


    private void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
            sousa.SetActive(false);
            booktext.text = " ";
            
        }
    }
    
    IEnumerator OpenMusic() {
        yield return new WaitForSeconds(1.0f);
        openpage.SetActive(false);
    }
 
}
