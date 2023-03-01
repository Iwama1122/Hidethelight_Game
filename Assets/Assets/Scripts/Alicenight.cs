using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Alicenight : MonoBehaviour
{
    [SerializeField] private GameObject Yes;
    [SerializeField] private GameObject No;
    [SerializeField] private RawImage Yesimage;
    [SerializeField] private RawImage Noimage;
    Vector3 _pmy;
    [SerializeField] private GameObject myme;
    RawImage myarrow;
    bool no = false;
    public static bool _yes = false;
    public static bool _no = false;
    bool yes = false;
    bool yesgoal = false;
    int yescount = 0;
    public bool NO {
        set {
            this.no = value;
        }
        get {
            return this.no;
        }
    }
    public bool YES {
        set {
            this.yes = value;
        }
        get {
            return this.yes;
        }
    }
    public bool YESGOAL {
        set {
            this.yesgoal = value;
        }
        get {
            return this.yesgoal;
        }
    }
    AudioSource nightalice;
    [SerializeField] private AudioClip alicenight;
    // Start is called before the first frame update
    void Start()
    {
        myarrow = myme.GetComponent<RawImage>();
        nightalice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _pmy = this.transform.position;
       
        if(_pmy.y >=  858.39f) {
            if(Gamepad.current.leftStick.down.isPressed) {
                _pmy.y -= 200f;
                this.transform.position = _pmy;
            }
        }
        if(_pmy.y < 860.39f) {
            if(Gamepad.current.leftStick.up.isPressed) {
                _pmy.y += 200f;
                this.transform.position = _pmy;
            }
        }
        if(_pmy.y >= 858.39f) {
            Yesimage.color = new Color32(93,175,178,255);
            Noimage.color = new Color32(111, 106, 106, 255);
            if(Gamepad.current.buttonEast.wasReleasedThisFrame) {
                //yescount++;
                //if(yescount == 2) {
                    nightalice.PlayOneShot(alicenight);
                    StartCoroutine("Transparent");
                   
                //}
            }
        }
        if(_pmy.y < 860.39f) {
            Noimage.color = new Color32(93, 175, 178, 255);
            Yesimage.color = new Color32(111, 106, 106, 255);
            if (Gamepad.current.buttonEast.wasReleasedThisFrame)
            {
                //no = true;
                nightalice.PlayOneShot(alicenight);
                StartCoroutine("Transparents");
            }
        }
    }
    IEnumerator Transparent() {

        int co = 5;
        while(co != 0) {
            for(int i = 0; i < 100; i++) {
                myarrow.color = new Color(255, 255, 255, 0);
            }

            yield return new WaitForSeconds(0.1f);

            for(int k = 0; k < 100; k++) {
                myarrow.color = new Color32(255, 255, 255, 255);
            }

            yield return new WaitForSeconds(0.1f);
            co--;
            //mesh.color = mesh.color - new Color32(0, 0, 0, 0);
        }
        StartCoroutine("Yesanswer");
    }
    IEnumerator Transparents() {

        int co = 5;
        while(co != 0) {
            for(int i = 0; i < 100; i++) {
                myarrow.color = new Color(255, 255, 255, 0);
            }

            yield return new WaitForSeconds(0.1f);

            for(int k = 0; k < 100; k++) {
                myarrow.color = new Color32(255, 255, 255, 255);
            }

            yield return new WaitForSeconds(0.1f);
            co--;
            //mesh.color = mesh.color - new Color32(0, 0, 0, 0);
        }
        StartCoroutine("Noanswer");
    }
    IEnumerator Yesanswer() {
        yield return new WaitForSeconds(1.0f);
      
        yes = true;
        _yes = true;
        yesgoal = true;
    }
    IEnumerator Noanswer() {
        yield return new WaitForSeconds(1.0f);
        no = true;
        _no = true;
    }

}
