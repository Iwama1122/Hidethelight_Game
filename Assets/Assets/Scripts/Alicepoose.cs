using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Alicepoose : MonoBehaviour
{
    [SerializeField]
    private GameObject line;
    [SerializeField]
    private GameObject lines;
    [SerializeField] private GameObject botton;
    [SerializeField] private GameObject botton1;
    [SerializeField] private GameObject botton2;
    [SerializeField] private GameObject botton3;
    Vector3 bo;//選択1
    Vector3 bo1;//選択2
    Vector3 bo2;//選択2
    Vector3 bo3;//ポーズ先の戻るボタンの位置
    Vector3 my;
    Vector3 mycopy;//次のシーンまたはワイプが出される前の押したボタンの位置
    [SerializeField]
    private GameObject myme;
    RawImage myarrow;
    bool osita = false;
    bool moidou = false;
    bool next = false;
    public bool NEXT {
        set {
            this.next = value;
        }
        get {
            return this.next;
        }
    }
    bool returntitle = false;
    public bool RETURNTITLE {
        set {
            this.returntitle = value;
        }
        get {
            return this.returntitle;
        }
    }
    [SerializeField] private GameObject sousasetumei;
    AudioSource alicepose;
    [SerializeField] private AudioClip poseaudio;
    // Start is called before the first frame update
    void Start()
    {
        alicepose = GetComponent<AudioSource>();
        line.SetActive(true);
        lines.SetActive(false);
        sousasetumei.SetActive(false);
        bo = botton.transform.position;
        bo1 = botton1.transform.position;
        bo2 = botton2.transform.position;
        bo3 = botton3.transform.position;
        this.transform.position = new Vector3(bo.x-300f, bo.y, 0);
        myarrow = myme.GetComponent<RawImage>();
        myarrow.color = new Color32(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
        my = transform.position;
        if(moidou == false) { 
        if(osita == false) {
                line.SetActive(true);
                lines.SetActive(false);
                if(my.y > 284f) {
                if(Gamepad.current.leftStick.down.wasPressedThisFrame) {//Gamepad.current.dpad.down.wasReleasedThisFrame
                    my.y -= 170.0f;
                    transform.position = my;
                }
            }
            if(my.y < 624f) {
                if(Gamepad.current.leftStick.up.wasPressedThisFrame) {//Gamepad.current.dpad.up.wasReleasedThisFrame
                    my.y += 170.0f;
                    transform.position = my;
                }
            }

            if(my.y == 624f) {
                if(Gamepad.current.buttonEast.isPressed) {
                    alicepose.PlayOneShot(poseaudio);
                        osita = true;
                    StartCoroutine("Transparents");
                    StartCoroutine("Next");

                }
            }
            if(my.y == 454f) {
                if(Gamepad.current.buttonEast.isPressed) {
                    alicepose.PlayOneShot(poseaudio);
                        StartCoroutine("Transparent");
                     
                        osita = true;
                    StartCoroutine("Windowidous");//ここには操作説明画面のUIを表示させて
                    //表示させたさきでボタンがおされたらositaのフラグをfalseにする
                }
            }
            if(my.y == 284f) {
                if(Gamepad.current.buttonEast.wasReleasedThisFrame) {
                        alicepose.PlayOneShot(poseaudio);
                        AliceCursoleStage.stagecount = 0;
                        Alicetyutoriaru.nottyutorial = false;
                        Alicetyutoriaru.gametutorial = false;
                      
                        StartCoroutine("Transparent");
                    osita = true;
                        returntitle = true;
                    StartCoroutine("Title");
                }
            }
        }
        }
        if(moidou == true) {
            if(my.y <= 121.37f) {
                if(Gamepad.current.buttonEast.isPressed) {
                    alicepose.PlayOneShot(poseaudio);
                    StartCoroutine("Transparent");
                    StartCoroutine("Windowidouex");
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
            
        }
    }
    IEnumerator Transparents() {

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

        }
        osita = false;
    }

    IEnumerator Title() {
        yield return new WaitForSeconds(4.0f);
        
        SceneManager.LoadScene("TitleScene");
    }
    IEnumerator Next() {
        yield return new WaitForSeconds(1.3f);
        next = true;
    }
    IEnumerator Windowidous() {
        yield return new WaitForSeconds(1.3f);
        sousasetumei.SetActive(true);
        line.SetActive(false);
        lines.SetActive(true);
        mycopy = my;
        transform.position = new Vector3(bo3.x - 200f, bo3.y, 0);
        moidou = true;
    }
    IEnumerator Windowidouex() {
        yield return new WaitForSeconds(1.3f);
        transform.position = mycopy;
        moidou = false;
        osita = false;
        sousasetumei.SetActive(false);
    }
}
