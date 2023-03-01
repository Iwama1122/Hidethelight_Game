using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AliceOverarrow : MonoBehaviour
{
    [SerializeField] private GameObject botton;
    [SerializeField] private GameObject botton1;
    [SerializeField] private GameObject botton2;
  
    Vector3 bo;//選択1
    Vector3 bo1;//選択2
    Vector3 bo2;//選択3
  
    Vector3 my;
    Vector3 mycopy;//次のシーンまたはワイプが出される前の押したボタンの位置
    [SerializeField]
    private GameObject myme;
    RawImage myarrow;
    bool osita = false;
    bool moidou = false;
    bool overtitle = false;
    public bool OVERTITLE {
        set {
            this.overtitle = false;
        }
        get {
            return this.overtitle;
        }
    }
    AudioSource aliceover;
    [SerializeField] private AudioClip overalice;
    // Start is called before the first frame update
    void Start()
    {
        aliceover = GetComponent<AudioSource>();
        bo = botton.transform.position;
        bo1 = botton1.transform.position;
        bo2 = botton2.transform.position;
        this.transform.position = new Vector3(bo.x - 260f, bo.y, 0);
        myarrow = myme.GetComponent<RawImage>();
        myarrow.color = new Color32(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        my = this.transform.position;
        if(osita == false) {
            if(my.y < bo.y) {
                if(Gamepad.current.leftStick.up.wasReleasedThisFrame) {//Gamepad.current.dpad.down.wasReleasedThisFrame
                    my.y += 182.0f;
                    transform.position = my;
                }
            }
            if(my.y > 209.35f){
                if(Gamepad.current.leftStick.down.wasReleasedThisFrame) {//Gamepad.current.dpad.up.wasReleasedThisFrame
                    my.y -= 182.0f;
                    transform.position = my;
                }
            }

            if(my.y == bo.y) {
               if(AliceCursoleStage.stagecount == 1) { 
                if(Gamepad.current.buttonEast.isPressed) {
                        overtitle = true;
                        StartCoroutine("Transparent");
                    osita = true;
                    aliceover.PlayOneShot(overalice);
                     StartCoroutine("Startsd");
                    }
                }
                if(AliceCursoleStage.stagecount == 2) {
                    if(Gamepad.current.buttonEast.isPressed) {
                        overtitle = true;
                        StartCoroutine("Transparent");
                        osita = true;
                        aliceover.PlayOneShot(overalice);
                        StartCoroutine("Normal");
                    }
                }
                if(AliceCursoleStage.stagecount == 3) {
                    if(Gamepad.current.buttonEast.isPressed) {
                        overtitle = true;
                        StartCoroutine("Transparent");
                        osita = true;
                        aliceover.PlayOneShot(overalice);
                        StartCoroutine("Night");
                    }
                }

            }
            if(my.y < 573.34f && my.y > 381.34f) {
                if(Gamepad.current.buttonEast.isPressed) {
                    aliceover.PlayOneShot(overalice);
                    StartCoroutine("Transparent");
                    osita = true;
                    overtitle = true;
                    Alicetyutoriaru.nottyutorial = false;
                    AliceCursoleStage.stagecount = 0;
                    StartCoroutine("Stage");
                 
                }
            }
            if(my.y < 381.34f ) {
                if(Gamepad.current.buttonEast.isPressed) {
                    aliceover.PlayOneShot(overalice);
                    StartCoroutine("Transparent");
                    osita = true;
                    overtitle = true;
                    Alicetyutoriaru.nottyutorial = false;
                    AliceCursoleStage.stagecount = 0;
                    StartCoroutine("Home");
                }
            }
        }
    }
    IEnumerator Transparent() {

        int co = 5;
        while(co != 0) {
            for(int i = 0; i < 100; i++) {
                myarrow.color = new Color32(255, 255, 255, 0);
            }

            yield return new WaitForSeconds(0.1f);

            for(int k = 0; k < 100; k++) {
                myarrow.color = new Color32(255, 255, 255, 255);
            }

            yield return new WaitForSeconds(0.1f);
            co--;
            //mesh.color = mesh.color - new Color32(0, 0, 0, 0);
        }
    }
    IEnumerator Stage() {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("StageSentaku");
    }
    IEnumerator Startsd() {
        yield return new WaitForSeconds(2.7f);
        SceneManager.LoadScene("SampleScene");
    }
    IEnumerator Normal() {
        yield return new WaitForSeconds(2.7f);
        SceneManager.LoadScene("NormalStage");
    }
    ///ここはナイトメア
    IEnumerator Night() {
        yield return new WaitForSeconds(2.7f);
        SceneManager.LoadScene("NightmeaScene");
    }
    
    IEnumerator Home() {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("TitleScene");
    }
}
